namespace LibraryTeamWinFormApp
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            label3 = new Label();
            RegisterButton = new Button();
            PasswordTextBox = new TextBox();
            LoginTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxRights = new ComboBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 10.1999989F);
            label4.Location = new Point(94, 111);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 11;
            label4.Text = "ПАРОЛЬ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.1999989F);
            label3.Location = new Point(107, 57);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 10;
            label3.Text = "ЛОГІН";
            // 
            // RegisterButton
            // 
            RegisterButton.Font = new Font("Sitka Text", 10.1999989F);
            RegisterButton.Location = new Point(50, 226);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(158, 33);
            RegisterButton.TabIndex = 9;
            RegisterButton.Text = "ЗАРЕЄСТРУВАТИСЬ";
            RegisterButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Sitka Text", 10.1999989F);
            PasswordTextBox.Location = new Point(50, 134);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.PlaceholderText = "Введіть новий пароль";
            PasswordTextBox.Size = new Size(158, 25);
            PasswordTextBox.TabIndex = 8;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Font = new Font("Sitka Text", 10.1999989F);
            LoginTextBox.Location = new Point(50, 80);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PlaceholderText = "Введіть новий логін";
            LoginTextBox.Size = new Size(158, 25);
            LoginTextBox.TabIndex = 7;
            LoginTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(84, 21);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 12;
            label1.Text = "РЕЄСТРАЦІЯ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(49, 182);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 14;
            label2.Text = "РОЛЬ:";
            // 
            // comboBoxRights
            // 
            comboBoxRights.Font = new Font("Sitka Text", 10.1999989F);
            comboBoxRights.ForeColor = SystemColors.WindowText;
            comboBoxRights.FormattingEnabled = true;
            comboBoxRights.Items.AddRange(new object[] { "Читач", "Бібліотекар", "Адміністратор" });
            comboBoxRights.Location = new Point(107, 179);
            comboBoxRights.Name = "comboBoxRights";
            comboBoxRights.Size = new Size(122, 28);
            comboBoxRights.TabIndex = 15;
            comboBoxRights.Text = "Вибрати роль";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 272);
            Controls.Add(comboBoxRights);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(RegisterButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Button RegisterButton;
        private TextBox PasswordTextBox;
        private TextBox LoginTextBox;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxRights;
    }
}