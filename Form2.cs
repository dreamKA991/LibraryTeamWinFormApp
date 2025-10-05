using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class RegisterForm : Form
    {
        NpgsqlConnection DBConnection;
        public Action<string, string> OnNewUserRegistered;

        public RegisterForm(NpgsqlConnection DBConnection, Action<string, string> OnNewUserRegisteredAction)
        {
            InitializeComponent();
            this.DBConnection = DBConnection;
            this.OnNewUserRegistered = OnNewUserRegisteredAction;
        }

        private void onRegisterButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            RegisterNewUser();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            LoginTextBox.ValidateTextBox();
            if (!LoginTextBox.ValidateTextBox()) isValid = false;
            if (!PasswordTextBox.ValidateTextBox()) isValid = false;
            if (comboBoxRights.SelectedItem == null)
            {
                comboBoxRights.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                comboBoxRights.BackColor = SystemColors.Window;
            }
            if(DBConnection.IsLoginExistsInDataBase(LoginTextBox.Text)) isValid = false;
            return isValid;
        }

        private void RegisterNewUser()
        {
            try
            {

                string sql = "INSERT INTO users (name, password, rights) VALUES (@name, @password, @rights)";
                using (var cmd = new NpgsqlCommand(sql, DBConnection))
                {
                    cmd.Parameters.AddWithValue("name", LoginTextBox.Text);
                    cmd.Parameters.AddWithValue("password", PasswordTextBox.Text);
                    cmd.Parameters.AddWithValue("rights", comboBoxRights.GetRightsStringFromComboBox());

                    int rows = cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User registered successfully!");
                OnNewUserRegistered?.Invoke(LoginTextBox.Text, PasswordTextBox.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}