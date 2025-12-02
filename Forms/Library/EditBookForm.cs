using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Forms.Shared;
using LibraryTeamWinFormApp.Common;

namespace LibraryTeamWinFormApp.Forms.Library
{
    public partial class EditBookForm : BaseForm
    {
        private readonly int _bookId;
        private readonly LibraryForm _libraryForm;

        public EditBookForm(int bookId, LibraryForm libraryForm)
        {
            _bookId = bookId;
            _libraryForm = libraryForm;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadBookData();
            ApplyFormSpecificStyles();
            CenterControls();
        }

        private void ApplyFormSpecificStyles()
        {
            //CenterControls(label1, label2, TitleTextBox, ISBNTextBox, SaveButton, CancelButton);
        }

        private void LoadBookData()
        {
            if (!ValidateDatabaseConnection()) return;

            try
            {
                const string query = "SELECT title, isbn FROM books WHERE id = @id";
                using var cmd = new NpgsqlCommand(query, Db.Connection);
                cmd.Parameters.AddWithValue("id", _bookId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TitleTextBox.Text = reader["title"]?.ToString() ?? "";
                    ISBNTextBox.Text = reader["isbn"]?.ToString() ?? "";
                }
                else
                {
                    ShowError("Книгу не знайдено.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowError("Помилка завантаження даних книги: " + ex.Message);
                this.Close();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                UpdateBookInDatabase();
            }
            catch (Exception ex)
            {
                ShowError($"Помилка при оновленні книги:\n{ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (!TitleTextBox.ValidateTextBox() || !ISBNTextBox.ValidateTextBox())
                return false;

            if (ISBNTextBox.HasLetters() || ISBNTextBox.Text.Length > Constants.MaxIsbnLength)
            {
                ISBNTextBox.BackColor = Color.LightCoral;
                ShowError($"ISBN не може містити літери або бути довшим за {Constants.MaxIsbnLength} символів.");
                return false;
            }

            ISBNTextBox.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            return true;
        }

        private void UpdateBookInDatabase()
        {
            const string sql = "UPDATE books SET title = @title, isbn = @isbn WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, Db.Connection);
            cmd.Parameters.AddWithValue("title", TitleTextBox.Text);
            cmd.Parameters.AddWithValue("isbn", ISBNTextBox.Text);
            cmd.Parameters.AddWithValue("id", _bookId);

            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
            {
                ShowError("Не вдалося оновити дані книги.");
                return;
            }

            ShowSuccess("Книгу успішно оновлено!");
            _libraryForm.UpdateBooksData();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label label1;
        private Label label2;
        private TextBox TitleTextBox;
        private TextBox ISBNTextBox;
        private Button SaveButton;
        private Button CancelButton;
    }
}