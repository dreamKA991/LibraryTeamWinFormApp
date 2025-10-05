using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class TakeBookForm : Form
    {
        NpgsqlConnection? dbConnection = null;
        LibraryForm mainForm =null;
        int bookID;
        string bookTitle;
        public TakeBookForm(NpgsqlConnection? dbConnection, int bookID, string bookTitle, LibraryForm mainForm)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.bookID = bookID;
            this.bookTitle = bookTitle;
            this.mainForm = mainForm;
        }

        private void TakeBookForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Take Book - ID {bookID} {bookTitle}";
            returnDatePicker.MinDate = DateTime.Now.AddDays(1);
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            int userId = (int)numericUpDown1.Value;
            string login = string.Empty;

            // date for ui
            string dateOnly = returnDatePicker.Value.ToString("dd-MM-yyyy");

            // dates for db
            DateTime parsedDateToPut = returnDatePicker.Value.Date;
            DateTime parsedDateNow = DateTime.Now.Date;

            try
            {
                string query = "SELECT name FROM users WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show($"User with ID {userId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        login = reader["name"].ToString();

                        bool isLibrarianApproved = Microsoft.VisualBasic.Interaction.MsgBox(
                            $"Is data correct?\n Login: {login}\n Return date: {dateOnly}",
                            Microsoft.VisualBasic.MsgBoxStyle.YesNo,
                            "Librarian Approval"
                        ) == Microsoft.VisualBasic.MsgBoxResult.Yes;

                        if (!isLibrarianApproved)
                        {
                            MessageBox.Show("Librarian approval is required to take a book.", "Approval Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }

            try
            {
                string sql = "UPDATE books SET putToDate = @putToDate, takedDate = @takedDate, fk_usertakedbook_id = @fk_usertakedbook_id WHERE id = @bookId";

                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("putToDate", parsedDateToPut);
                    cmd.Parameters.AddWithValue("takedDate", parsedDateNow);
                    cmd.Parameters.AddWithValue("fk_usertakedbook_id", userId);
                    cmd.Parameters.AddWithValue("bookId", bookID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Success.\nLogin: {login}\nReturn date: {dateOnly}", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить данные. Проверьте ID пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении пользователя:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mainForm.UpdateBooksData();
        }

    }
}
