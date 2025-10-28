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

        public RegisterForm(NpgsqlConnection dbConnection, Action<string, string> onNewUserRegistered)
        {
            InitializeComponent();

            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _onNewUserRegistered = onNewUserRegistered ?? throw new ArgumentNullException(nameof(onNewUserRegistered));

            RegisterButton.Click += RegisterButton_Click;
            this.FormClosing += RegisterForm_FormClosing;

            // Додаємо українські права користувачів
            comboBoxRights.Items.Clear();
            comboBoxRights.Items.AddRange(new string[] { "читач", "бібліотекар", "адмін" });
            comboBoxRights.SelectedIndex = 0; // за замовчуванням – читач
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            ApplyColorsAndAlignment();
            CenterControls();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            RegisterNewUser();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // дії при закритті форми
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
                LoginTextBox.BackColor = ColorTranslator.FromHtml("#F7F2E8");

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                PasswordTextBox.BackColor = Color.Red;
                isValid = false;
            }
            else
                PasswordTextBox.BackColor = ColorTranslator.FromHtml("#F7F2E8");

            if (comboBoxRights.SelectedItem == null)
            {
                comboBoxRights.BackColor = Color.Red;
                isValid = false;
            }
            else
                comboBoxRights.BackColor = ColorTranslator.FromHtml("#F7F2E8");

            if (NpgsqlExtensions.IsLoginExistsInDataBase(_dbConnection, LoginTextBox.Text.Trim()))
            {
                MessageBox.Show("Користувач з таким логіном вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            return isValid;
        }

        private void RegisterNewUser()
        {
            string sql = "INSERT INTO users (name, password, rights) VALUES (@name, @password, @rights)";
            using var cmd = new NpgsqlCommand(sql, _dbConnection);
            cmd.Parameters.AddWithValue("name", LoginTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("password", PasswordTextBox.Text.Trim());
            cmd.Parameters.AddWithValue("rights", comboBoxRights.SelectedItem?.ToString() ?? "читач");
            cmd.ExecuteNonQuery();

            MessageBox.Show("Користувача успішно зареєстровано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _onNewUserRegistered(LoginTextBox.Text.Trim(), PasswordTextBox.Text.Trim());
            this.Close();
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");
            Color labelColor = ColorTranslator.FromHtml("#3A2A20");

            foreach (Label lbl in new Label[] { label1, label2, label3, label4 })
            {
                lbl.ForeColor = labelColor;
                lbl.BackColor = Color.Transparent;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            foreach (TextBox tb in new TextBox[] { LoginTextBox, PasswordTextBox })
            {
                tb.BackColor = ColorTranslator.FromHtml("#F7F2E8");
                tb.ForeColor = labelColor;
                tb.TextAlign = HorizontalAlignment.Center;
                tb.GotFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml("#FFF5D9");
                tb.LostFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml("#F7F2E8");
            }

            comboBoxRights.BackColor = ColorTranslator.FromHtml("#F7F2E8");
            comboBoxRights.ForeColor = labelColor;
            comboBoxRights.DropDownStyle = ComboBoxStyle.DropDownList;

            RegisterButton.BackColor = ColorTranslator.FromHtml("#3F2727");
            RegisterButton.ForeColor = Color.White;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.FlatAppearance.BorderSize = 0;
            RegisterButton.Cursor = Cursors.Hand;
            RegisterButton.MouseEnter += (s, e) => RegisterButton.BackColor = ColorTranslator.FromHtml("#5A3A3A");
            RegisterButton.MouseLeave += (s, e) => RegisterButton.BackColor = ColorTranslator.FromHtml("#3F2727");
        }

        private void CenterControls()
        {
            Control[] controls = { label1, label2, label3, label4, LoginTextBox, PasswordTextBox, comboBoxRights, RegisterButton };
            foreach (Control ctrl in controls)
            {
                ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
