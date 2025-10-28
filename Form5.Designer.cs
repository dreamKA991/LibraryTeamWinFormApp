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
            comboBoxRights.Location = new Point(139, 219);
            comboBoxRights.Margin = new Padding(3, 4, 3, 4);
            comboBoxRights.Name = "comboBoxRights";
            comboBoxRights.Size = new Size(115, 32);
            comboBoxRights.TabIndex = 23;
            comboBoxRights.Text = "Select role";
            comboBoxRights.SelectedIndexChanged += comboBoxRights_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(73, 223);
            label2.Name = "label2";
            label2.Size = new Size(61, 24);
            label2.TabIndex = 22;
            label2.Text = "РОЛЬ:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F);
            label1.Location = new Point(100, 19);
            label1.Name = "label1";
            label1.Size = new Size(134, 24);
            label1.TabIndex = 21;
            label1.Text = "Налаштування";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 10.1999989F);
            label4.Location = new Point(123, 121);
            label4.Name = "label4";
            label4.Size = new Size(79, 24);
            label4.TabIndex = 20;
            label4.Text = "ПАРОЛЬ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.1999989F);
            label3.Location = new Point(139, 63);
            label3.Name = "label3";
            label3.Size = new Size(51, 24);
            label3.TabIndex = 19;
            label3.Text = "ВХІД";
            // 
            // SetUpButton
            // 
            SetUpButton.Font = new Font("Sitka Text", 10.1999989F);
            SetUpButton.Location = new Point(74, 287);
            SetUpButton.Margin = new Padding(3, 4, 3, 4);
            SetUpButton.Name = "SetUpButton";
            SetUpButton.Size = new Size(180, 37);
            SetUpButton.TabIndex = 18;
            SetUpButton.Text = "Встановити";
            SetUpButton.UseVisualStyleBackColor = true;
            SetUpButton.Click += SetUpButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Font = new Font("Sitka Text", 10.1999989F);
            PasswordTextBox.Location = new Point(73, 145);
            PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Type new password";
            PasswordTextBox.Size = new Size(180, 29);
            PasswordTextBox.TabIndex = 17;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            // 
            // LoginTextBox
            // 
            LoginTextBox.Font = new Font("Sitka Text", 10.1999989F);
            LoginTextBox.Location = new Point(74, 87);
            LoginTextBox.Margin = new Padding(3, 4, 3, 4);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.PlaceholderText = "Type new login";
            LoginTextBox.Size = new Size(180, 29);
            LoginTextBox.TabIndex = 16;
            LoginTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // UserSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(347, 399);
            Controls.Add(comboBoxRights);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SetUpButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Margin = new Padding(3, 4, 3, 4);
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