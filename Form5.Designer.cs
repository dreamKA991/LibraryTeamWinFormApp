namespace LibraryTeamWinFormApp
{
    partial class UserSettings
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
            comboBoxRights = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            SetUpButton = new Button();
            PasswordTextBox = new TextBox();
            LoginTextBox = new TextBox();
            SuspendLayout();
            // 
            // comboBoxRights
            // 
            comboBoxRights.ForeColor = SystemColors.WindowText;
            comboBoxRights.FormattingEnabled = true;
            comboBoxRights.Items.AddRange(new object[] { "Читач", "Бібліотекар", "Адміністратор" });
            comboBoxRights.Location = new Point(122, 164);
            comboBoxRights.Name = "comboBoxRights";
            comboBoxRights.Size = new Size(101, 23);
            comboBoxRights.TabIndex = 23;
            comboBoxRights.Text = "Select role";
            comboBoxRights.SelectedIndexChanged += comboBoxRights_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 167);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 22;
            label2.Text = "ROLE:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(120, 14);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 21;
            label1.Text = "Settings";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 91);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 20;
            label4.Text = "PASSWORD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 47);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 19;
            label3.Text = "LOGIN";
            // 
            // SetUpButton
            // 
            SetUpButton.Location = new Point(65, 215);
            SetUpButton.Name = "SetUpButton";
            SetUpButton.Size = new Size(158, 47);
            SetUpButton.TabIndex = 18;
            SetUpButton.Text = "Set";
            SetUpButton.UseVisualStyleBackColor = true;
            SetUpButton.Click += SetUpButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(64, 109);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Type new password";
            PasswordTextBox.Size = new Size(158, 23);
            PasswordTextBox.TabIndex = 17;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(65, 65);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PlaceholderText = "Type new login";
            LoginTextBox.Size = new Size(158, 23);
            LoginTextBox.TabIndex = 16;
            LoginTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // UserSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 299);
            Controls.Add(comboBoxRights);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SetUpButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Name = "UserSettings";
            Text = "UserSettings";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxRights;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button SetUpButton;
        private TextBox PasswordTextBox;
        private TextBox LoginTextBox;
    }
}