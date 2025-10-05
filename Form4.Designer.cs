namespace LibraryTeamWinFormApp
{
    partial class AdminPanel
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
            usersGridView = new DataGridView();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            ((System.ComponentModel.ISupportInitialize)usersGridView).BeginInit();
            SuspendLayout();
            // 
            // usersGridView
            // 
            usersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGridView.Location = new Point(61, 12);
            usersGridView.Name = "usersGridView";
            usersGridView.Size = new Size(542, 323);
            usersGridView.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(378, 370);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(148, 36);
            btnDeleteUser.TabIndex = 1;
            btnDeleteUser.Text = "btnDeleteUser";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(146, 370);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(148, 36);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "btnEditUser";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 438);
            Controls.Add(btnEditUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(usersGridView);
            Name = "AdminPanel";
            Text = "Admin Panel";
            Load += AdminPanel_Load;
            ((System.ComponentModel.ISupportInitialize)usersGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView usersGridView;
        private Button btnDeleteUser;
        private Button btnEditUser;
    }
}