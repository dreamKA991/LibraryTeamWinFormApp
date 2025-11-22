using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class StartForm : Form
    {
        private LibraryForm? libraryForm = null;
        public NpgsqlConnection? DBConnection = null;

        const string BackgroundColor = "#E8DCC8";
        const string labelColor = "#3A2A20";
        const string textBoxColor = "#F7F2E8";
        const string activeColor = "#FFF5D9";
        const string buttonBase = "#3F2727";
        const string buttonHover = "#5A3A3A";

        public StartForm()
        {
            InitializeComponent();
            this.Load += StartForm_Load;
        }

        private void StartForm_Load(object? sender, EventArgs e)
        {
            DBConnection = AdditionalFormsFunctionalityExtension.CreateConnection();

            if (!DBConnection.ValidateConnection())
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Помилка";
            }
            else
            {
                label1.ForeColor = Color.LightGreen;
                label1.Text = "Успішне";
            }

            ApplyColorsAndAlignment();
            CenterControls();
        }

        private void onRegisterButton_Click(object sender, EventArgs e)
        {
            if (!DBConnection.ValidateConnection())
                return;

            if (!ValidateInputs())
                return;

            TryLogin();
        }

        private bool TryLogin()
        {
            libraryForm?.Close();

            AuthorizationUserForm();

            return true;
        }

        private void AuthorizationUserForm()
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            const string sql = @"SELECT rights, id FROM users WHERE name = @name AND password = @password";

            try
            {
                using var connection = AdditionalFormsFunctionalityExtension.CreateConnection();

                if (!connection.ValidateConnection())
                    return;

                using var cmd = new NpgsqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("name", login);
                cmd.Parameters.AddWithValue("password", password);

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Невірний логін або пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string rights = reader["rights"]?.ToString() ?? string.Empty;
                int id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : -1;

                string RightsToUA = AdditionalFormsFunctionalityExtension.SwitchRightsToUkrainian(rights);

                MessageBox.Show($"Ласкаво просимо до бібліотеки, {login}! Ваша роль: {RightsToUA}", "Успішний вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                var userInfo = new UserInfo(id, login, password, RightsToUA);

                using var lconnection = AdditionalFormsFunctionalityExtension.CreateConnection();

                if (!lconnection.ValidateConnection())
                    return;

                libraryForm = new LibraryForm(lconnection, userInfo);
                libraryForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка авторизації: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInputs()
        {
            return LoginTextBox.ValidateTextBox() && PasswordTextBox.ValidateTextBox();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (!DBConnection.ValidateConnection())
                return;

            using var regForm = new RegisterForm(DBConnection, onNewUserRegistered);
          
            this.Hide(); 
            regForm.ShowDialog(); 
            this.Show();
        }

        private void onNewUserRegistered(string login, string password)
        {
            LoginTextBox.Text = login;
            PasswordTextBox.Text = password;
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml(BackgroundColor);

            Label[] labels = { /* label1, */ label2, label3, label4 };
            foreach (var lbl in labels)
            {
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = ColorTranslator.FromHtml(labelColor);
            }

            TextBox[] textBoxes = { LoginTextBox, PasswordTextBox };
            foreach (var tb in textBoxes)
            {
                tb.TextAlign = HorizontalAlignment.Center;
                tb.BackColor = ColorTranslator.FromHtml(textBoxColor);
                tb.ForeColor = ColorTranslator.FromHtml(labelColor);
                tb.GotFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml(activeColor);
                tb.LostFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml(textBoxColor);
            }

            Button[] buttons = { SignInButton, AddUserButton };
            foreach (var btn in buttons)
            {
                btn.Cursor = Cursors.Hand;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.BackColor = ColorTranslator.FromHtml(buttonBase);
                btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml(buttonHover);
                btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(buttonBase);
            }
        }

        private void CenterControls()
        {
            Control[] controls = { label1, label2, label3, label4, LoginTextBox, PasswordTextBox, SignInButton, AddUserButton };
            foreach (Control parameters in controls)
            {
                parameters.Left = (this.ClientSize.Width - parameters.Width) / 2;
            }
        }
    }

    public class UserInfo
    {
        public int Id = -1;
        public string Name = string.Empty;
        public string Password = string.Empty;
        public string Rights = string.Empty;

        public UserInfo(int id = 0, string name = "", string password = "", string rights = "")
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Rights = rights;
        }
    }
}
