using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class LibraryForm : Form
    {
        NpgsqlConnection? dbConnection;
        UserInfo userInfo;
        public LibraryForm(NpgsqlConnection? dbConnection, UserInfo userInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.userInfo = userInfo;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = $"Library - {userInfo.Name} ({userInfo.Rights})";
        }
    }
}
