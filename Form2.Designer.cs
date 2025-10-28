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
            label4.Location = new Point(96, 150);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 11;
            label4.Text = "PASSWORD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.1999989F);
            label3.Location = new Point(122, 83);
            label3.Name = "label3";
            label3.Size = new Size(63, 24);
            label3.TabIndex = 10;
            label3.Text = "LOGIN";
            // 
            // RegisterButton
            // 
            RegisterButton.Font = new Font("Sitka Text", 10.1999989F);
            RegisterButton.Location = new Point(57, 302);
            RegisterButton.Margin = new Padding(3, 4, 3, 4);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(180, 44);
            RegisterButton.TabIndex = 9;
            RegisterButton.Text = "REGISTER";
            RegisterButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Sitka Text", 10.1999989F);
            PasswordTextBox.Location = new Point(57, 178);
            PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Type new password";
            PasswordTextBox.Size = new Size(180, 29);
            PasswordTextBox.TabIndex = 8;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Font = new Font("Sitka Text", 10.1999989F);
            LoginTextBox.Location = new Point(57, 107);
            LoginTextBox.Margin = new Padding(3, 4, 3, 4);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PlaceholderText = "Type new login";
            LoginTextBox.Size = new Size(180, 29);
            LoginTextBox.TabIndex = 7;
            LoginTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(96, 28);
            label1.Name = "label1";
            label1.Size = new Size(139, 24);
            label1.TabIndex = 12;
            label1.Text = "REGISTRATION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(56, 243);
            label2.Name = "label2";
            label2.Size = new Size(60, 24);
            label2.TabIndex = 14;
            label2.Text = "ROLE:";
            label2.Click += label2_Click;
            // 
            // comboBoxRights
            // 
            comboBoxRights.Font = new Font("Sitka Text", 10.1999989F);
            comboBoxRights.ForeColor = SystemColors.WindowText;
            comboBoxRights.FormattingEnabled = true;
            comboBoxRights.Items.AddRange(new object[] { "Читач", "Бібліотекар", "Адміністратор" });
            comboBoxRights.Location = new Point(122, 239);
            comboBoxRights.Margin = new Padding(3, 4, 3, 4);
            comboBoxRights.Name = "comboBoxRights";
            comboBoxRights.Size = new Size(115, 32);
            comboBoxRights.TabIndex = 15;
            comboBoxRights.Text = "Вибрати роль";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 363);
            Controls.Add(comboBoxRights);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(RegisterButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Margin = new Padding(3, 4, 3, 4);
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