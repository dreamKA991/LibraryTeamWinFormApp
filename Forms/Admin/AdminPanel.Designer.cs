namespace LibraryTeamWinFormApp.Forms.Admin
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
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Location = new System.Drawing.Point(12, 50);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.ReadOnly = true;
            this.usersGridView.RowHeadersWidth = 51;
            this.usersGridView.RowTemplate.Height = 24;
            this.usersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGridView.Size = new System.Drawing.Size(600, 300);
            this.usersGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Управління користувачами";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(12, 370);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Видалити користувача";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(180, 370);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(150, 40);
            this.btnEditUser.TabIndex = 3;
            this.btnEditUser.Text = "Редагувати користувача";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(348, 370);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(150, 40);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Оновити";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 425);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersGridView);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель адміністратора";
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}