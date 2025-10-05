using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class AddNewBookInLibrary : Form
    {
        NpgsqlConnection? dbConnection;
        LibraryForm libraryForm;
        public AddNewBookInLibrary(NpgsqlConnection? dbConnection, LibraryForm libraryForm)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.libraryForm = libraryForm;
        }

        private void AddNewBookInLibrary_Load(object sender, EventArgs e)
        {

        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (!TitleBookTextBox.ValidateTextBox()) isValid = false;
            if (!ISBNBookTextBox.ValidateTextBox()) isValid = false;
            if (ISBNBookTextBox.IsHaveLiters() || ISBNBookTextBox.Text.Length > 32)
            {
                isValid = false;
                ISBNBookTextBox.BackColor = Color.Red;
            }
            else ISBNBookTextBox.BackColor = SystemColors.Window;
            if (!isValid) return;

            try
            {
                string sql = "INSERT INTO books (title, isbn) VALUES (@title, @isbn)";

                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("title", TitleBookTextBox.Text);
                    cmd.Parameters.AddWithValue("isbn", ISBNBookTextBox.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Книга успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить книгу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            libraryForm.UpdateBooksData();
            this.Close();
        }
    }
}
