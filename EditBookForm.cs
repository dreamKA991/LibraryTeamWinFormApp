using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class EditBookForm : Form
    {
        NpgsqlConnection? dbConnection;
        int bookID;
        LibraryForm libraryForm;

        public EditBookForm(NpgsqlConnection? dbConnection, int bookID, LibraryForm libraryForm)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.bookID = bookID;
            this.libraryForm = libraryForm;
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            ApplyColorsAndAlignment();

            try
            {
                string query = "SELECT title, isbn FROM books WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", bookID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show($"Книгу з ID {bookID} не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        TitleBookTextBox.Text = reader["title"].ToString();
                        ISBNBookTextBox.Text = reader["isbn"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при завантаженні книги: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Виправте виділені поля.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = "UPDATE books SET title = @title, isbn = @isbn WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("title", TitleBookTextBox.Text);
                    cmd.Parameters.AddWithValue("isbn", ISBNBookTextBox.Text);
                    cmd.Parameters.AddWithValue("id", bookID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Книгу успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        libraryForm.UpdateBooksData();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося оновити книгу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні книги:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            if (!TitleBookTextBox.ValidateTextBox()) isValid = false;
            if (!ISBNBookTextBox.ValidateTextBox()) isValid = false;
            return isValid;
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");

            Color labelColor = ColorTranslator.FromHtml("#3A2A20");
            Label[] labels = { label1, label2 };
            foreach (var lbl in labels)
            {
                lbl.ForeColor = labelColor;
                lbl.BackColor = Color.Transparent;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            Color textBoxColor = ColorTranslator.FromHtml("#F7F2E8");
            TextBox[] textBoxes = { TitleBookTextBox, ISBNBookTextBox };
            foreach (var tb in textBoxes)
            {
                tb.BackColor = textBoxColor;
                tb.ForeColor = labelColor;
                tb.TextAlign = HorizontalAlignment.Center;
                Color activeColor = ColorTranslator.FromHtml("#FFF5D9");
                tb.GotFocus += (s, e) => tb.BackColor = activeColor;
                tb.LostFocus += (s, e) => tb.BackColor = textBoxColor;
            }

            Color buttonBase = ColorTranslator.FromHtml("#3F2727");
            Color buttonHover = ColorTranslator.FromHtml("#5A3A3A");

            // Кнопки: "Оновити" та "Скасувати"
            Button[] buttons = { SetButton, (Button)CancelButton };
            foreach (var btn in buttons)
            {
                btn.BackColor = buttonBase;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = buttonHover;
                btn.MouseLeave += (s, e) => btn.BackColor = buttonBase;
                btn.Left = (this.ClientSize.Width - btn.Width) / 2;
            }
        }
    }
}
