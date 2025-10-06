namespace LibraryTeamWinFormApp
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
            ((System.ComponentModel.ISupportInitialize)booksGridView).BeginInit();
            SuspendLayout();
            // 
            // AdminPanelButton
            // 
            AdminPanelButton.Location = new Point(636, 365);
            AdminPanelButton.Name = "AdminPanelButton";
            AdminPanelButton.Size = new Size(136, 54);
            AdminPanelButton.TabIndex = 0;
            AdminPanelButton.Text = "Open AdminPanelButton";
            AdminPanelButton.UseVisualStyleBackColor = true;
            AdminPanelButton.Click += AdminPanelButton_Click;
            // 
            // booksGridView
            // 
            booksGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksGridView.Location = new Point(31, 12);
            booksGridView.Name = "booksGridView";
            booksGridView.Size = new Size(587, 323);
            booksGridView.TabIndex = 1;
            // 
            // FindBookByNameTextBox
            // 
            FindBookByNameTextBox.Location = new Point(88, 391);
            FindBookByNameTextBox.Name = "FindBookByNameTextBox";
            FindBookByNameTextBox.Size = new Size(259, 23);
            FindBookByNameTextBox.TabIndex = 3;
            // 
            // FindBookByNameButton
            // 
            FindBookByNameButton.Location = new Point(391, 384);
            FindBookByNameButton.Name = "FindBookByNameButton";
            FindBookByNameButton.Size = new Size(94, 35);
            FindBookByNameButton.TabIndex = 4;
            FindBookByNameButton.Text = "Find";
            FindBookByNameButton.UseVisualStyleBackColor = true;
            FindBookByNameButton.Click += FindBookByNameButton_Click;
            // 
            // FindLabel
            // 
            FindLabel.AutoSize = true;
            FindLabel.Location = new Point(156, 354);
            FindLabel.Name = "FindLabel";
            FindLabel.Size = new Size(109, 15);
            FindLabel.TabIndex = 5;
            FindLabel.Text = "Find book by name";
            // 
            // TakeBookButton
            // 
            TakeBookButton.Location = new Point(636, 41);
            TakeBookButton.Name = "TakeBookButton";
            TakeBookButton.Size = new Size(136, 46);
            TakeBookButton.TabIndex = 6;
            TakeBookButton.Text = "TakeBookButton";
            TakeBookButton.UseVisualStyleBackColor = true;
            TakeBookButton.Click += TakeBookButton_Click;
            // 
            // ReturnBookButton
            // 
            ReturnBookButton.Location = new Point(636, 93);
            ReturnBookButton.Name = "ReturnBookButton";
            ReturnBookButton.Size = new Size(136, 47);
            ReturnBookButton.TabIndex = 7;
            ReturnBookButton.Text = "ReturnBookButton";
            ReturnBookButton.UseVisualStyleBackColor = true;
            ReturnBookButton.Click += ReturnBookButton_Click;
            // 
            // AddNewBookButton
            // 
            AddNewBookButton.Location = new Point(636, 181);
            AddNewBookButton.Name = "AddNewBookButton";
            AddNewBookButton.Size = new Size(136, 47);
            AddNewBookButton.TabIndex = 8;
            AddNewBookButton.Text = "AddNewBookButton";
            AddNewBookButton.UseVisualStyleBackColor = true;
            AddNewBookButton.Click += AddNewBookButton_Click;
            // 
            // DeleteSelectedBook
            // 
            DeleteSelectedBook.Location = new Point(636, 287);
            DeleteSelectedBook.Name = "DeleteSelectedBook";
            DeleteSelectedBook.Size = new Size(136, 47);
            DeleteSelectedBook.TabIndex = 9;
            DeleteSelectedBook.Text = "DeleteSelectedBook";
            DeleteSelectedBook.UseVisualStyleBackColor = true;
            DeleteSelectedBook.Click += DeleteSelectedBook_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(654, 22);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 10;
            label1.Text = "User book controls";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(641, 163);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 11;
            label2.Text = "Library book controls";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(651, 347);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 12;
            label3.Text = "User's admin controls";
            // 
            // EditSelectedBookButton
            // 
            EditSelectedBookButton.Location = new Point(636, 234);
            EditSelectedBookButton.Name = "EditSelectedBookButton";
            EditSelectedBookButton.Size = new Size(136, 47);
            EditSelectedBookButton.TabIndex = 13;
            EditSelectedBookButton.Text = "EditSelectedBookButton";
            EditSelectedBookButton.UseVisualStyleBackColor = true;
            EditSelectedBookButton.Click += EditSelectedBookButton_Click;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 441);
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
            Load += Form3_Load;
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
    }
}