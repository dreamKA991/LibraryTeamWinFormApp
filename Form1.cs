using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace LibraryTeamWinFormApp
{
    public partial class StartForm : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=librarydatabase";
        RegisterForm? registrationForm = null;
        LibraryForm? libraryForm = null;
        NpgsqlConnection? DBConnection = null;

        public StartForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            ConnectToDB();
            ApplyColorsAndAlignment();
            CenterControls();
        }

        private void onRegisterButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            TryLogin();
        }

        private bool TryLogin()
        {
            if (DBConnection == null)
            {
                MessageBox.Show("Немає підключення до бази даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            libraryForm?.Close();

            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            try
            {
                string sql = "SELECT rights, id FROM users WHERE name = @name AND password = @password";

                using (var cmd = new NpgsqlCommand(sql, DBConnection))
                {
                    cmd.Parameters.AddWithValue("name", login);
                    cmd.Parameters.AddWithValue("password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string rights = reader["rights"]?.ToString() ?? string.Empty;
                            int id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : -1;

                            // Переклад прав на українську
                            string rightsUA = rights switch
                            {
                                "reader" => "читач",
                                "librarian" => "бібліотекар",
                                "admin" => "адмін",
                                _ => rights
                            };

                            MessageBox.Show($"Ласкаво просимо, {login}! Ваша роль: {rightsUA}",
                                "Успішний вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            reader.Close();

                            UserInfo userInfo = new UserInfo
                            {
                                Id = id,
                                Name = login,
                                Password = password,
                                Rights = rightsUA
                            };

                            libraryForm = new LibraryForm(DBConnection, userInfo);
                            libraryForm.Show();
                            registrationForm?.Close();
                            this.Hide();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Невірний логін або пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка авторизації:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            if (!LoginTextBox.ValidateTextBox()) isValid = false;
            if (!PasswordTextBox.ValidateTextBox()) isValid = false;
            return isValid;
        }

        private void ConnectToDB()
        {
            try
            {
                DBConnection = new NpgsqlConnection(connectionString);
                DBConnection.Open();
                DBStatusLabel.BackColor = Color.LightGreen;
                DBStatusLabel.Text = "Підключення: успішне";
            }
            catch
            {
                DBConnection = null;
                DBStatusLabel.BackColor = Color.Red;
                DBStatusLabel.Text = "Підключення: помилка";
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            registrationForm?.Close();

            if (DBConnection == null)
            {
                MessageBox.Show("Немає підключення до бази даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            registrationForm = new RegisterForm(DBConnection, onNewUserRegistered);
            registrationForm.Show();
        }

        private void onNewUserRegistered(string login, string password)
        {
            this.LoginTextBox.Text = login;
            this.PasswordTextBox.Text = password;
        }

        private void ApplyColorsAndAlignment()
        {
            this.BackColor = ColorTranslator.FromHtml("#E8DCC8");
            Color labelColor = ColorTranslator.FromHtml("#3A2A20");

            Label[] labels = { DBStatusLabel, label2, label3, label4 };
            foreach (var lbl in labels)
            {
                lbl.ForeColor = labelColor;
                lbl.BackColor = Color.Transparent;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }

            Color textBoxColor = ColorTranslator.FromHtml("#F7F2E8");
            TextBox[] textBoxes = { LoginTextBox, PasswordTextBox };
            foreach (var tb in textBoxes)
            {
                tb.BackColor = textBoxColor;
                tb.ForeColor = labelColor;
                tb.TextAlign = HorizontalAlignment.Center;
                Color activeColor = ColorTranslator.FromHtml("#FFF5D9");
                tb.GotFocus += (s, e) => tb.BackColor = activeColor;
                tb.LostFocus += (s, e) => tb.BackColor = textBoxColor;
            }

            Color buttonBase = ColorTranslator.FromHtml("#3F2727");
            Color buttonHover = ColorTranslator.FromHtml("#5A3A3A");
            Button[] buttons = { SignInButton, AddUserButton };
            foreach (var btn in buttons)
            {
                btn.BackColor = buttonBase;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = buttonHover;
                btn.MouseLeave += (s, e) => btn.BackColor = buttonBase;
            }
        }

        private void CenterControls()
        {
            Label[] labels = { DBStatusLabel, label2, label3, label4 };
            foreach (var lbl in labels) lbl.Left = (this.ClientSize.Width - lbl.Width) / 2;

            TextBox[] textBoxes = { LoginTextBox, PasswordTextBox };
            foreach (var tb in textBoxes) tb.Left = (this.ClientSize.Width - tb.Width) / 2;

            Button[] buttons = { SignInButton, AddUserButton };
            foreach (var btn in buttons) btn.Left = (this.ClientSize.Width - btn.Width) / 2;
        }
    }

    public class UserInfo
    {
        public int Id = -1;
        public string Name = string.Empty;
        public string Password = string.Empty;
        public string Rights = string.Empty; // тепер зберігає українські значення: читач, бібліотекар, адмін
    }
}
