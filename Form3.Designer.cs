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
            AdminPanelButton.Location = new Point(699, 381);
            AdminPanelButton.Margin = new Padding(3, 2, 3, 2);
            AdminPanelButton.Name = "AdminPanelButton";
            AdminPanelButton.Size = new Size(245, 34);
            AdminPanelButton.TabIndex = 14;
            AdminPanelButton.Text = "Відкрити панель адміністратора";
            AdminPanelButton.UseVisualStyleBackColor = true;
            AdminPanelButton.Visible = false;
            AdminPanelButton.Click += AdminPanelButton_Click;
            // 
            // booksGridView
            // 
            booksGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksGridView.Location = new Point(26, 11);
            booksGridView.Margin = new Padding(3, 2, 3, 2);
            booksGridView.Name = "booksGridView";
            booksGridView.RowHeadersWidth = 51;
            booksGridView.Size = new Size(612, 322);
            booksGridView.TabIndex = 13;
            // 
            // FindBookByNameTextBox
            // 
            FindBookByNameTextBox.Font = new Font("Sitka Text", 10.2F);
            FindBookByNameTextBox.Location = new Point(88, 390);
            FindBookByNameTextBox.Margin = new Padding(3, 2, 3, 2);
            FindBookByNameTextBox.Name = "FindBookByNameTextBox";
            FindBookByNameTextBox.Size = new Size(263, 25);
            FindBookByNameTextBox.TabIndex = 12;
            // 
            // FindBookByNameButton
            // 
            FindBookByNameButton.Font = new Font("Sitka Text", 10.2F);
            FindBookByNameButton.Location = new Point(368, 384);
            FindBookByNameButton.Margin = new Padding(3, 2, 3, 2);
            FindBookByNameButton.Name = "FindBookByNameButton";
            FindBookByNameButton.Size = new Size(96, 34);
            FindBookByNameButton.TabIndex = 11;
            FindBookByNameButton.Text = "Знайти";
            FindBookByNameButton.UseVisualStyleBackColor = true;
            FindBookByNameButton.Click += FindBookByNameButton_Click;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Font = new Font("Sitka Text", 10.2F);
            FindLabel.Location = new Point(158, 360);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(180, 20);
            FindLabel.TabIndex = 10;
            FindLabel.Text = "Знайти книгу за назвою";
            // 
            // TakeBookButton
            // 
            TakeBookButton.Font = new Font("Sitka Text", 10.2F);
            TakeBookButton.Location = new Point(656, 38);
            TakeBookButton.Margin = new Padding(3, 2, 3, 2);
            TakeBookButton.Name = "TakeBookButton";
            TakeBookButton.Size = new Size(158, 45);
            TakeBookButton.TabIndex = 9;
            TakeBookButton.Text = "Взяти книгу";
            TakeBookButton.Visible = false;
            TakeBookButton.Click += TakeBookButton_Click;
            // 
            // ReturnBookButton
            // 
            ReturnBookButton.Font = new Font("Sitka Text", 10.2F);
            ReturnBookButton.Location = new Point(831, 38);
            ReturnBookButton.Margin = new Padding(3, 2, 3, 2);
            ReturnBookButton.Name = "ReturnBookButton";
            ReturnBookButton.Size = new Size(158, 45);
            ReturnBookButton.TabIndex = 8;
            ReturnBookButton.Text = "Повернути книгу";
            ReturnBookButton.Visible = false;
            ReturnBookButton.Click += ReturnBookButton_Click;
            // 
            // AddNewBookButton
            // 
            AddNewBookButton.Font = new Font("Sitka Text", 10.2F);
            AddNewBookButton.Location = new Point(656, 142);
            AddNewBookButton.Margin = new Padding(3, 2, 3, 2);
            AddNewBookButton.Name = "AddNewBookButton";
            AddNewBookButton.Size = new Size(158, 58);
            AddNewBookButton.TabIndex = 7;
            AddNewBookButton.Text = "Додати нову книгу";
            AddNewBookButton.Visible = false;
            AddNewBookButton.Click += AddNewBookButton_Click;
            // 
            // DeleteSelectedBook
            // 
            DeleteSelectedBook.Font = new Font("Sitka Text", 10.2F);
            DeleteSelectedBook.Location = new Point(656, 204);
            DeleteSelectedBook.Margin = new Padding(3, 2, 3, 2);
            DeleteSelectedBook.Name = "DeleteSelectedBook";
            DeleteSelectedBook.Size = new Size(158, 56);
            DeleteSelectedBook.TabIndex = 6;
            DeleteSelectedBook.Text = "Видалити вибрану книгу";
            DeleteSelectedBook.Visible = false;
            DeleteSelectedBook.Click += DeleteSelectedBook_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.2F);
            label1.Location = new Point(718, 16);
            label1.Name = "label1";
            label1.Size = new Size(239, 20);
            label1.TabIndex = 5;
            label1.Text = "Керування книгами користувача";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.2F);
            label2.Location = new Point(718, 120);
            label2.Name = "label2";
            label2.Size = new Size(226, 20);
            label2.TabIndex = 4;
            label2.Text = "Керування книгами бібліотеки";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Text", 10.2F);
            label3.Location = new Point(718, 359);
            label3.Name = "label3";
            label3.Size = new Size(194, 20);
            label3.TabIndex = 3;
            label3.Text = "Керування користувачами";
            label3.Visible = false;
            // 
            // EditSelectedBookButton
            // 
            EditSelectedBookButton.Font = new Font("Sitka Text", 10.2F);
            EditSelectedBookButton.Location = new Point(831, 142);
            EditSelectedBookButton.Margin = new Padding(3, 2, 3, 2);
            EditSelectedBookButton.Name = "EditSelectedBookButton";
            EditSelectedBookButton.Size = new Size(158, 58);
            EditSelectedBookButton.TabIndex = 2;
            EditSelectedBookButton.Text = "Редагувати вибрану книгу";
            EditSelectedBookButton.Visible = false;
            EditSelectedBookButton.Click += EditSelectedBookButton_Click;
            // 
            // ShowOverdueBooksButton
            // 
            ShowOverdueBooksButton.Font = new Font("Sitka Text", 10.2F);
            ShowOverdueBooksButton.Location = new Point(831, 204);
            ShowOverdueBooksButton.Margin = new Padding(3, 2, 3, 2);
            ShowOverdueBooksButton.Name = "ShowOverdueBooksButton";
            ShowOverdueBooksButton.Size = new Size(158, 56);
            ShowOverdueBooksButton.TabIndex = 1;
            ShowOverdueBooksButton.Text = "Показати прострочені книги";
            ShowOverdueBooksButton.Visible = false;
            ShowOverdueBooksButton.Click += ShowOverdueBooksButton_Click;
            // 
            // ShowAllLibraryButton
            // 
            ShowAllLibraryButton.Font = new Font("Sitka Text", 10.2F);
            ShowAllLibraryButton.Location = new Point(744, 264);
            ShowAllLibraryButton.Margin = new Padding(3, 2, 3, 2);
            ShowAllLibraryButton.Name = "ShowAllLibraryButton";
            ShowAllLibraryButton.Size = new Size(158, 45);
            ShowAllLibraryButton.TabIndex = 0;
            ShowAllLibraryButton.Text = "Показати всі книги";
            ShowAllLibraryButton.Visible = false;
            ShowAllLibraryButton.Click += ShowAllLibraryButton_Click;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 435);
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
            Margin = new Padding(3, 2, 3, 2);
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
