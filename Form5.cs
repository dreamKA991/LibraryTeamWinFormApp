using Npgsql;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    public partial class UserSettings : Form
    {
        private NpgsqlConnection? dbConnection;
        private UserInfo selectedUserInfo, signedUserInfo;

        public UserSettings(NpgsqlConnection? dbConnection, UserInfo selectedUserInfo, UserInfo signedUserInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.selectedUserInfo = selectedUserInfo;
            this.signedUserInfo = signedUserInfo;

            this.Load += UserSettings_Load;
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            // Заповнення полів
            LoginTextBox.Text = selectedUserInfo.Name;
            PasswordTextBox.Text = selectedUserInfo.Password;

            switch (selectedUserInfo.Rights.ToLower())
            {
                case "reader": comboBoxRights.SelectedIndex = 0; break;
                case "librarian": comboBoxRights.SelectedIndex = 1; break;
                case "admin": comboBoxRights.SelectedIndex = 2; break;
            }

            ApplyColors();
        }

        private void ApplyColors()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");
            Color labelColor = ColorTranslator.FromHtml("#3A2A20");
            Color textBoxColor = ColorTranslator.FromHtml("#F7F2E8");
            Color activeTextBox = ColorTranslator.FromHtml("#FFF5D9");
            Color buttonBase = ColorTranslator.FromHtml("#3F2727");
            Color buttonHover = ColorTranslator.FromHtml("#5A3A3A");
            Font standardFont = new Font("Sitka Text", 10.2f);

            foreach (Control ctrl in this.Controls)
            {
                switch (ctrl)
                {
                    case TextBox tb:
                        tb.BackColor = textBoxColor;
                        tb.ForeColor = labelColor;
                        tb.Font = standardFont;
                        tb.TextAlign = HorizontalAlignment.Center;
                        tb.GotFocus += (s, e) => tb.BackColor = activeTextBox;
                        tb.LostFocus += (s, e) => tb.BackColor = textBoxColor;
                        break;

                    case ComboBox cb:
                        cb.BackColor = textBoxColor;
                        cb.ForeColor = labelColor;
                        cb.Font = standardFont;
                        cb.DropDownStyle = ComboBoxStyle.DropDownList;
                        break;

                    case Button btn:
                        btn.BackColor = buttonBase;
                        btn.ForeColor = Color.White;
                        btn.Font = standardFont;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Cursor = Cursors.Hand;
                        btn.MouseEnter += (s, e) => btn.BackColor = buttonHover;
                        btn.MouseLeave += (s, e) => btn.BackColor = buttonBase;
                        break;

                    case Label lbl:
                        lbl.ForeColor = labelColor;
                        lbl.BackColor = Color.Transparent;
                        lbl.Font = standardFont;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.BringToFront(); // щоб лейбл був поверх інших контролів
                        break;
                }
            }
        }

        private void SetUpButton_Click(object sender, EventArgs e)
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Немає підключення до бази даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newLogin = LoginTextBox.Text.Trim();
            string newPassword = PasswordTextBox.Text;
            string newRights = comboBoxRights.SelectedItem?.ToString().ToLower() ?? string.Empty;

            if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newRights))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(selectedUserInfo.Name, newLogin, StringComparison.OrdinalIgnoreCase))
            {
                if (NpgsqlExtensions.IsLoginExistsInDataBase(dbConnection, newLogin))
                {
                    MessageBox.Show("Користувач з таким логіном вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (signedUserInfo.Id == selectedUserInfo.Id &&
                !string.Equals(signedUserInfo.Rights, newRights, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Неможливо змінювати свої права.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isPasswordNeedToBeChanged = !string.IsNullOrEmpty(newPassword);

            try
            {
                string sql = isPasswordNeedToBeChanged
                    ? "UPDATE users SET name = @name, password = @password, rights = @rights WHERE id = @id"
                    : "UPDATE users SET name = @name, rights = @rights WHERE id = @id";

                using var cmd = new NpgsqlCommand(sql, dbConnection);
                cmd.Parameters.AddWithValue("name", newLogin);
                if (isPasswordNeedToBeChanged)
                    cmd.Parameters.AddWithValue("password", newPassword);
                cmd.Parameters.AddWithValue("rights", newRights);
                cmd.Parameters.AddWithValue("id", selectedUserInfo.Id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Зміни успішно збережено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не вдалося оновити дані. Перевірте ID користувача.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні користувача:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxRights_SelectedIndexChanged(object sender, EventArgs e) { }
        private void PasswordTextBox_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
