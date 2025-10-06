using Npgsql;
using System.Data;
using System.Net;

namespace LibraryTeamWinFormApp
{
    public partial class LibraryForm : Form, IDisposable
    {
        NpgsqlConnection? dbConnection;
        UserInfo userInfo;
        AdminPanel? adminPanelForm = null;
        AddNewBookInLibrary AddNewBookInLibrary = null;
        TakeBookForm? takeBookForm = null;
        DataTable cachedDataTable;
        EditBookForm? editBookForm = null;

        public LibraryForm(NpgsqlConnection? dbConnection, UserInfo userInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.userInfo = userInfo;
            this.FormClosed += (s, e) => Dispose();
        }

        public void UpdateBooksData() => LoadBooks(userInfo.Rights);

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = $"Library - {userInfo.Name} ({userInfo.Rights})";
            LoadBooks(userInfo.Rights);
        }

        private void LoadBooks(string rights)
        {
            switch (rights)
            {
                case "читач":
                    try
                    {
                        string query = @"SELECT id, title, CASE WHEN fk_usertakedbook_id IS NULL THEN true ELSE false END AS Availability FROM books ORDER BY id";

                        using (var adapter = new NpgsqlDataAdapter(query, dbConnection))
                        {
                            cachedDataTable = new DataTable();
                            adapter.Fill(cachedDataTable);
                            booksGridView.DataSource = cachedDataTable;
                        }

                        booksGridView.Columns["id"].HeaderText = "ID";
                        booksGridView.Columns["title"].HeaderText = "Title";
                        booksGridView.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        booksGridView.Columns["availability"].HeaderText = "Availability";
                        booksGridView.ReadOnly = true;
                        this.Width = 600;
                        booksGridView.Width = 490;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading books: " + ex.Message);
                    }
                    break;
                case "бібліотекар":
                case "адміністратор":
                    try
                    {
                        string query = @"SELECT id, title, CASE WHEN fk_usertakedbook_id IS NULL THEN true ELSE false END AS Availability, takeddate, puttodate FROM books ORDER BY id";

                        using (var adapter = new NpgsqlDataAdapter(query, dbConnection))
                        {
                            cachedDataTable = new DataTable();
                            adapter.Fill(cachedDataTable);
                            booksGridView.DataSource = cachedDataTable;
                        }

                        booksGridView.Columns["id"].HeaderText = "ID";
                        booksGridView.Columns["title"].HeaderText = "Title";
                        booksGridView.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        booksGridView.Columns["availability"].HeaderText = "Availability";
                        booksGridView.Columns["takeddate"].HeaderText = "Taked book date";
                        booksGridView.Columns["puttodate"].HeaderText = "Put to date";
                        booksGridView.ReadOnly = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading books: " + ex.Message);
                    }
                    break;
                    break;
                default:
                    MessageBox.Show("Unknown user rights.");
                    break;
            }
        }

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            if (adminPanelForm is not null)
            {
                adminPanelForm.Close();
            }
            if (userInfo.Rights != "адміністратор")
            {
                MessageBox.Show("Доступ заборонено. Тільки для адміністраторів.");
                return;
            }
            adminPanelForm = new AdminPanel(dbConnection, userInfo);
            adminPanelForm.Show();
        }

        private void Dispose()
        {
            dbConnection?.Close();
            dbConnection?.Dispose();
            Application.Exit();
        }

        private void FindBookByNameButton_Click(object sender, EventArgs e)
        {
            string name = FindBookByNameTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(name))
            {
                booksGridView.DataSource = cachedDataTable;
            }
            else
            {
                var filteredRows = cachedDataTable.AsEnumerable()
                    .Where(row => row.Field<string>("title").ToLower().Contains(name));

                DataTable filteredTable = filteredRows.Any()
                    ? filteredRows.CopyToDataTable()
                    : cachedDataTable.Clone();

                booksGridView.DataSource = filteredTable;
            }
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            if (userInfo.Rights != "адміністратор" && userInfo.Rights != "бібліотекар")
            {
                MessageBox.Show("Тiльки бібліотекарi та адміністратори можуть брати книги. Ви: " + userInfo.Rights);
                return;
            }
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to check availability.");
                return;
            }
            bool isBookAvailable = Convert.ToBoolean(booksGridView.SelectedRows[0].Cells["Availability"].Value);
            if (!isBookAvailable)
            {
                MessageBox.Show("This book is currently unavailable.");
                return;
            }

            int bookId = Convert.ToInt32(booksGridView.SelectedRows[0].Cells["ID"].Value);
            string bookTitle = booksGridView.SelectedRows[0].Cells["Title"].Value.ToString();
            if (takeBookForm is not null)
            {
                takeBookForm.Close();
            }
            takeBookForm = new TakeBookForm(dbConnection, bookId, bookTitle, this);
            takeBookForm.Show();
        }

        private void DeleteSelectedBook_Click(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = booksGridView.SelectedRows[0];
            int bookId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string bookTitle = selectedRow.Cells["title"].Value.ToString();

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete the book:\n\n'{bookTitle}' (ID: {bookId})?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string sql = "DELETE FROM books WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", bookId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Book '{bookTitle}' (ID: {bookId}) deleted successfully.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks(userInfo.Rights);
                    }
                    else
                    {
                        MessageBox.Show($"No book found with ID {bookId}.",
                            "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to return.");
                return;
            }

            bool isBookAvailable = Convert.ToBoolean(booksGridView.SelectedRows[0].Cells["Availability"].Value);
            if (isBookAvailable)
            {
                MessageBox.Show("This book is not currently taken.");
                return;
            }

            int bookId = Convert.ToInt32(booksGridView.SelectedRows[0].Cells["ID"].Value);
            string bookTitle = booksGridView.SelectedRows[0].Cells["Title"].Value.ToString();
            string login = String.Empty;
            int fk_usertakedbook_id = -1;
            DateTime dateToPut = new DateTime();

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
                            MessageBox.Show($"Book with ID {bookId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        fk_usertakedbook_id = Convert.ToInt32(reader["fk_usertakedbook_id"]);
                        dateToPut = Convert.ToDateTime(reader["puttodate"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching user id taked book: " + ex.Message);
            }

            try
            {
                string query = "SELECT name FROM users WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", fk_usertakedbook_id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show($"User with ID {fk_usertakedbook_id} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        login = reader["name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message);
            }

            string bookOverdue = String.Empty;
            bool isBookOverdue = DateTime.Now.Date > dateToPut.Date;
            bookOverdue = isBookOverdue ? "Iз запiзненням." : "Без запiзнення.";

            bool isLibrarianApproved = Microsoft.VisualBasic.Interaction.MsgBox(
                            $"Is data correct?\n User login: {login} with ID: {fk_usertakedbook_id}\n Returning book: \n ID {bookId} : {bookTitle} \n {bookOverdue}",
                            Microsoft.VisualBasic.MsgBoxStyle.YesNo,
                            "Librarian Approval"
                        ) == Microsoft.VisualBasic.MsgBoxResult.Yes;

            if (isLibrarianApproved)
            {
                try
                {
                    string sql = "UPDATE books SET putToDate = NULL, takedDate = NULL, fk_usertakedbook_id = NULL WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(sql, dbConnection))
                    {
                        cmd.Parameters.AddWithValue("id", bookId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Book ID {bookId} returned successfully.");
                            LoadBooks(userInfo.Rights);
                        }
                        else
                        {
                            MessageBox.Show($"No book found with ID {bookId}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error returning book: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Librarian approval is required to return a book.", "Approval Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            if (userInfo.Rights != "адміністратор" && userInfo.Rights != "бібліотекар")
            {
                MessageBox.Show("Тiльки бібліотекарi та адміністратори можуть додати книги. Ви " + userInfo.Rights);
                return;
            }

            if (AddNewBookInLibrary is not null)
            {
                AddNewBookInLibrary.Close();
            }

            AddNewBookInLibrary = new AddNewBookInLibrary(dbConnection, this);
            AddNewBookInLibrary.Show();
        }

        private void EditSelectedBookButton_Click(object sender, EventArgs e)
        {
            if (booksGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to check availability.");
                return;
            }
            int bookId = Convert.ToInt32(booksGridView.SelectedRows[0].Cells["ID"].Value);

            if (editBookForm is not null)
            {
                editBookForm.Close();
            }
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
                booksGridView.Columns["title"].HeaderText = "Book Title";
                booksGridView.Columns["borrower"].HeaderText = "Borrower";
                booksGridView.Columns["Taken Date"].HeaderText = "Taken";
                booksGridView.Columns["Return Date"].HeaderText = "Return Until";

                booksGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                booksGridView.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading overdue books: " + ex.Message);
            }
        }

        private void ShowAllLibraryButton_Click(object sender, EventArgs e)
        {
            UpdateBooksData();
        }
    }
}
