using Npgsql;

namespace LibraryTeamWinFormApp
{
    public static class  AdditionalFormsFunctionalityExtension
    {
        public static bool ValidateTextBox(this TextBox textBox)
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

        public static string GetRightsStringFromComboBox(this ComboBox comboBox)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    return "читач";
                case 1:
                    return "бібліотекар";
                case 2:
                    return "адміністратор";
                default:
                    return string.Empty;
            }
        }

        public static bool IsHaveLiters(this TextBox textBox)
        {
            string text = textBox.Text;
            foreach (char c in text)
            {
                if (char.IsLetter(c)) return true;
            }
            return false;
        }

        public static bool IsLoginExistsInDataBase(this NpgsqlConnection dbConnection,string login)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM users WHERE name = @name";
                using (var cmd = new NpgsqlCommand(sql, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", login);

                    long count = (long)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show($"That login already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }
    }
}
