using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class RegisterForm : Form
    {
        private readonly NpgsqlConnection _dbConnection;
        private readonly Action<string, string> _onNewUserRegistered;

        const string BackgroundColor = "#E8DCC8";
        const string labelColor = "#3A2A20";
        const string BoxBackgroundColor = "#F7F2E8";
        const string BoxHoverBackgroundColor = "#FFF5D9";
        const string ButtonBackgroundColor = "#3F2727";
        const string ButtonHoverBackgroundColor = "#5A3A3A";

        string[] roles = { "читач", "бібліотекар", "адміністратор" };


        public RegisterForm(NpgsqlConnection dbConnection, Action<string, string> onNewUserRegistered)
        {
            InitializeComponent();

            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _onNewUserRegistered = onNewUserRegistered ?? throw new ArgumentNullException(nameof(onNewUserRegistered));

            RegisterButton.Click += RegisterButton_Click;
            this.FormClosing += RegisterForm_FormClosing;

            comboBoxRights.Items.Clear();
            comboBoxRights.Items.AddRange(roles);
            comboBoxRights.SelectedIndex = 0; 
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            ApplyColorsAndAlignment();
            CenterControls();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) 
                return;

            RegisterNewUser();
        }

        // TODO: Clean all
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private bool ValidateInputs()
        {
            const string BackgroundColor = "#E8DCC8";

            LoginTextBox.BackColor = ColorTranslator.FromHtml(BackgroundColor);
            PasswordTextBox.BackColor = ColorTranslator.FromHtml(BackgroundColor);
            comboBoxRights.BackColor = ColorTranslator.FromHtml(BackgroundColor);

            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                LoginTextBox.BackColor = Color.Red;
                return false;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.BackColor = Color.Red;
                return false;
            }

            if (comboBoxRights.SelectedItem is null)
            {
                comboBoxRights.BackColor = Color.Red;
                return false;
            }

            if (NpgsqlExtensions.IsLoginExistsInDataBase(_dbConnection, LoginTextBox.Text.Trim()))
            {
                MessageBox.Show("Користувач з таким логіном вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void RegisterNewUser()
        {
            string selectedRights = comboBoxRights.SelectedItem?.ToString();

            string rightsInEnglish = AdditionalFormsFunctionalityExtension.SwitchRightsToPoop(selectedRights);

            const string sql = @"INSERT INTO users (name, password, rights) VALUES (@name, @password, @rights)";
            using var cmd = new NpgsqlCommand(sql, _dbConnection);
            cmd.Parameters.AddWithValue("name", LoginTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("password", PasswordTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("rights", rightsInEnglish); 
            cmd.ExecuteNonQuery();

            MessageBox.Show("Користувача успішно зареєстровано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _onNewUserRegistered(LoginTextBox.Text.Trim(), PasswordTextBox.Text.Trim());
            this.Close();
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml(BackgroundColor);

            foreach (Label lbl in new Label[] { label1, label2, label3, label4 })
            {
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = ColorTranslator.FromHtml(labelColor);
            }

            foreach (TextBox tb in new TextBox[] { LoginTextBox, PasswordTextBox })
            {
                tb.TextAlign = HorizontalAlignment.Center;
                tb.ForeColor = ColorTranslator.FromHtml(labelColor);
                tb.BackColor = ColorTranslator.FromHtml(BoxBackgroundColor);
                tb.GotFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml(BoxHoverBackgroundColor);
                tb.LostFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml(BoxBackgroundColor);
            }

            comboBoxRights.BackColor = ColorTranslator.FromHtml(BoxBackgroundColor);
            comboBoxRights.ForeColor = ColorTranslator.FromHtml(labelColor);
            comboBoxRights.DropDownStyle = ComboBoxStyle.DropDownList;

            RegisterButton.Cursor = Cursors.Hand;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.FlatAppearance.BorderSize = 0;
            RegisterButton.ForeColor = Color.White;
            RegisterButton.BackColor = ColorTranslator.FromHtml(ButtonBackgroundColor);
            RegisterButton.MouseEnter += (s, e) => RegisterButton.BackColor = ColorTranslator.FromHtml(ButtonHoverBackgroundColor);
            RegisterButton.MouseLeave += (s, e) => RegisterButton.BackColor = ColorTranslator.FromHtml(ButtonBackgroundColor);
        }

        private void CenterControls()
        {
            Control[] controls = { label1, label2, label3, label4, LoginTextBox, PasswordTextBox, comboBoxRights, RegisterButton };
            foreach (Control ctrl in controls)
            {
                ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            }
        }
    }

    public static class NpgsqlExtensions
    {
        public static bool IsLoginExistsInDataBase(this NpgsqlConnection connection, string login)
        {
            string sql = "SELECT COUNT(*) FROM users WHERE name = @name";
            using var cmd = new NpgsqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("name", login.Trim());
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}
