using Npgsql;
using System.Data;
using System.Data.Common;

namespace LibraryTeamWinFormApp
{
    public static class AdditionalFormsFunctionalityExtension
    {
        public static bool ValidateTextBox(this TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Red;
                return false;
            }

            textBox.BackColor = SystemColors.Window;

            return true;
        }

        public static bool IsHaveLiters(this TextBox textBox)
        {
            string text = textBox.Text;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                    return true;
            }

            return false;
        }

        public static NpgsqlConnection CreateConnection()
        {
            const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1;Database=test;Encoding=UTF8";
            return new NpgsqlConnection(connectionString);
        }

        public static bool ValidateConnection(this NpgsqlConnection connection)
        {
            if (connection is null)
            {
                MessageBox.Show("Немає підключення до бази даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення до бази даних:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static string SwitchRightsToUkrainian(this string rights)
        {
            switch (rights.ToLower())
            {
                case "reader": return "читач";
                case "librarian": return "бібліотекар";
                case "administrator": return "адміністратор";
                default: return "невідомі права";
            }
        }

        public static string SwitchRightsToPoop(this string rights)
        {
            switch (rights.ToLower())
            {
                case "читач": return "reader";
                case "бібліотекар": return "librarian";
                case "адміністратор": return "administrator";
                default: return "unknown role";
            }
        }

        public static string GetRightsStringFromComboBox(this ComboBox comboBox)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0: return "читач";
                case 1: return "бібліотекар";
                case 2: return "адміністратор";
                default: return string.Empty;
            }
        }
    }
}