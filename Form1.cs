using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class StartForm : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=LibraryDataBase";
        RegisterForm registrationForm = null;
        LibraryForm libraryForm = null;
        NpgsqlConnection? DBConnection = null;
        

        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDB();
        }

        private void onRegisterButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            if (!TryLogin()) return;
        }

        private bool TryLogin()
        {
            if (DBConnection is null)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(libraryForm is not null)
            {
                libraryForm.Close();
            }

            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            try
            {
                string sql = "SELECT rights FROM users WHERE name = @name AND password = @password";

                using (var cmd = new NpgsqlCommand(sql, DBConnection))
                {
                    cmd.Parameters.AddWithValue("name", login);
                    cmd.Parameters.AddWithValue("password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string rights = reader["rights"].ToString();

                            MessageBox.Show($"Добро пожаловать, {login}! Ваша роль: {rights}",
                                "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            reader.Close();
                            UserInfo userInfo = new UserInfo
                            {
                                Name = login,
                                Password = password,
                                Rights = rights
                            };
                            libraryForm = new LibraryForm(DBConnection, userInfo);
                            libraryForm.Show();
                            if(registrationForm is not null) registrationForm.Close();
                            this.Hide();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private bool ValidateInputs()
        {
            bool isValid = true;
            if (!ValidateTextBox(LoginTextBox)) isValid = false;
            if (!ValidateTextBox(PasswordTextBox)) isValid = false;
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

        private void ConnectToDB()
        {
            string status = string.Empty;
            try
            {
                DBConnection = new NpgsqlConnection(connectionString);
                DBConnection.Open();
                status = "OK";
                DBStatusLabel.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                DBConnection = null;
                status = "ERROR";
                DBStatusLabel.BackColor = Color.Red;
            }
            Console.WriteLine(status);
            DBStatusLabel.Text = status;
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (registrationForm is not null)
            {
                registrationForm.Close();
            }
            if(DBConnection is null)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            registrationForm = new RegisterForm(DBConnection, onNewUserRegistered);
            registrationForm.Show();
        }

        private void onNewUserRegistered(string login, string password)
        {
            this.LoginTextBox.Text = login;
            this.PasswordTextBox.Text = password;
        }
    }
}
public class UserInfo
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Rights { get; set; }
}