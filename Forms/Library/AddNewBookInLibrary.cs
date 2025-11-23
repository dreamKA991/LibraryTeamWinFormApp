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
    public partial class AddNewBookInLibrary : BaseForm
    {
        private readonly LibraryForm _libraryForm;

        public AddNewBookInLibrary(LibraryForm libraryForm)
        {
            _libraryForm = libraryForm;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            ApplyFormSpecificStyles();
            CenterControls();
        }

        private void ApplyFormSpecificStyles()
        {
           // CenterControls(label1, label2, TitleBookTextBox, ISBNBookTextBox, AddNewBookButton);
           //
           // if (CancelButton != null)
           // {
           //     CenterControls(CancelButton);
           // }
        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                AddBookToDatabase();
            }
            catch (Exception ex)
            {
                ShowError($"Помилка при додаванні книги:\n{ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (!TitleBookTextBox.ValidateTextBox() || !ISBNBookTextBox.ValidateTextBox())
                return false;

            if (ISBNBookTextBox.HasLetters() || ISBNBookTextBox.Text.Length > Constants.MaxIsbnLength)
            {
                ISBNBookTextBox.BackColor = Color.LightCoral;
                ShowError($"ISBN не може містити літери або бути довшим за {Constants.MaxIsbnLength} символів.");
                return false;
            }

            ISBNBookTextBox.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            return true;
        }

        private void AddBookToDatabase()
        {
            const string sql = "INSERT INTO books (title, isbn) VALUES (@title, @isbn)";

            using var cmd = new NpgsqlCommand(sql, Db.Connection);
            cmd.Parameters.AddWithValue("title", TitleBookTextBox.Text);
            cmd.Parameters.AddWithValue("isbn", ISBNBookTextBox.Text);

            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
            {
                ShowError("Не вдалося додати книгу.");
                return;
            }

            ShowSuccess("Книгу успішно додано!");
            _libraryForm.UpdateBooksData();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Label label1;
        private Label label2;
        private TextBox TitleBookTextBox;
        private TextBox ISBNBookTextBox;
        private Button AddNewBookButton;
        private Button CancelButton;
    }
}