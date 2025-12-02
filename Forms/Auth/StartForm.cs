using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Core.Models;
using LibraryTeamWinFormApp.Forms.Library;
using LibraryTeamWinFormApp.Forms.Shared;
using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp.Forms.Auth
{
    public partial class StartForm : BaseForm
    {
        private LibraryForm? libraryForm;

        public StartForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            Db.Init();
            UpdateConnectionStatus();
            ApplyFormSpecificStyles();
            CenterControls();
        }

        private void UpdateConnectionStatus()
        {
            // Используем новый метод проверки подключения
            bool isConnected = CheckConnection();
            connectionStatusLabel.Text = isConnected ? "Успішне" : "Помилка";
            connectionStatusLabel.ForeColor = isConnected ? Color.LightGreen : Color.Red;
        }

        private bool CheckConnection()
        {
            try
            {
                using var testConnection = new NpgsqlConnection(Db.ConnectionString);
                testConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ApplyFormSpecificStyles()
        {
            //CenterControls(label1, connectionStatusLabel, label2, label3, label4,
            //             LoginTextBox, PasswordTextBox, SignInButton, AddUserButton);
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (!ValidateDatabaseConnection()) return;
            if (!ValidateInputs()) return;

            AuthenticateUser();
        }

        private bool ValidateInputs()
        {
            return LoginTextBox.ValidateTextBox() && PasswordTextBox.ValidateTextBox();
        }

        private void AuthenticateUser()
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            const string sql = @"SELECT rights, id 
                                 FROM users 
                                 WHERE name = @name AND password = @password";

            try
            {
                // Создаем новое подключение специально для этого запроса
                using var authConnection = new NpgsqlConnection(Db.ConnectionString);
                authConnection.Open();

                using var cmd = new NpgsqlCommand(sql, authConnection);
                cmd.Parameters.AddWithValue("name", login);
                cmd.Parameters.AddWithValue("password", password);

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    ShowError("Невірний логін або пароль!");
                    return;
                }

                string rights = reader["rights"].ToString()!;
                int id = Convert.ToInt32(reader["id"]);

                string rightsUA = rights.ToUkrainianRights();

                ShowSuccess($"Ласкаво просимо до бібліотеки, {login}! Ваша роль: {rightsUA}");

                var userInfo = new UserInfo(id, login, password, rightsUA);
                libraryForm = new LibraryForm(userInfo);
                libraryForm.FormClosed += (s, args) => this.Show();
                libraryForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                ShowError($"Помилка авторизації: {ex.Message}");
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (!ValidateDatabaseConnection()) return;

            var regForm = new RegisterForm(OnNewUserRegistered);
            regForm.ShowDialog();
        }

        private void OnNewUserRegistered(string login, string password)
        {
            LoginTextBox.Text = login;
            PasswordTextBox.Text = password;
        }

        private bool ValidateDatabaseConnection()
        {
            return CheckConnection();
        }

        // Элементы управления
        private Label label1;
        private Label connectionStatusLabel;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox LoginTextBox;
        private TextBox PasswordTextBox;
        private Button SignInButton;
        private Button AddUserButton;
    }
}