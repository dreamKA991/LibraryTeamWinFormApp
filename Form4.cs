using Npgsql;
using System.Data;

namespace LibraryTeamWinFormApp
{
    public partial class AdminPanel : Form
    {
        private UserInfo userInfo;
        private NpgsqlConnection? dbConnection;
        private UserSettings? userSettingsForm = null;

        public AdminPanel(NpgsqlConnection? dbConnection, UserInfo userInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.userInfo = userInfo;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            this.Text = $"Admin Panel - {userInfo.Name} ({userInfo.Rights})";
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                string query = "SELECT id, name AS login, rights FROM users ORDER BY id";
                using (var adapter = new NpgsqlDataAdapter(query, dbConnection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    usersGridView.DataSource = table;
                }

                usersGridView.Columns["id"].HeaderText = "ID";
                usersGridView.Columns["login"].HeaderText = "Login";
                usersGridView.Columns["rights"].HeaderText = "Rights";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (usersGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete.");
                return;
            }

            int userId = Convert.ToInt32(usersGridView.SelectedRows[0].Cells["id"].Value);
            string login = usersGridView.SelectedRows[0].Cells["login"].Value.ToString();

            var confirm = MessageBox.Show($"Delete user '{login}'?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM users WHERE id = @id";
                using (var cmd = new NpgsqlCommand(query, dbConnection))
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
                MessageBox.Show("Select a user to edit.");
                return;
            }

            int userId = Convert.ToInt32(usersGridView.SelectedRows[0].Cells["id"].Value);
            string oldLogin = usersGridView.SelectedRows[0].Cells["login"].Value.ToString();
            string oldRights = usersGridView.SelectedRows[0].Cells["rights"].Value.ToString();

            if(userSettingsForm is not null)
            {
                userSettingsForm.Close();
            }
            userSettingsForm = new UserSettings(dbConnection, new UserInfo { Id = userId, Name = oldLogin, Rights = oldRights });
            userSettingsForm.FormClosed += (s, args) => { LoadUsers(); };
            userSettingsForm.Show();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void usersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
