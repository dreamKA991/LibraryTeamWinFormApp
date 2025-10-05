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
                    return "reader";
                case 1:
                    return "librarian";
                case 2:
                    return "admin";
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
    }
}
