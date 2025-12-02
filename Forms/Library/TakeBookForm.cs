using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Forms.Shared;

namespace LibraryTeamWinFormApp.Forms.Library
{
    public partial class TakeBookForm : BaseForm
    {
        private readonly int _bookId;
        private readonly string _bookTitle;
        private readonly LibraryForm _mainForm;

        private ComboBox _comboBoxUserIds;
        private Label _selectedLoginLabel;

        public TakeBookForm(int bookId, string bookTitle, LibraryForm mainForm)
        {
            _bookId = bookId;
            _bookTitle = bookTitle;
            _mainForm = mainForm;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = $"Взяти книгу - ID {_bookId} {_bookTitle}";
            returnDatePicker.MinDate = DateTime.Now.AddDays(1);

            InitializeCustomControls();
            ApplyFormSpecificStyles();
            PopulateUsersCombo();
        }

        private void InitializeCustomControls()
        {
            _comboBoxUserIds = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 140,
                Height = 28,
                Name = "comboBoxUserIds"
            };
            _comboBoxUserIds.SelectedIndexChanged += ComboBoxUserIds_SelectedIndexChanged;

            _selectedLoginLabel = new Label
            {
                AutoSize = true,
                Height = 28,
                TextAlign = ContentAlignment.MiddleLeft,
                Name = "selectedLoginLabel"
            };

            this.Controls.Add(_comboBoxUserIds);
            this.Controls.Add(_selectedLoginLabel);

            if (numericUpDown1 != null)
            {
                numericUpDown1.Visible = false;
                numericUpDown1.Enabled = false;
            }

            int topPosition = numericUpDown1?.Top ?? 60;
            _comboBoxUserIds.Top = topPosition;
            _selectedLoginLabel.Top = topPosition + 4;
        }

        private void ApplyFormSpecificStyles()
        {
            CenterControls(returnDatePicker, TakeBookButton);

            _comboBoxUserIds.Left = (this.ClientSize.Width - _comboBoxUserIds.Width) / 2;
            _selectedLoginLabel.Left = _comboBoxUserIds.Right + 10;
        }

        private void PopulateUsersCombo()
        {
            if (!ValidateDatabaseConnection()) return;

            try
            {
                const string query = "SELECT id, name FROM users ORDER BY id";
                using var adapter = new NpgsqlDataAdapter(query, Db.Connection);
                var table = new DataTable();
                adapter.Fill(table);

                if (table.Columns.Contains("id") && table.Columns.Contains("name"))
                {
                    _comboBoxUserIds.DataSource = table;
                    _comboBoxUserIds.DisplayMember = "id";
                    _comboBoxUserIds.ValueMember = "id";

                    if (_comboBoxUserIds.Items.Count > 0)
                    {
                        _comboBoxUserIds.SelectedIndex = 0;
                        UpdateSelectedLoginLabel();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Помилка завантаження користувачів: " + ex.Message);
            }
        }

        private void ComboBoxUserIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedLoginLabel();
        }

        private void UpdateSelectedLoginLabel()
        {
            if (_comboBoxUserIds.SelectedItem is DataRowView drv)
            {
                string name = drv["name"]?.ToString() ?? string.Empty;
                _selectedLoginLabel.Text = $"Логін: {name}";
            }
            else
            {
                _selectedLoginLabel.Text = string.Empty;
            }
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            if (_comboBoxUserIds.SelectedValue == null)
            {
                ShowError("Оберіть ID користувача зі списку.");
                return;
            }

            if (!int.TryParse(_comboBoxUserIds.SelectedValue.ToString(), out int userId))
            {
                ShowError("Невірний вибір користувача.");
                return;
            }

            string dateOnly = returnDatePicker.Value.ToString("dd-MM-yyyy");
            DateTime parsedDateToPut = returnDatePicker.Value.Date;
            DateTime parsedDateNow = DateTime.Now.Date;

            string login = string.Empty;
            if (_comboBoxUserIds.SelectedItem is DataRowView rv)
            {
                login = rv["name"]?.ToString() ?? string.Empty;
            }

            try
            {
                const string query = "SELECT name FROM users WHERE id = @id";
                using var cmd = new NpgsqlCommand(query, Db.Connection);
                cmd.Parameters.AddWithValue("id", userId);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    ShowError($"Користувача з ID {userId} не знайдено.");
                    return;
                }

                if (string.IsNullOrEmpty(login))
                    login = reader["name"].ToString();
            }
            catch (Exception ex)
            {
                ShowError("Помилка завантаження користувачів: " + ex.Message);
                return;
            }

            var result = MessageBox.Show(
                $"Дані правильні?\nКористувач: {login}\nДата повернення: {dateOnly}",
                "Підтвердження бібліотекаря",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                ShowError("Потрібне підтвердження бібліотекаря.");
                return;
            }

            try
            {
                const string sql = @"UPDATE books 
                              SET putToDate=@putToDate, takedDate=@takedDate, 
                                  fk_usertakedbook_id=@fk_usertakedbook_id 
                              WHERE id=@bookId";

                using var cmd = new NpgsqlCommand(sql, Db.Connection);
                cmd.Parameters.AddWithValue("putToDate", parsedDateToPut);
                cmd.Parameters.AddWithValue("takedDate", parsedDateNow);
                cmd.Parameters.AddWithValue("fk_usertakedbook_id", userId);
                cmd.Parameters.AddWithValue("bookId", _bookId);

                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    ShowError("Не вдалося оновити дані.");
                    return;
                }

                ShowSuccess($"Успішно!\nКористувач: {login}\nДата повернення: {dateOnly}");
                _mainForm.UpdateBooksData();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Помилка бази даних:\n{ex.Message}");
            }
        }

        private Button TakeBookButton;
        private Label label1;
        private DateTimePicker returnDatePicker;
        private Label label2;
        private NumericUpDown numericUpDown1;
    }
}