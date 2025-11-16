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
            comboBoxRights.Font = new Font("Sitka Text", 10.1999989F);
            comboBoxRights.ForeColor = SystemColors.WindowText;
            comboBoxRights.FormattingEnabled = true;
            comboBoxRights.Items.AddRange(new object[] { "Читач", "Бібліотекар", "Адміністратор" });
            comboBoxRights.Location = new Point(122, 164);
            comboBoxRights.Name = "comboBoxRights";
            comboBoxRights.Size = new Size(122, 28);
            comboBoxRights.TabIndex = 23;
            comboBoxRights.Text = "Виберіть роль";
            comboBoxRights.SelectedIndexChanged += comboBoxRights_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(64, 167);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 22;
            label2.Text = "РОЛЬ:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F);
            label1.Location = new Point(88, 14);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 21;
            label1.Text = "Налаштування";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 10.1999989F);
            label4.Location = new Point(108, 91);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 20;
            label4.Text = "ПАРОЛЬ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.1999989F);
            label3.Location = new Point(122, 42);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 19;
            label3.Text = "ВХІД";
            // 
            // SetUpButton
            // 
            SetUpButton.Font = new Font("Sitka Text", 10.1999989F);
            SetUpButton.Location = new Point(65, 215);
            SetUpButton.Name = "SetUpButton";
            SetUpButton.Size = new Size(158, 28);
            SetUpButton.TabIndex = 18;
            SetUpButton.Text = "Встановити";
            SetUpButton.UseVisualStyleBackColor = true;
            SetUpButton.Click += SetUpButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Sitka Text", 10.1999989F);
            PasswordTextBox.Location = new Point(64, 114);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Введіть новий пароль";
            PasswordTextBox.Size = new Size(158, 25);
            PasswordTextBox.TabIndex = 17;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Font = new Font("Sitka Text", 10.1999989F);
            LoginTextBox.Location = new Point(65, 65);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PlaceholderText = "Введіть новий логін";
            LoginTextBox.Size = new Size(158, 25);
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