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
            label4.Location = new Point(93, 106);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 11;
            label4.Text = "PASSWORD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 62);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 10;
            label3.Text = "LOGIN";
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(50, 230);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(158, 47);
            RegisterButton.TabIndex = 9;
            RegisterButton.Text = "REGISTER";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += onRegisterButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(49, 124);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Type new password";
            PasswordTextBox.Size = new Size(158, 23);
            PasswordTextBox.TabIndex = 8;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(50, 80);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PlaceholderText = "Type new login";
            LoginTextBox.Size = new Size(158, 23);
            LoginTextBox.TabIndex = 7;
            LoginTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(84, 21);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 12;
            label1.Text = "REGISTRATION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 182);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 14;
            label2.Text = "ROLE:";
            // 
            // comboBoxRights
            // 
            comboBoxRights.ForeColor = SystemColors.WindowText;
            comboBoxRights.FormattingEnabled = true;
            comboBoxRights.Items.AddRange(new object[] { "Читач", "Бібліотекар", "Адміністратор" });
            comboBoxRights.Location = new Point(107, 179);
            comboBoxRights.Name = "comboBoxRights";
            comboBoxRights.Size = new Size(101, 23);
            comboBoxRights.TabIndex = 15;
            comboBoxRights.Text = "Select role";
            comboBoxRights.SelectedIndexChanged += comboBoxRights_SelectedIndexChanged;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 289);
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