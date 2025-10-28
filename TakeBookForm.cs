using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    public partial class TakeBookForm : Form
    {
        NpgsqlConnection? dbConnection = null;
        LibraryForm mainForm = null;
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
            this.Text = $"Взяти книгу - ID {bookID} {bookTitle}";
            returnDatePicker.MinDate = DateTime.Now.AddDays(1);
            ApplyColorsAndAlignment();
            CenterControls();
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            int userId = (int)numericUpDown1.Value;
            string login = string.Empty;

            string dateOnly = returnDatePicker.Value.ToString("dd-MM-yyyy");
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
                            MessageBox.Show($"Користувача з ID {userId} не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        login = reader["name"].ToString();
                        bool approved = Microsoft.VisualBasic.Interaction.MsgBox(
                            $"Дані правильні?\nКористувач: {login}\nДата повернення: {dateOnly}",
                            Microsoft.VisualBasic.MsgBoxStyle.YesNo,
                            "Підтвердження бібліотекаря"
                        ) == Microsoft.VisualBasic.MsgBoxResult.Yes;

                        if (!approved)
                        {
                            MessageBox.Show("Потрібне підтвердження бібліотекаря.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження користувачів: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string sql = "UPDATE books SET putToDate=@putToDate, takedDate=@takedDate, fk_usertakedbook_id=@fk_usertakedbook_id WHERE id=@bookId";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("putToDate", parsedDateToPut);
                    cmd.Parameters.AddWithValue("takedDate", parsedDateNow);
                    cmd.Parameters.AddWithValue("fk_usertakedbook_id", userId);
                    cmd.Parameters.AddWithValue("bookId", bookID);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show($"Успішно!\nКористувач: {login}\nДата повернення: {dateOnly}", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося оновити дані.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка бази даних:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mainForm.UpdateBooksData();
        }

        // --- Дизайн ---
        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");
            Color labelColor = ColorTranslator.FromHtml("#3A2A20");
            Color textBoxColor = ColorTranslator.FromHtml("#F7F2E8");

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = labelColor;
                    lbl.BackColor = Color.Transparent;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                }
                else if (ctrl is Button btn)
                {
                    Color buttonBase = ColorTranslator.FromHtml("#3F2727");
                    Color buttonHover = ColorTranslator.FromHtml("#5A3A3A");

                    btn.BackColor = buttonBase;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += (s, e) => btn.BackColor = buttonHover;
                    btn.MouseLeave += (s, e) => btn.BackColor = buttonBase;
                }
                else if (ctrl is NumericUpDown num)
                {
                    num.BackColor = textBoxColor;
                    num.ForeColor = labelColor;
                    num.TextAlign = HorizontalAlignment.Center;
                }
            }
        }

        private void CenterControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label or Button or NumericUpDown or DateTimePicker)
                {
                    ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
                }
            }
        }

        private void returnDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Можна додати логіку при зміні дати, якщо потрібно
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Можна додати логіку при зміні ID користувача, якщо потрібно
        }
    }
}
