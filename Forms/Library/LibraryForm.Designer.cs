namespace LibraryTeamWinFormApp.Forms.Library
{
    partial class LibraryForm
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
            booksGridView = new DataGridView();
            FindBookByNameTextBox = new TextBox();
            AdminPanelButton = new Button();
            TakeBookButton = new Button();
            ReturnBookButton = new Button();
            AddNewBookButton = new Button();
            DeleteSelectedBook = new Button();
            EditSelectedBookButton = new Button();
            ShowOverdueBooksButton = new Button();
            ShowAllLibraryButton = new Button();
            FindBookByNameButton = new Button();
            FindLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)booksGridView).BeginInit();
            SuspendLayout();
            // 
            // booksGridView
            // 
            booksGridView.AllowUserToAddRows = false;
            booksGridView.AllowUserToDeleteRows = false;
            booksGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksGridView.Location = new Point(10, 112);
            booksGridView.Name = "booksGridView";
            booksGridView.ReadOnly = true;
            booksGridView.RowHeadersWidth = 51;
            booksGridView.RowTemplate.Height = 24;
            booksGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksGridView.Size = new Size(752, 375);
            booksGridView.TabIndex = 0;
            // 
            // FindBookByNameTextBox
            // 
            FindBookByNameTextBox.Location = new Point(10, 38);
            FindBookByNameTextBox.Name = "FindBookByNameTextBox";
            FindBookByNameTextBox.Size = new Size(176, 23);
            FindBookByNameTextBox.TabIndex = 1;
            // 
            // AdminPanelButton
            // 
            AdminPanelButton.Location = new Point(10, 506);
            AdminPanelButton.Name = "AdminPanelButton";
            AdminPanelButton.Size = new Size(105, 38);
            AdminPanelButton.TabIndex = 2;
            AdminPanelButton.Text = "Панель адміна";
            AdminPanelButton.UseVisualStyleBackColor = true;
            AdminPanelButton.Click += AdminPanelButton_Click;
            // 
            // TakeBookButton
            // 
            TakeBookButton.Location = new Point(131, 506);
            TakeBookButton.Name = "TakeBookButton";
            TakeBookButton.Size = new Size(105, 38);
            TakeBookButton.TabIndex = 3;
            TakeBookButton.Text = "Взяти книгу";
            TakeBookButton.UseVisualStyleBackColor = true;
            TakeBookButton.Click += TakeBookButton_Click;
            // 
            // ReturnBookButton
            // 
            ReturnBookButton.Location = new Point(252, 506);
            ReturnBookButton.Name = "ReturnBookButton";
            ReturnBookButton.Size = new Size(105, 38);
            ReturnBookButton.TabIndex = 4;
            ReturnBookButton.Text = "Повернути книгу";
            ReturnBookButton.UseVisualStyleBackColor = true;
            ReturnBookButton.Click += ReturnBookButton_Click;
            // 
            // AddNewBookButton
            // 
            AddNewBookButton.Location = new Point(373, 506);
            AddNewBookButton.Name = "AddNewBookButton";
            AddNewBookButton.Size = new Size(105, 38);
            AddNewBookButton.TabIndex = 5;
            AddNewBookButton.Text = "Додати книгу";
            AddNewBookButton.UseVisualStyleBackColor = true;
            AddNewBookButton.Click += AddNewBookButton_Click;
            // 
            // DeleteSelectedBook
            // 
            DeleteSelectedBook.Location = new Point(494, 506);
            DeleteSelectedBook.Name = "DeleteSelectedBook";
            DeleteSelectedBook.Size = new Size(105, 38);
            DeleteSelectedBook.TabIndex = 6;
            DeleteSelectedBook.Text = "Видалити книгу";
            DeleteSelectedBook.UseVisualStyleBackColor = true;
            DeleteSelectedBook.Click += DeleteSelectedBook_Click;
            // 
            // EditSelectedBookButton
            // 
            EditSelectedBookButton.Location = new Point(614, 506);
            EditSelectedBookButton.Name = "EditSelectedBookButton";
            EditSelectedBookButton.Size = new Size(149, 38);
            EditSelectedBookButton.TabIndex = 7;
            EditSelectedBookButton.Text = "Редагувати книгу";
            EditSelectedBookButton.UseVisualStyleBackColor = true;
            EditSelectedBookButton.Click += EditSelectedBookButton_Click;
            // 
            // ShowOverdueBooksButton
            // 
            ShowOverdueBooksButton.Location = new Point(10, 75);
            ShowOverdueBooksButton.Name = "ShowOverdueBooksButton";
            ShowOverdueBooksButton.Size = new Size(131, 28);
            ShowOverdueBooksButton.TabIndex = 8;
            ShowOverdueBooksButton.Text = "Прострочені книги";
            ShowOverdueBooksButton.UseVisualStyleBackColor = true;
            ShowOverdueBooksButton.Click += ShowOverdueBooksButton_Click;
            // 
            // ShowAllLibraryButton
            // 
            ShowAllLibraryButton.Location = new Point(147, 75);
            ShowAllLibraryButton.Name = "ShowAllLibraryButton";
            ShowAllLibraryButton.Size = new Size(131, 28);
            ShowAllLibraryButton.TabIndex = 9;
            ShowAllLibraryButton.Text = "Вся бібліотека";
            ShowAllLibraryButton.UseVisualStyleBackColor = true;
            ShowAllLibraryButton.Click += ShowAllLibraryButton_Click;
            // 
            // FindBookByNameButton
            // 
            FindBookByNameButton.Location = new Point(191, 38);
            FindBookByNameButton.Name = "FindBookByNameButton";
            FindBookByNameButton.Size = new Size(88, 23);
            FindBookByNameButton.TabIndex = 10;
            FindBookByNameButton.Text = "Пошук";
            FindBookByNameButton.UseVisualStyleBackColor = true;
            FindBookByNameButton.Click += FindBookByNameButton_Click;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Location = new Point(10, 19);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(96, 15);
            FindLabel.TabIndex = 11;
            FindLabel.Text = "Пошук по назві:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 94);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 12;
            label1.Text = "Управління:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 488);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 13;
            label2.Text = "Управління:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 553);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 14;
            label3.Text = "Адміністрування";
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 601);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(FindLabel);
            Controls.Add(FindBookByNameButton);
            Controls.Add(ShowAllLibraryButton);
            Controls.Add(ShowOverdueBooksButton);
            Controls.Add(EditSelectedBookButton);
            Controls.Add(DeleteSelectedBook);
            Controls.Add(AddNewBookButton);
            Controls.Add(ReturnBookButton);
            Controls.Add(TakeBookButton);
            Controls.Add(AdminPanelButton);
            Controls.Add(FindBookByNameTextBox);
            Controls.Add(booksGridView);
            Name = "LibraryForm";
            Text = "Бібліотека";
            ((System.ComponentModel.ISupportInitialize)booksGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}