using Npgsql;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    public partial class TakeBookForm : Form
    {
        NpgsqlConnection? DBConnection = null;
        LibraryForm mainForm = null;
        int bookID;
        string bookTitle;

        private ComboBox comboBoxUserIds = new ComboBox();
        private Label selectedLoginLabel = new Label();

        public TakeBookForm(NpgsqlConnection? dbConnection, int bookID, string bookTitle, LibraryForm mainForm)
        {
            InitializeComponent();
            this.DBConnection = dbConnection;
            this.bookID = bookID;
            this.bookTitle = bookTitle;
            this.mainForm = mainForm;

            comboBoxUserIds.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUserIds.Width = 140;
            comboBoxUserIds.Height = 28;
            comboBoxUserIds.SelectedIndexChanged += ComboBoxUserIds_SelectedIndexChanged;
            comboBoxUserIds.Name = "comboBoxUserIds";

            selectedLoginLabel.AutoSize = true;
            selectedLoginLabel.Height = 28;
            selectedLoginLabel.TextAlign = ContentAlignment.MiddleLeft;
            selectedLoginLabel.Name = "selectedLoginLabel";

            this.Controls.Add(comboBoxUserIds);
            this.Controls.Add(selectedLoginLabel);
        }

        private void TakeBookForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Взяти книгу - ID {bookID} {bookTitle}";
            returnDatePicker.MinDate = DateTime.Now.AddDays(1);
            ApplyColorsAndAlignment();

            if (numericUpDown1 != null)
            {
                numericUpDown1.Visible = false;
                numericUpDown1.Enabled = false;
            }

            int topPosition = numericUpDown1 != null ? numericUpDown1.Top : 60;
            comboBoxUserIds.Top = topPosition;
            selectedLoginLabel.Top = topPosition + 4; 

            CenterControls();
            PopulateUsersCombo();
        }

        private void PopulateUsersCombo()
        {
            if (DBConnection == null)
            {
                MessageBox.Show("Немає підключення до бази даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "SELECT id, name FROM users ORDER BY id";

                using (var adapter = new NpgsqlDataAdapter(query, DBConnection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);

                    if (table.Columns.Contains("id") && table.Columns.Contains("name"))
                    {
                        comboBoxUserIds.DataSource = table;
                        comboBoxUserIds.DisplayMember = "id";    
                        comboBoxUserIds.ValueMember = "id";

                        if (comboBoxUserIds.Items.Count > 0)
                        {
                            comboBoxUserIds.SelectedIndex = 0;
                            UpdateSelectedLoginLabel();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження користувачів: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxUserIds_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateSelectedLoginLabel();
        }

        private void UpdateSelectedLoginLabel()
        {
            if (comboBoxUserIds.SelectedItem is DataRowView drv)
            {
                string name = drv["name"]?.ToString() ?? string.Empty;
                selectedLoginLabel.Text = $"Логін: {name}";
            }
            else
            {
                selectedLoginLabel.Text = string.Empty;
            }
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            int userId;
            string login = string.Empty;

            if (comboBoxUserIds.SelectedValue == null)
            {
                MessageBox.Show("Оберіть ID користувача зі списку.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                userId = Convert.ToInt32(comboBoxUserIds.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Невірний вибір користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dateOnly = returnDatePicker.Value.ToString("dd-MM-yyyy");
            DateTime parsedDateToPut = returnDatePicker.Value.Date;
            DateTime parsedDateNow = DateTime.Now.Date;
                
            // логін для combobox
            if (comboBoxUserIds.SelectedItem is DataRowView rv)
            {
                login = rv["name"]?.ToString() ?? string.Empty;
            }

            try
            {
                string query = "SELECT name FROM users WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, DBConnection))
                {
                    cmd.Parameters.AddWithValue("id", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show($"Користувача з ID {userId} не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (string.IsNullOrEmpty(login))
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

                using (var cmd = new NpgsqlCommand(sql, DBConnection))
                {
                    cmd.Parameters.AddWithValue("putToDate", parsedDateToPut);
                    cmd.Parameters.AddWithValue("takedDate", parsedDateNow);
                    cmd.Parameters.AddWithValue("fk_usertakedbook_id", userId);
                    cmd.Parameters.AddWithValue("bookId", bookID);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows <= 0)
                    {
                        MessageBox.Show("Не вдалося оновити дані.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show($"Успішно!\nКористувач: {login}\nДата повернення: {dateOnly}", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
                else if (ctrl is ComboBox cb)
                {
                    cb.BackColor = textBoxColor;
                    cb.ForeColor = labelColor;
                    cb.Font = new Font("Sitka Text", 10.2f);
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        private void CenterControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label && ctrl.Name != "selectedLoginLabel")
                {
                    ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
                }
                else if (ctrl is Button)
                {
                    ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
                }
                else if (ctrl is NumericUpDown)
                {
                    ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
                }
                else if (ctrl is DateTimePicker)
                {
                    ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
                }
                else if (ctrl is ComboBox cb && cb.Name == "comboBoxUserIds")
                {
                    cb.Left = (this.ClientSize.Width - cb.Width) / 2;
                    selectedLoginLabel.Left = cb.Right + 10;
                }
            }
        }
    }
}
