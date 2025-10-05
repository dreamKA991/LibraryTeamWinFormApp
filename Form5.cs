using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class UserSettings : Form
    {
        NpgsqlConnection? dbConnection;
        UserInfo selectedUserInfo, signedUserInfo;
        public UserSettings(NpgsqlConnection? dbConnection, UserInfo selectedUserInfo, UserInfo signedUserInfo)
        {
            InitializeComponent();
            this.dbConnection = dbConnection;
            this.selectedUserInfo = selectedUserInfo;
            this.signedUserInfo = signedUserInfo;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoginTextBox.Text = selectedUserInfo.Name;
            PasswordTextBox.Text = selectedUserInfo.Password;

            switch (selectedUserInfo.Rights)
            {
                case "reader":
                    comboBoxRights.SelectedIndex = 0;
                    break;
                case "librarian":
                    comboBoxRights.SelectedIndex = 1;
                    break;
                case "admin":
                    comboBoxRights.SelectedIndex = 2;
                    break;
            }
        }

        private void SetUpButton_Click(object sender, EventArgs e)
        {
            if (dbConnection == null)
            {
                MessageBox.Show("Нет подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation
            bool isValid = true;
            
            if (selectedUserInfo.Name != LoginTextBox.Text)
            {
                if(dbConnection.IsLoginExistsInDataBase(LoginTextBox.Text))
                {
                    isValid = false;
                    return;
                }
            }
            if (!LoginTextBox.ValidateTextBox() || comboBoxRights.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
                return;
            }
            if(signedUserInfo.Id == selectedUserInfo.Id)
            {
                if (signedUserInfo.Rights != comboBoxRights.SelectedItem.ToString().ToLower())
                {
                    MessageBox.Show("Нельзя изменять себе права.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isValid = false;
                    return;
                }
            }
            
            if (!isValid) return;
            bool isPasswordNeedToBeChanged = !String.IsNullOrEmpty(PasswordTextBox.Text);
            try
            {
                string sql = string.Empty;
                if (isPasswordNeedToBeChanged) 
                    sql = "UPDATE users SET name = @name, password = @password, rights = @rights WHERE id = @id";
                else
                    sql = "UPDATE users SET name = @name, rights = @rights WHERE id = @id";

                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                    {
                        cmd.Parameters.AddWithValue("name", LoginTextBox.Text);
                        if (isPasswordNeedToBeChanged) cmd.Parameters.AddWithValue("password", PasswordTextBox.Text);
                        cmd.Parameters.AddWithValue("rights", comboBoxRights.SelectedItem.ToString().ToLower());
                        cmd.Parameters.AddWithValue("id", selectedUserInfo.Id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Изменения успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить данные. Проверьте ID пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении пользователя:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxRights_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
