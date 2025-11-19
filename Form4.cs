using Npgsql;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    public partial class AdminPanel : Form
    {
        private UserInfo userInfo;
        private NpgsqlConnection? DBConnection;
        private UserSettings? userSettingsForm = null;

        public AdminPanel(NpgsqlConnection? dbConnection, UserInfo userInfo)
        {
            InitializeComponent();
            this.DBConnection = dbConnection;
            this.userInfo = userInfo;
            this.Load += AdminPanel_Load;
        }

        private void AdminPanel_Load(object? sender, EventArgs e)
        {
            if (userInfo == null)
            {
                MessageBox.Show("Немає інформації про користувача!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DBConnection == null)
            {
                MessageBox.Show("Немає підключення до бази даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Text = $"Панель адміністратора - {userInfo.Name} ({userInfo.Rights})";
            ApplyColorsAndAlignment();
            CenterControls();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                string query = "SELECT id, name AS login, rights FROM users ORDER BY id";

                using (var adapter = new NpgsqlDataAdapter(query, DBConnection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    usersGridView.DataSource = table;
                }

                usersGridView.Columns["id"].HeaderText = "ID";
                usersGridView.Columns["login"].HeaderText = "Логін";
                usersGridView.Columns["rights"].HeaderText = "Права";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження користувачів: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть користувача для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object? idValue = usersGridView.SelectedRows[0].Cells["id"].Value;
            object? loginValue = usersGridView.SelectedRows[0].Cells["login"].Value;
            if (idValue == null || loginValue == null) return;

            int userId = Convert.ToInt32(idValue);
            string login = loginValue.ToString()!;

            if (login == userInfo.Name)
            {
                MessageBox.Show("Ви не можете видалити свій обліковий запис.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkQuery = "SELECT COUNT(*) FROM books WHERE fk_usertakedbook_id = @id";

                using (var checkCmd = new NpgsqlCommand(checkQuery, DBConnection))
                {
                    checkCmd.Parameters.AddWithValue("@id", userId);
                    object? result = checkCmd.ExecuteScalar();
                    int takenCount = result != null ? Convert.ToInt32(result) : 0;

                    if (takenCount > 0)
                    {
                        MessageBox.Show($"Користувач '{login}' має {takenCount} взяту/взятих книгу(и). Поверніть книги перед видаленням.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка перевірки книг користувача: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Видалити користувача '{login}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM users WHERE id = @id";

                using (var cmd = new NpgsqlCommand(query, DBConnection))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();                                              
                }

                LoadUsers();
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть користувача для редагування.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object? idValue = usersGridView.SelectedRows[0].Cells["id"].Value;
            object? loginValue = usersGridView.SelectedRows[0].Cells["login"].Value;
            object? rightsValue = usersGridView.SelectedRows[0].Cells["rights"].Value;

            if (idValue == null || loginValue == null || rightsValue == null) return;

            int userId = Convert.ToInt32(idValue);
            string oldLogin = loginValue.ToString()!;
            string oldRights = rightsValue.ToString()!;

            userSettingsForm?.Close();

            userSettingsForm = new UserSettings(DBConnection, new UserInfo
            {
                Id = userId,
                Name = oldLogin,
                Rights = oldRights
            }, userInfo);

            userSettingsForm.FormClosed += (s, args) => LoadUsers();
            userSettingsForm.Show();

            // Стилізація ComboBox
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox cb)
                {
                    cb.BackColor = ColorTranslator.FromHtml("#F7F2E8");
                    cb.ForeColor = ColorTranslator.FromHtml("#3A2A20");
                    cb.Font = new Font("Sitka Text", 10.2f);
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");
            Color labelColor = ColorTranslator.FromHtml("#3A2A20");

            foreach (Control ctrl in this.Controls)
            {
                switch (ctrl)
                {
                    case Label lbl:
                        lbl.ForeColor = labelColor;
                        lbl.BackColor = Color.Transparent;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        break;
                    case Button btn:
                        Color buttonBase = ColorTranslator.FromHtml("#3F2727");
                        Color buttonHover = ColorTranslator.FromHtml("#5A3A3A");
                        btn.BackColor = buttonBase;
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Cursor = Cursors.Hand;
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        btn.MouseEnter += (s, e) => btn.BackColor = buttonHover;
                        btn.MouseLeave += (s, e) => btn.BackColor = buttonBase;
                        break;
                    case DataGridView grid:
                        grid.BackgroundColor = ColorTranslator.FromHtml("#F7F2E8");
                        grid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF5D9");
                        grid.DefaultCellStyle.ForeColor = labelColor;
                        grid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3A2A20");
                        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        grid.EnableHeadersVisualStyles = false;
                        break;
                }
            }
        }

        private void CenterControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
                }
            }
        }
    }
}
