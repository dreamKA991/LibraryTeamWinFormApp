using System;
using System.Drawing;
using System.Windows.Forms;
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
            ApplyColorsAndAlignment();
        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            if (!TitleBookTextBox.ValidateTextBox() || !ISBNBookTextBox.ValidateTextBox())
                return;

            if (ISBNBookTextBox.IsHaveLiters() || ISBNBookTextBox.Text.Length > 32)
            {
                ISBNBookTextBox.BackColor = Color.LightCoral;
                return;
            }

            ISBNBookTextBox.BackColor = SystemColors.Window;

            try
            {
                string sql = "INSERT INTO books (title, isbn) VALUES (@title, @isbn)";

                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("title", TitleBookTextBox.Text);
                    cmd.Parameters.AddWithValue("isbn", ISBNBookTextBox.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        MessageBox.Show("Не вдалося додати книгу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Книгу успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    libraryForm.UpdateBooksData();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні книги:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            // Кнопки: додати книгу та скасувати
            Button[] buttons = CancelButton is Button cancelBtn && cancelBtn != null ? new[] { AddNewBookButton, cancelBtn } : new[] { AddNewBookButton };
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
