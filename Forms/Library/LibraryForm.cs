using LibraryTeamWinFormApp.Common;
using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Core.Models;
using LibraryTeamWinFormApp.Forms.Admin;
using LibraryTeamWinFormApp.Forms.Shared;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp.Forms.Library
{
    public partial class LibraryForm : BaseForm
    {
        private readonly UserInfo _user;
        private DataTable _cachedBooks = new DataTable();

        private AdminPanel? _adminPanel;
        private AddNewBookInLibrary? _addBookForm;
        private TakeBookForm? _takeBookForm;
        private EditBookForm? _editBookForm;

        public LibraryForm(UserInfo user)
        {
            _user = user;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = $"Бібліотека — {_user.Name} ({_user.Rights})";
            LoadBooks();
            ConfigureUIByRights();
            ApplyFormSpecificStyles();
        }

        private void ApplyFormSpecificStyles()
        {
            FormExtensions.ConfigureDataGrid(booksGridView);

            FindBookByNameTextBox.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            FindBookByNameTextBox.ForeColor = ColorTranslator.FromHtml(Colors.LabelColor);
            FindBookByNameTextBox.TextAlign = HorizontalAlignment.Center;

            CenterControls(FindLabel, label1, label2, FindBookByNameTextBox);
        }

        public void UpdateBooksData() => LoadBooks();

        private void LoadBooks()
        {
            if (!ValidateDatabaseConnection()) return;

            string query = _user.Rights.ToLower() switch
            {
                "читач" or "reader" =>
                    @"SELECT id, title,
                      CASE WHEN fk_usertakedbook_id IS NULL THEN TRUE ELSE FALSE END AS availability
                      FROM books ORDER BY id",

                "бібліотекар" or "librarian" or "адміністратор" or "administrator" =>
                    @"SELECT id, title,
                      CASE WHEN fk_usertakedbook_id IS NULL THEN TRUE ELSE FALSE END AS availability,
                      takeddate, puttodate
                      FROM books ORDER BY id",

                _ => throw new Exception("Невідомі права користувача!")
            };

            try
            {
                using var adapter = new NpgsqlDataAdapter(query, Db.Connection);
                _cachedBooks = new DataTable();
                adapter.Fill(_cachedBooks);

                booksGridView.DataSource = _cachedBooks;

                booksGridView.Columns["id"].HeaderText = "ID";
                booksGridView.Columns["title"].HeaderText = "Назва книги";
                booksGridView.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                booksGridView.Columns["availability"].HeaderText = "Доступність";

                if (HasLibrarianRights())
                {
                    booksGridView.Columns["takeddate"].HeaderText = "Дата взяття";
                    booksGridView.Columns["puttodate"].HeaderText = "Дата повернення";
                }
            }
            catch (Exception ex)
            {
                ShowError("Помилка завантаження книг: " + ex.Message);
            }
        }

        private bool HasAdminRights() =>
            _user.Rights is "адміністратор" or "administrator";

        private bool HasLibrarianRights() =>
            _user.Rights is "бібліотекар" or "librarian" || HasAdminRights();

        private bool IsReader() =>
            _user.Rights is "читач" or "reader";

        private void ConfigureUIByRights()
        {
            if (IsReader())
            {
                AdminPanelButton.Visible = false;
                AddNewBookButton.Visible = false;
                EditSelectedBookButton.Visible = false;
                DeleteSelectedBook.Visible = false;
                TakeBookButton.Visible = false;
                ReturnBookButton.Visible = false;
                ShowOverdueBooksButton.Visible = false;
                label2.Visible = false;
            }
            else
            {
                AddNewBookButton.Visible = true;
                EditSelectedBookButton.Visible = true;
                DeleteSelectedBook.Visible = true;
                TakeBookButton.Visible = true;
                ReturnBookButton.Visible = true;
                ShowOverdueBooksButton.Visible = true;
                label2.Visible = true;
            }

            AdminPanelButton.Visible = HasAdminRights();
        }

        private void FindBookByNameButton_Click(object sender, EventArgs e)
        {
            string text = FindBookByNameTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(text))
            {
                booksGridView.DataSource = _cachedBooks;
                return;
            }

            var filtered = _cachedBooks.AsEnumerable()
                .Where(r => r.Field<string>("title")!.ToLower().Contains(text));

            booksGridView.DataSource =
                filtered.Any() ? filtered.CopyToDataTable() : _cachedBooks.Clone();
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            if (!HasLibrarianRights())
            {
                ShowError("Тільки бібліотекарі можуть брати книги.");
                return;
            }

            if (!TryGetSelectedBook(out int id, out string title, out bool available))
                return;

            if (!available)
            {
                ShowError("Книга недоступна.");
                return;
            }

            _takeBookForm?.Close();
            _takeBookForm = new TakeBookForm(id, title, this);
            _takeBookForm.Show();
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedBook(out int id, out string title, out bool available))
                return;

            if (available)
            {
                ShowError("Ця книга вже повернена.");
                return;
            }

            try
            {
                int fkUser;
                DateTime dueDate;

                using (var cmd = new NpgsqlCommand(
                    "SELECT puttodate, fk_usertakedbook_id FROM books WHERE id=@i", Db.Connection))
                {
                    cmd.Parameters.AddWithValue("i", id);

                    using var r = cmd.ExecuteReader();
                    r.Read();

                    fkUser = r["fk_usertakedbook_id"] is DBNull ? -1 : (int)r["fk_usertakedbook_id"];
                    dueDate = r["puttodate"] is DBNull ? DateTime.Now : (DateTime)r["puttodate"];
                }

                string userName = "";
                if (fkUser != -1)
                {
                    using var cmd2 = new NpgsqlCommand("SELECT name FROM users WHERE id=@u", Db.Connection);
                    cmd2.Parameters.AddWithValue("u", fkUser);

                    using var rr = cmd2.ExecuteReader();
                    if (rr.Read())
                        userName = rr["name"]?.ToString() ?? "";
                }

                bool overdue = DateTime.Now.Date > dueDate.Date;

                if (MessageBox.Show(
                        $"Книга: {title}\nКористувач: {userName} (ID {fkUser})\nПовернення: {(overdue ? "З запізненням" : "Вчасно")}",
                        "Підтвердження",
                        MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                using var cmd3 = new NpgsqlCommand(
                    "UPDATE books SET takeddate=NULL, puttodate=NULL, fk_usertakedbook_id=NULL WHERE id=@id", Db.Connection);
                cmd3.Parameters.AddWithValue("id", id);
                cmd3.ExecuteNonQuery();

                ShowSuccess("Книгу повернено.");
                LoadBooks();
            }
            catch (Exception ex)
            {
                ShowError("Помилка повернення: " + ex.Message);
            }
        }

        private void DeleteSelectedBook_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedBook(out int id, out string title, out _))
                return;

            if (MessageBox.Show($"Видалити \"{title}\"?", "Підтвердження",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using var cmd = new NpgsqlCommand("DELETE FROM books WHERE id=@i", Db.Connection);
            cmd.Parameters.AddWithValue("i", id);
            cmd.ExecuteNonQuery();

            LoadBooks();
        }

        private void EditSelectedBookButton_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedBook(out int id, out _, out _))
                return;

            _editBookForm?.Close();
            _editBookForm = new EditBookForm(id, this);
            _editBookForm.Show();
        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            if (!HasLibrarianRights())
            {
                ShowError("Недостатньо прав.");
                return;
            }

            _addBookForm?.Close();
            _addBookForm = new AddNewBookInLibrary(this);
            _addBookForm.Show();
        }

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            if (!HasAdminRights())
            {
                ShowError("Доступ заборонено.");
                return;
            }

            _adminPanel?.Close();
            _adminPanel = new AdminPanel(_user);
            _adminPanel.Show();
        }

        private void ShowOverdueBooksButton_Click(object sender, EventArgs e)
        {
            const string query = @"
                SELECT b.id, b.title, u.name AS borrower, b.takeddate AS ""Взято"",
                       b.puttodate AS ""Повернути до""
                FROM books b
                JOIN users u ON b.fk_usertakedbook_id = u.id
                WHERE b.puttodate < CURRENT_DATE
                ORDER BY b.puttodate";

            using var adapter = new NpgsqlDataAdapter(query, Db.Connection);
            var tbl = new DataTable();
            adapter.Fill(tbl);

            booksGridView.DataSource = tbl;
        }

        private void ShowAllLibraryButton_Click(object sender, EventArgs e)
        {
            UpdateBooksData();
        }

        private bool TryGetSelectedBook(out int id, out string title, out bool available)
        {
            id = -1;
            title = "";
            available = false;

            if (booksGridView.SelectedRows.Count == 0)
            {
                ShowError("Оберіть книгу.");
                return false;
            }

            var row = booksGridView.SelectedRows[0];

            id = (int)row.Cells["id"].Value;
            title = row.Cells["title"].Value?.ToString() ?? "";
            available = Convert.ToBoolean(row.Cells["availability"].Value);

            return true;
        }

        // Дизайнерские поля
        private DataGridView booksGridView;
        private TextBox FindBookByNameTextBox;
        private Button AdminPanelButton;
        private Button TakeBookButton;
        private Button ReturnBookButton;
        private Button AddNewBookButton;
        private Button DeleteSelectedBook;
        private Button EditSelectedBookButton;
        private Button ShowOverdueBooksButton;
        private Button ShowAllLibraryButton;
        private Button FindBookByNameButton;
        private Label FindLabel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}