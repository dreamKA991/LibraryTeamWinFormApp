using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class LibraryForm : Form, IDisposable
    {
        NpgsqlConnection? dbConnection;
        UserInfo userInfo;
        AdminPanel? adminPanelForm = null;

        public LibraryForm(NpgsqlConnection? dbConnection, UserInfo userInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.userInfo = userInfo;
            this.FormClosed += (s, e) => Dispose();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = $"Library - {userInfo.Name} ({userInfo.Rights})";
        }

        private void AdminPanelButton_Click(object sender, EventArgs e)
        {
            if(adminPanelForm is not null)
            {
                adminPanelForm.Close();
            }
            adminPanelForm = new AdminPanel(dbConnection, userInfo);
            adminPanelForm.Show();
        }

        private void Dispose()
        {
            dbConnection?.Close();
            dbConnection?.Dispose();
            Application.Exit();
        }
    }
}
