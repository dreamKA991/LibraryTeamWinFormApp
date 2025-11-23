using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using LibraryTeamWinFormApp.Core.Models;
using LibraryTeamWinFormApp.Core.Database;
using LibraryTeamWinFormApp.Core.Extensions;
using LibraryTeamWinFormApp.Forms.Shared;
using LibraryTeamWinFormApp.Common;

namespace LibraryTeamWinFormApp.Forms.Admin
{
    public partial class UserSettings : BaseForm
    {
        private readonly UserInfo _selectedUser;
        private readonly UserInfo _signedInUser;

        public UserSettings(UserInfo selectedUserInfo, UserInfo signedInUser)
        {
            _selectedUser = selectedUserInfo;
            _signedInUser = signedInUser;
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            InitializeFormData();
            ApplyFormSpecificStyles();
        }

        private void InitializeFormData()
        {
            LoginTextBox.Text = _selectedUser.Name;
            PasswordTextBox.Text = _selectedUser.Password;

            comboBoxRights.Items.AddRange(Constants.UserRolesEnglish);

            switch (_selectedUser.Rights.ToLower())
            {
                case "reader": comboBoxRights.SelectedIndex = 0; break;
                case "librarian": comboBoxRights.SelectedIndex = 1; break;
                case "admin": comboBoxRights.SelectedIndex = 2; break;
                default: comboBoxRights.SelectedIndex = 0; break;
            }
        }

        private void ApplyFormSpecificStyles()
        {
           // CenterControls(label1, label2, label3, LoginTextBox,
           //              PasswordTextBox, comboBoxRights, SetUpButton);
        }

        private void SetUpButton_Click(object sender, EventArgs e)
        {
            if (!ValidateDatabaseConnection()) return;
            if (!ValidateInputs()) return;

            UpdateUser();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                LoginTextBox.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                LoginTextBox.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            }

            if (comboBoxRights.SelectedItem == null)
            {
                comboBoxRights.BackColor = Color.Red;
                isValid = false;
            }
            else
            {
                comboBoxRights.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            }

            if (isValid && !string.Equals(_selectedUser.Name, LoginTextBox.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                if (IsLoginExists(LoginTextBox.Text.Trim()))
                {
                    ShowError("Користувач з таким логіном вже існує.");
                    return false;
                }
            }

            if (_signedInUser.Id == _selectedUser.Id &&
                !string.Equals(_signedInUser.Rights, comboBoxRights.SelectedItem?.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                ShowError("Неможливо змінювати свої права.");
                return false;
            }

            return isValid;
        }

        private bool IsLoginExists(string login)
        {
            const string sql = "SELECT COUNT(*) FROM users WHERE name = @name AND id != @id";
            using var cmd = new NpgsqlCommand(sql, Db.Connection);
            cmd.Parameters.AddWithValue("name", login);
            cmd.Parameters.AddWithValue("id", _selectedUser.Id);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void UpdateUser()
        {
            string newLogin = LoginTextBox.Text.Trim();
            string newPassword = PasswordTextBox.Text;
            string newRights = comboBoxRights.SelectedItem?.ToString() ?? "reader";

            bool updatePassword = !string.IsNullOrEmpty(newPassword);

            try
            {
                string sql = updatePassword
                    ? "UPDATE users SET name = @name, password = @password, rights = @rights WHERE id = @id"
                    : "UPDATE users SET name = @name, rights = @rights WHERE id = @id";

                using var cmd = new NpgsqlCommand(sql, Db.Connection);
                cmd.Parameters.AddWithValue("name", newLogin);
                cmd.Parameters.AddWithValue("rights", newRights);
                cmd.Parameters.AddWithValue("id", _selectedUser.Id);

                if (updatePassword)
                    cmd.Parameters.AddWithValue("password", newPassword);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    ShowSuccess("Зміни успішно збережено!");
                    this.Close();
                }
                else
                {
                    ShowError("Не вдалося оновити дані.");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Помилка при оновленні користувача:\n{ex.Message}");
            }
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox LoginTextBox;
        private TextBox PasswordTextBox;
        private ComboBox comboBoxRights;
        private Button SetUpButton;
    }
}