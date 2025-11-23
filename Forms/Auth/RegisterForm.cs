using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Forms.Shared;
using LibraryTeamWinFormApp.Common;

namespace LibraryTeamWinFormApp.Forms.Auth
{
    public partial class RegisterForm : BaseForm
    {
        private readonly Action<string, string> _onNewUserRegistered;

        public RegisterForm(Action<string, string> onNewUserRegistered)
        {
            _onNewUserRegistered = onNewUserRegistered;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            comboBoxRights.Items.AddRange(Constants.UserRoles);
            comboBoxRights.SelectedIndex = 0;

            ApplyFormSpecificStyles();
            CenterControls();
        }

        private void ApplyFormSpecificStyles()
        {
           // CenterControls(label1, label2, label3, label4, LoginTextBox, PasswordTextBox, comboBoxRights, RegisterButton);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!ValidateDatabaseConnection()) return;
            if (!ValidateInputs()) return;

            RegisterNewUser();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (!LoginTextBox.ValidateTextBox())
                isValid = false;

            if (!PasswordTextBox.ValidateTextBox())
                isValid = false;

            if (comboBoxRights.SelectedItem == null)
            {
                comboBoxRights.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                comboBoxRights.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            }

            if (isValid && IsLoginExists(LoginTextBox.Text.Trim()))
            {
                ShowError("Користувач з таким логіном вже існує.");
                return false;
            }

            return isValid;
        }

        private bool IsLoginExists(string login)
        {
            const string sql = "SELECT COUNT(*) FROM users WHERE name = @name";
            using var cmd = new NpgsqlCommand(sql, Db.Connection);
            cmd.Parameters.AddWithValue("name", login);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void RegisterNewUser()
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string selectedRights = comboBoxRights.SelectedItem?.ToString() ?? "reader";
            string rightsInEnglish = selectedRights.ToEnglishRights();

            const string sql = @"INSERT INTO users (name, password, rights) VALUES (@name, @password, @rights)";

            try
            {
                using var cmd = new NpgsqlCommand(sql, Db.Connection);
                cmd.Parameters.AddWithValue("name", login);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("rights", rightsInEnglish);
                cmd.ExecuteNonQuery();

                ShowSuccess("Користувача успішно зареєстровано!");
                _onNewUserRegistered(login, password);
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Помилка реєстрації: {ex.Message}");
            }
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox LoginTextBox;
        private TextBox PasswordTextBox;
        private ComboBox comboBoxRights;
        private Button RegisterButton;
    }
}