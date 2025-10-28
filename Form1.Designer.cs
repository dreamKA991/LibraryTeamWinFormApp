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
            DBStatusLabel.Font = new Font("Sitka Text", 10.1999989F);
            DBStatusLabel.Location = new Point(140, 32);
            DBStatusLabel.Name = "DBStatusLabel";
            DBStatusLabel.Size = new Size(56, 24);
            DBStatusLabel.TabIndex = 0;
            DBStatusLabel.Text = "label1";
            // 
            // LoginTextBox
            // 
            LoginTextBox.Location = new Point(74, 84);
            LoginTextBox.Margin = new Padding(3, 4, 3, 4);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new Size(180, 27);
            LoginTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(105, 12);
            label2.Name = "label2";
            label2.Size = new Size(143, 24);
            label2.TabIndex = 2;
            label2.Text = "DataBase Status:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(73, 143);
            PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(180, 27);
            PasswordTextBox.TabIndex = 3;
            //                                                                  
            // SignInButton
            // 
            SignInButton.Font = new Font("Sitka Text", 10.1999989F);
            SignInButton.Location = new Point(73, 201);
            SignInButton.Margin = new Padding(3, 4, 3, 4);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(181, 31);
            SignInButton.TabIndex = 4;
            SignInButton.Text = "SIGN IN";
            SignInButton.UseVisualStyleBackColor = true;
            SignInButton.Click += onRegisterButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.1999989F);
            label3.Location = new Point(139, 60);
            label3.Name = "label3";
            label3.Size = new Size(63, 24);
            label3.TabIndex = 5;
            label3.Text = "LOGIN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Text", 10.1999989F);
            label4.Location = new Point(123, 119);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 6;
            label4.Text = "PASSWORD";
            // 
            // AddUserButton
            // 
            AddUserButton.Font = new Font("Sitka Text", 10.1999989F);
            AddUserButton.Location = new Point(75, 240);
            AddUserButton.Margin = new Padding(3, 4, 3, 4);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(179, 31);
            AddUserButton.TabIndex = 7;
            AddUserButton.Text = "ADD USER";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 335);
            Controls.Add(AddUserButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SignInButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(label2);
            Controls.Add(LoginTextBox);
            Controls.Add(DBStatusLabel);
            Margin = new Padding(3, 4, 3, 4);
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
