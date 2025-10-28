namespace LibraryTeamWinFormApp
{
    partial class LibraryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            AdminPanelButton = new Button();
            booksGridView = new DataGridView();
            FindBookByNameTextBox = new TextBox();
            FindBookByNameButton = new Button();
            FindLabel = new Label();
            TakeBookButton = new Button();
            ReturnBookButton = new Button();
            AddNewBookButton = new Button();
            DeleteSelectedBook = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            EditSelectedBookButton = new Button();
            ShowOverdueBooksButton = new Button();
            ShowAllLibraryButton = new Button();
            ((System.ComponentModel.ISupportInitialize)booksGridView).BeginInit();
            SuspendLayout();
            // 
            // AdminPanelButton
            // 
            AdminPanelButton.Font = new Font("Sitka Text", 10.2F);
            AdminPanelButton.Location = new Point(821, 513);
            AdminPanelButton.Name = "AdminPanelButton";
            AdminPanelButton.Size = new Size(280, 45);
            AdminPanelButton.TabIndex = 14;
            AdminPanelButton.Text = "Відкрити панель адміністратора";
            AdminPanelButton.UseVisualStyleBackColor = true;
            AdminPanelButton.Click += AdminPanelButton_Click;
            // 
            // booksGridView
            // 
            booksGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksGridView.Location = new Point(30, 15);
            booksGridView.Name = "booksGridView";
            booksGridView.RowHeadersWidth = 51;
            booksGridView.Size = new Size(700, 430);
            booksGridView.TabIndex = 13;
            // 
            // FindBookByNameTextBox
            // 
            FindBookByNameTextBox.Font = new Font("Sitka Text", 10.2F);
            FindBookByNameTextBox.Location = new Point(100, 520);
            FindBookByNameTextBox.Name = "FindBookByNameTextBox";
            FindBookByNameTextBox.Size = new Size(300, 29);
            FindBookByNameTextBox.TabIndex = 12;
            // 
            // FindBookByNameButton
            // 
            FindBookByNameButton.Font = new Font("Sitka Text", 10.2F);
            FindBookByNameButton.Location = new Point(420, 512);
            FindBookByNameButton.Name = "FindBookByNameButton";
            FindBookByNameButton.Size = new Size(110, 45);
            FindBookByNameButton.TabIndex = 11;
            FindBookByNameButton.Text = "Знайти";
            FindBookByNameButton.UseVisualStyleBackColor = true;
            FindBookByNameButton.Click += FindBookByNameButton_Click;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Font = new Font("Sitka Text", 10.2F);
            FindLabel.Location = new Point(180, 480);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(212, 24);
            FindLabel.TabIndex = 10;
            FindLabel.Text = "Знайти книгу за назвою";
            // 
            // TakeBookButton
            // 
            TakeBookButton.Font = new Font("Sitka Text", 10.2F);
            TakeBookButton.Location = new Point(750, 50);
            TakeBookButton.Name = "TakeBookButton";
            TakeBookButton.Size = new Size(180, 60);
            TakeBookButton.TabIndex = 9;
            TakeBookButton.Text = "Взяти книгу";
            TakeBookButton.Click += TakeBookButton_Click;
            // 
            // ReturnBookButton
            // 
            ReturnBookButton.Font = new Font("Sitka Text", 10.2F);
            ReturnBookButton.Location = new Point(950, 50);
            ReturnBookButton.Name = "ReturnBookButton";
            ReturnBookButton.Size = new Size(180, 60);
            ReturnBookButton.TabIndex = 8;
            ReturnBookButton.Text = "Повернути книгу";
            ReturnBookButton.Click += ReturnBookButton_Click;
            // 
            // AddNewBookButton
            // 
            AddNewBookButton.Font = new Font("Sitka Text", 10.2F);
            AddNewBookButton.Location = new Point(750, 190);
            AddNewBookButton.Name = "AddNewBookButton";
            AddNewBookButton.Size = new Size(180, 60);
            AddNewBookButton.TabIndex = 7;
            AddNewBookButton.Text = "Додати нову книгу";
            AddNewBookButton.Click += AddNewBookButton_Click;
            // 
            // DeleteSelectedBook
            // 
            DeleteSelectedBook.Font = new Font("Sitka Text", 10.2F);
            DeleteSelectedBook.Location = new Point(750, 280);
            DeleteSelectedBook.Name = "DeleteSelectedBook";
            DeleteSelectedBook.Size = new Size(180, 60);
            DeleteSelectedBook.TabIndex = 6;
            DeleteSelectedBook.Text = "Видалити вибрану книгу";
            DeleteSelectedBook.Click += DeleteSelectedBook_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.2F);
            label1.Location = new Point(780, 20);
            label1.Name = "label1";
            label1.Size = new Size(285, 24);
            label1.TabIndex = 5;
            label1.Text = "Керування книгами користувача";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.2F);
            label2.Location = new Point(780, 160);
            label2.Name = "label2";
            label2.Size = new Size(270, 24);
            label2.TabIndex = 4;
            label2.Text = "Керування книгами бібліотеки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.2F);
            label3.Location = new Point(780, 450);
            label3.Name = "label3";
            label3.Size = new Size(340, 24);
            label3.TabIndex = 3;
            label3.Text = "Керування адміністратора користувача";
            // 
            // EditSelectedBookButton
            // 
            EditSelectedBookButton.Font = new Font("Sitka Text", 10.2F);
            EditSelectedBookButton.Location = new Point(950, 190);
            EditSelectedBookButton.Name = "EditSelectedBookButton";
            EditSelectedBookButton.Size = new Size(180, 60);
            EditSelectedBookButton.TabIndex = 2;
            EditSelectedBookButton.Text = "Редагувати вибрану книгу";
            EditSelectedBookButton.Click += EditSelectedBookButton_Click;
            // 
            // ShowOverdueBooksButton
            // 
            ShowOverdueBooksButton.Font = new Font("Sitka Text", 10.2F);
            ShowOverdueBooksButton.Location = new Point(950, 280);
            ShowOverdueBooksButton.Name = "ShowOverdueBooksButton";
            ShowOverdueBooksButton.Size = new Size(180, 60);
            ShowOverdueBooksButton.TabIndex = 1;
            ShowOverdueBooksButton.Text = "Показати прострочені книги";
            ShowOverdueBooksButton.Click += ShowOverdueBooksButton_Click;
            // 
            // ShowAllLibraryButton
            // 
            ShowAllLibraryButton.Font = new Font("Sitka Text", 10.2F);
            ShowAllLibraryButton.Location = new Point(850, 360);
            ShowAllLibraryButton.Name = "ShowAllLibraryButton";
            ShowAllLibraryButton.Size = new Size(180, 60);
            ShowAllLibraryButton.TabIndex = 0;
            ShowAllLibraryButton.Text = "Показати всі книги";
            ShowAllLibraryButton.Click += ShowAllLibraryButton_Click;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 580);
            Controls.Add(ShowAllLibraryButton);
            Controls.Add(ShowOverdueBooksButton);
            Controls.Add(EditSelectedBookButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DeleteSelectedBook);
            Controls.Add(AddNewBookButton);
            Controls.Add(ReturnBookButton);
            Controls.Add(TakeBookButton);
            Controls.Add(FindLabel);
            Controls.Add(FindBookByNameButton);
            Controls.Add(FindBookByNameTextBox);
            Controls.Add(booksGridView);
            Controls.Add(AdminPanelButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LibraryForm";
            Text = "LibraryForm";
            Load += LibraryForm_Load;
            ((System.ComponentModel.ISupportInitialize)booksGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AdminPanelButton;
        private DataGridView booksGridView;
        private TextBox FindBookByNameTextBox;
        private Button FindBookByNameButton;
        private Label FindLabel;
        private Button TakeBookButton;
        private Button ReturnBookButton;
        private Button AddNewBookButton;
        private Button DeleteSelectedBook;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button EditSelectedBookButton;
        private Button ShowOverdueBooksButton;
        private Button ShowAllLibraryButton;
    }
}
