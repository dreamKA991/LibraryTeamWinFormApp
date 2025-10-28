using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    public partial class LibraryForm : Form, IDisposable
    {
        private NpgsqlConnection? dbConnection;
        private UserInfo userInfo;
        private AdminPanel? adminPanelForm = null;
        private AddNewBookInLibrary? addNewBookForm = null;
        private TakeBookForm? takeBookForm = null;
        private EditBookForm? editBookForm = null;
        private DataTable cachedDataTable;

        public LibraryForm(NpgsqlConnection? dbConnection, UserInfo userInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.userInfo = userInfo;
            this.FormClosed += (s, e) => Dispose();

            ApplyColorsAndAlignment();
        }

        public void UpdateBooksData() => LoadBooks(userInfo.Rights);

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Бібліотека - {userInfo.Name} ({userInfo.Rights})";
            LoadBooks(userInfo.Rights);
        }

        private void LoadBooks(string rights)
        {
            try
            {
                string query;

                if (rights == "читач")
                {
                    query = @"SELECT id, title, CASE WHEN fk_usertakedbook_id IS NULL THEN true ELSE false END AS Availability FROM books ORDER BY id";
                }
                else if (rights == "бібліотекар" || rights == "адміністратор")
                {
                    query = @"SELECT id, title, CASE WHEN fk_usertakedbook_id IS NULL THEN true ELSE false END AS Availability, takeddate, puttodate FROM books ORDER BY id";
                }
                else
                {
                    MessageBox.Show("Невідомі права користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var adapter = new NpgsqlDataAdapter(query, dbConnection))
                {
                    cachedDataTable = new DataTable();
                    adapter.Fill(cachedDataTable);
                    booksGridView.DataSource = cachedDataTable;
                }

                booksGridView.Columns["id"].HeaderText = "ID";
                booksGridView.Columns["title"].HeaderText = "Назва книги";
                booksGridView.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                booksGridView.Columns["availability"].HeaderText = "Доступність";

                if (rights != "читач")
                {
                    booksGridView.Columns["takeddate"].HeaderText = "Дата взяття";
                    booksGridView.Columns["puttodate"].HeaderText = "Дата повернення";
                }

                booksGridView.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження книг: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            if (adminPanelForm is not null)
                adminPanelForm.Close();

            if (userInfo.Rights != "адміністратор")
            {
                MessageBox.Show("Доступ заборонено. Тільки для адміністраторів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            adminPanelForm = new AdminPanel(dbConnection, userInfo);
            adminPanelForm.Show();
        }

        private void FindBookByNameButton_Click(object sender, EventArgs e)
        {
            string name = FindBookByNameTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(name))
            {
                booksGridView.DataSource = cachedDataTable;
                return;
            }

            var filteredRows = cachedDataTable.AsEnumerable()
                .Where(row => row.Field<string>("title").ToLower().Contains(name));

            DataTable filteredTable = filteredRows.Any()
                ? filteredRows.CopyToDataTable()
                : cachedDataTable.Clone();

            booksGridView.DataSource = filteredTable;
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            if (userInfo.Rights != "адміністратор" && userInfo.Rights != "бібліотекар")
            {
                MessageBox.Show("Тільки бібліотекарі та адміністратори можуть брати книги. Ви: " + userInfo.Rights, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть книгу для взяття.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isBookAvailable = Convert.ToBoolean(booksGridView.SelectedRows[0].Cells["Availability"].Value);
            if (!isBookAvailable)
            {
                MessageBox.Show("Ця книга наразі недоступна.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int bookId = Convert.ToInt32(booksGridView.SelectedRows[0].Cells["id"].Value);
            string bookTitle = booksGridView.SelectedRows[0].Cells["title"].Value.ToString() ?? "";

            takeBookForm?.Close();
            takeBookForm = new TakeBookForm(dbConnection, bookId, bookTitle, this);
            takeBookForm.Show();
        }

        private void DeleteSelectedBook_Click(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть книгу для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = booksGridView.SelectedRows[0];
            int bookId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string bookTitle = selectedRow.Cells["title"].Value.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Ви впевнені, що хочете видалити книгу:\n\n'{bookTitle}' (ID: {bookId})?",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM books WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", bookId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Книга '{bookTitle}' (ID: {bookId}) успішно видалена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks(userInfo.Rights);
                    }
                    else
                        MessageBox.Show($"Книгу з ID {bookId} не знайдено.", "Не знайдено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка видалення книги: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть книгу для повернення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isBookAvailable = Convert.ToBoolean(booksGridView.SelectedRows[0].Cells["Availability"].Value);
            if (isBookAvailable)
            {
                MessageBox.Show("Ця книга наразі не взята.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int bookId = Convert.ToInt32(booksGridView.SelectedRows[0].Cells["id"].Value);
            string bookTitle = booksGridView.SelectedRows[0].Cells["title"].Value.ToString() ?? "";
            int fk_usertakedbook_id = -1;
            DateTime dateToPut = new DateTime();
            string login = "";

            try
            {
                string query = "SELECT puttodate,fk_usertakedbook_id FROM books WHERE id = @bookId";
                using (var cmd = new NpgsqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show($"Книга з ID {bookId} не знайдена.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        fk_usertakedbook_id = Convert.ToInt32(reader["fk_usertakedbook_id"]);
                        dateToPut = Convert.ToDateTime(reader["puttodate"]);
                    }
                }

                string queryUser = "SELECT name FROM users WHERE id = @id";
                using (var cmd = new NpgsqlCommand(queryUser, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", fk_usertakedbook_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            login = reader["name"].ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка повернення книги: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isBookOverdue = DateTime.Now.Date > dateToPut.Date;
            string bookOverdue = isBookOverdue ? "З запізненням." : "Без запізнення.";

            bool isLibrarianApproved = Microsoft.VisualBasic.Interaction.MsgBox(
                $"Дані правильні?\n Користувач: {login} (ID: {fk_usertakedbook_id})\n Повернення книги: \n ID {bookId} : {bookTitle} \n {bookOverdue}",
                Microsoft.VisualBasic.MsgBoxStyle.YesNo,
                "Підтвердження бібліотекаря"
            ) == Microsoft.VisualBasic.MsgBoxResult.Yes;

            if (!isLibrarianApproved)
            {
                MessageBox.Show("Потрібне підтвердження бібліотекаря для повернення книги.", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "UPDATE books SET putToDate = NULL, takedDate = NULL, fk_usertakedbook_id = NULL WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", bookId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Книга ID {bookId} успішно повернена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks(userInfo.Rights);
                    }
                    else
                        MessageBox.Show($"Книга з ID {bookId} не знайдена.", "Не знайдено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка повернення книги: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            if (userInfo.Rights != "адміністратор" && userInfo.Rights != "бібліотекар")
            {
                MessageBox.Show("Тільки бібліотекарі та адміністратори можуть додавати книги. Ви: " + userInfo.Rights, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            addNewBookForm?.Close();
            addNewBookForm = new AddNewBookInLibrary(dbConnection, this);
            addNewBookForm.Show();
        }

        private void EditSelectedBookButton_Click(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть книгу для редагування.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(booksGridView.SelectedRows[0].Cells["id"].Value);

            editBookForm?.Close();
            editBookForm = new EditBookForm(dbConnection, bookId, this);
            editBookForm.Show();
        }

        private void ShowOverdueBooksButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT 
                        b.id, 
                        b.title, 
                        u.name AS borrower,
                        b.takeddate AS ""Taken Date"",
                        b.puttodate AS ""Return Date""
                    FROM books b
                    JOIN users u ON b.fk_usertakedbook_id = u.id
                    WHERE b.puttodate < CURRENT_DATE AND b.fk_usertakedbook_id IS NOT NULL
                    ORDER BY b.puttodate ASC;";

                using (var adapter = new NpgsqlDataAdapter(query, dbConnection))
                {
                    DataTable overdueDataTable = new DataTable();
                    adapter.Fill(overdueDataTable);
                    booksGridView.DataSource = overdueDataTable;
                }

                booksGridView.Columns["id"].HeaderText = "ID";
                booksGridView.Columns["title"].HeaderText = "Назва книги";
                booksGridView.Columns["borrower"].HeaderText = "Користувач";
                booksGridView.Columns["Taken Date"].HeaderText = "Дата взяття";
                booksGridView.Columns["Return Date"].HeaderText = "Дата повернення";
                booksGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                booksGridView.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження прострочених книг: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");

            Color labelColor = ColorTranslator.FromHtml("#3A2A20");

            Label[] labels = { FindLabel, label1, label2, label3 };
            foreach (var lbl in labels)
            {
                lbl.ForeColor = labelColor;
                lbl.BackColor = Color.Transparent;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            booksGridView.BackgroundColor = ColorTranslator.FromHtml("#F7F2E8");
            booksGridView.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F7F2E8");
            booksGridView.DefaultCellStyle.ForeColor = labelColor;
            booksGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3F2727");
            booksGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            booksGridView.EnableHeadersVisualStyles = false;

            Color buttonBase = ColorTranslator.FromHtml("#3F2727");
            Color buttonHover = ColorTranslator.FromHtml("#5A3A3A");
            Button[] buttons = { AdminPanelButton, TakeBookButton, ReturnBookButton, AddNewBookButton,
                                 DeleteSelectedBook, EditSelectedBookButton, ShowOverdueBooksButton, ShowAllLibraryButton, FindBookByNameButton };

            foreach (var btn in buttons)
            {
                btn.BackColor = buttonBase;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = buttonHover;
                btn.MouseLeave += (s, e) => btn.BackColor = buttonBase;
            }

            Color textBoxColor = ColorTranslator.FromHtml("#F7F2E8");
            TextBox[] textBoxes = { FindBookByNameTextBox };
            foreach (var tb in textBoxes)
            {
                tb.BackColor = textBoxColor;
                tb.ForeColor = labelColor;
                tb.TextAlign = HorizontalAlignment.Center;
                Color activeColor = ColorTranslator.FromHtml("#FFF5D9");
                tb.GotFocus += (s, e) => tb.BackColor = activeColor;
                tb.LostFocus += (s, e) => tb.BackColor = textBoxColor;
            }
        }

        private void ShowAllLibraryButton_Click(object sender, EventArgs e)
        {
            UpdateBooksData();
        }

        public void Dispose()
        {
            dbConnection?.Close();
            dbConnection?.Dispose();
            Application.Exit();
        }
    }
}
