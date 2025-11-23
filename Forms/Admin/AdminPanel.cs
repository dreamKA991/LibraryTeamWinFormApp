using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using LibraryTeamWinFormApp.Core.Models;
using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Forms.Shared;

namespace LibraryTeamWinFormApp.Forms.Admin
{
    public partial class AdminPanel : BaseForm
    {
        private readonly UserInfo _currentUser;

        public AdminPanel(UserInfo userInfo)
        {
            _currentUser = userInfo;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            if (!ValidateDatabaseConnection()) return;

            Text = $"Панель адміністратора - {_currentUser.Name} ({_currentUser.Rights})";
            ApplyFormSpecificStyles();
            LoadUsers();
        }

        private void ApplyFormSpecificStyles()
        {
            CenterControls(label1);
            FormExtensions.ConfigureDataGrid(usersGridView);
        }

        private void LoadUsers()
        {
            try
            {
                const string query = "SELECT id, name AS login, rights FROM users ORDER BY id";
                using var adapter = new NpgsqlDataAdapter(query, Db.Connection);
                var table = new DataTable();
                adapter.Fill(table);

                usersGridView.DataSource = table;

                usersGridView.Columns["id"].HeaderText = "ID";
                usersGridView.Columns["login"].HeaderText = "Логін";
                usersGridView.Columns["rights"].HeaderText = "Права";
            }
            catch (Exception ex)
            {
                ShowError($"Помилка завантаження користувачів: {ex.Message}");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedUser(out int userId, out string login)) return;

            if (login == _currentUser.Name)
            {
                ShowError("Ви не можете видалити свій обліковий запис.");
                return;
            }

            if (HasTakenBooks(userId))
            {
                ShowError($"Користувач '{login}' має взяті книги. Поверніть книги перед видаленням.");
                return;
            }

            if (MessageBox.Show($"Видалити користувача '{login}'?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteUser(userId);
            }
        }

        private bool TryGetSelectedUser(out int userId, out string login)
        {
            userId = -1;
            login = string.Empty;

            if (usersGridView.SelectedRows.Count == 0)
            {
                ShowError("Оберіть користувача.");
                return false;
            }

            var row = usersGridView.SelectedRows[0];
            userId = Convert.ToInt32(row.Cells["id"].Value);
            login = row.Cells["login"].Value?.ToString() ?? "";

            return true;
        }

        private bool HasTakenBooks(int userId)
        {
            const string query = "SELECT COUNT(*) FROM books WHERE fk_usertakedbook_id = @id";
            using var cmd = new NpgsqlCommand(query, Db.Connection);
            cmd.Parameters.AddWithValue("@id", userId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void DeleteUser(int userId)
        {
            const string query = "DELETE FROM users WHERE id = @id";
            using var cmd = new NpgsqlCommand(query, Db.Connection);
            cmd.Parameters.AddWithValue("@id", userId);
            cmd.ExecuteNonQuery();

            LoadUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedUser(out int userId, out string login)) return;

            var row = usersGridView.SelectedRows[0];
            string rights = row.Cells["rights"].Value?.ToString() ?? "";

            var selectedUserInfo = new UserInfo(userId, login, "", rights);
            var userSettingsForm = new UserSettings(selectedUserInfo, _currentUser);

            userSettingsForm.FormClosed += (s, args) => LoadUsers();
            userSettingsForm.Show();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // Дизайнерские поля
        private DataGridView usersGridView;
        private Label label1;
        private Button btnDeleteUser;
        private Button btnEditUser;
        private Button RefreshButton;
    }
}