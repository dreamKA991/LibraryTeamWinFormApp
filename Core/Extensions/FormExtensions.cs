using LibraryTeamWinFormApp.Common;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp.Core.Extensions
{
    public static class FormExtensions
    {
        public static bool ValidateTextBox(this TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Red;
                return false;
            }

            textBox.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            return true;
        }

        public static bool HasLetters(this TextBox textBox)
        {
            return textBox.Text.Any(char.IsLetter);
        }

        public static string ToUkrainianRights(this string rights)
        {
            return rights.ToLower() switch
            {
                "reader" => "читач",
                "librarian" => "бібліотекар",
                "administrator" => "адміністратор",
                _ => "невідомі права"
            };
        }

        public static string ToEnglishRights(this string rights)
        {
            return rights.ToLower() switch
            {
                "читач" => "reader",
                "бібліотекар" => "librarian",
                "адміністратор" => "administrator",
                _ => "unknown"
            };
        }

        public static void ApplyLibraryTheme(this Control control)
        {
            control.BackColor = ColorTranslator.FromHtml(Colors.BackgroundColor);

            foreach (Control ctrl in control.Controls)
            {
                switch (ctrl)
                {
                    case Label lbl:
                        lbl.ForeColor = ColorTranslator.FromHtml(Colors.LabelColor);
                        lbl.BackColor = Color.Transparent;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        break;

                    case TextBox tb:
                        ConfigureTextBox(tb);
                        break;

                    case Button btn:
                        ConfigureButton(btn);
                        break;

                    case DataGridView grid:
                        ConfigureDataGrid(grid);
                        break;

                    case ComboBox cb:
                        ConfigureComboBox(cb);
                        break;
                }
            }
        }
        public static void CenterControls(this Control form, params Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control != null)
                {
                    control.Left = (form.ClientSize.Width - control.Width) / 2;
                }
            }
        }

        private static void ConfigureTextBox(TextBox tb)
        {
            tb.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            tb.ForeColor = ColorTranslator.FromHtml(Colors.LabelColor);
            tb.TextAlign = HorizontalAlignment.Center;

            tb.GotFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml(Colors.ActiveColor);
            tb.LostFocus += (s, e) => tb.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
        }

        private static void ConfigureButton(Button btn)
        {
            btn.BackColor = ColorTranslator.FromHtml(Colors.ButtonBase);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;

            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml(Colors.ButtonHover);
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(Colors.ButtonBase);
        }

        public static void ConfigureDataGrid(DataGridView grid)
        {
            grid.BackgroundColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            grid.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(Colors.ActiveColor);
            grid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(Colors.LabelColor);
            grid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(Colors.ButtonBase);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.EnableHeadersVisualStyles = false;
        }

        private static void ConfigureComboBox(ComboBox cb)
        {
            cb.BackColor = ColorTranslator.FromHtml(Colors.TextBoxColor);
            cb.ForeColor = ColorTranslator.FromHtml(Colors.LabelColor);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}