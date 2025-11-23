namespace LibraryTeamWinFormApp.Forms.Library
{
    partial class AddNewBookInLibrary
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleBookTextBox = new System.Windows.Forms.TextBox();
            this.ISBNBookTextBox = new System.Windows.Forms.TextBox();
            this.AddNewBookButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(50, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва книги:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(50, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ISBN:";
            // 
            // TitleBookTextBox
            // 
            this.TitleBookTextBox.Location = new System.Drawing.Point(180, 30);
            this.TitleBookTextBox.Name = "TitleBookTextBox";
            this.TitleBookTextBox.Size = new System.Drawing.Size(250, 22);
            this.TitleBookTextBox.TabIndex = 2;
            // 
            // ISBNBookTextBox
            // 
            this.ISBNBookTextBox.Location = new System.Drawing.Point(180, 80);
            this.ISBNBookTextBox.Name = "ISBNBookTextBox";
            this.ISBNBookTextBox.Size = new System.Drawing.Size(250, 22);
            this.ISBNBookTextBox.TabIndex = 3;
            // 
            // AddNewBookButton
            // 
            this.AddNewBookButton.Location = new System.Drawing.Point(100, 130);
            this.AddNewBookButton.Name = "AddNewBookButton";
            this.AddNewBookButton.Size = new System.Drawing.Size(150, 40);
            this.AddNewBookButton.TabIndex = 4;
            this.AddNewBookButton.Text = "Додати книгу";
            this.AddNewBookButton.UseVisualStyleBackColor = true;
            this.AddNewBookButton.Click += new System.EventHandler(this.AddNewBookButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(260, 130);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(150, 40);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Скасувати";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddNewBookInLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddNewBookButton);
            this.Controls.Add(this.ISBNBookTextBox);
            this.Controls.Add(this.TitleBookTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddNewBookInLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Додати нову книгу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}