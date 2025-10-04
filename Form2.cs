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
            if (!ValidateTextBox(LoginTextBox)) isValid = false;
            if (!ValidateTextBox(PasswordTextBox)) isValid = false;
            if (comboBoxRights.SelectedItem == null)
            {
                comboBoxRights.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                comboBoxRights.BackColor = SystemColors.Window;
            }
            return isValid;
        }

        private bool ValidateTextBox(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Red;
                return false;
            }
            else
            {
                textBox.BackColor = SystemColors.Window;
                return true;
            }
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
                    cmd.Parameters.AddWithValue("rights", GetRightsStringFromComboBox());

                    int rows = cmd.ExecuteNonQuery();
                }

                // Implement user registration logic here
                MessageBox.Show("User registered successfully!");
                OnNewUserRegistered?.Invoke(LoginTextBox.Text, PasswordTextBox.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRightsStringFromComboBox()
        {
            switch (comboBoxRights.SelectedIndex)
            {
                case 0:
                    return "admin";
                case 1:
                    return "librarian";
                case 2:
                    return "reader";
                default:
                    return string.Empty;
            }
        }
    }
}