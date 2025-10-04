namespace LibraryTeamWinFormApp
{
    partial class StartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DBStatusLabel = new Label();
            LoginTextBox = new TextBox();
            label2 = new Label();
            PasswordTextBox = new TextBox();
            SignInButton = new Button();
            label3 = new Label();
            label4 = new Label();
            AddUserButton = new Button();
            SuspendLayout();
            // 
            // DBStatusLabel
            // 
            DBStatusLabel.AutoSize = true;
            DBStatusLabel.Location = new Point(155, 9);
            DBStatusLabel.Name = "DBStatusLabel";
            DBStatusLabel.Size = new Size(38, 15);
            DBStatusLabel.TabIndex = 0;
            DBStatusLabel.Text = "label1";
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(65, 63);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(158, 23);
            LoginTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 9);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 2;
            label2.Text = "DataBase Status:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(64, 107);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(158, 23);
            PasswordTextBox.TabIndex = 3;
            // 
            // SignInButton
            // 
            SignInButton.Location = new Point(64, 151);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(158, 47);
            SignInButton.TabIndex = 4;
            SignInButton.Text = "SIGN IN";
            SignInButton.UseVisualStyleBackColor = true;
            SignInButton.Click += onRegisterButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 45);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "LOGIN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 89);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 6;
            label4.Text = "PASSWORD";
            // 
            // AddUserButton
            // 
            AddUserButton.Location = new Point(101, 204);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(75, 23);
            AddUserButton.TabIndex = 7;
            AddUserButton.Text = "ADD USER";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 251);
            Controls.Add(AddUserButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SignInButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(label2);
            Controls.Add(LoginTextBox);
            Controls.Add(DBStatusLabel);
            Name = "StartForm";
            Text = "Auntheficate";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DBStatusLabel;
        private TextBox LoginTextBox;
        private Label label2;
        private TextBox PasswordTextBox;
        private Button SignInButton;
        private Label label3;
        private Label label4;
        private Button AddUserButton;
    }
}
