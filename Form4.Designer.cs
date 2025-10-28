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
            usersGridView.Location = new Point(70, 16);
            usersGridView.Margin = new Padding(3, 4, 3, 4);
            usersGridView.Name = "usersGridView";
            usersGridView.RowHeadersWidth = 51;
            usersGridView.Size = new Size(428, 431);
            usersGridView.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Font = new Font("Sitka Text", 10.1999989F);
            btnDeleteUser.Location = new Point(12, 484);
            btnDeleteUser.Margin = new Padding(3, 4, 3, 4);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(224, 48);
            btnDeleteUser.TabIndex = 1;
            btnDeleteUser.Text = "Видалити користувача";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Font = new Font("Sitka Text", 10.1999989F);
            btnEditUser.Location = new Point(305, 484);
            btnEditUser.Margin = new Padding(3, 4, 3, 4);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(224, 48);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "Редагувати користувача";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 584);
            Controls.Add(btnEditUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(usersGridView);
            Margin = new Padding(3, 4, 3, 4);
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