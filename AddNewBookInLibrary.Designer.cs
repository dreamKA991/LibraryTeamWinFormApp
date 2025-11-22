namespace LibraryTeamWinFormApp
{
    public partial class AddNewBookInLibrary
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
            TitleBookTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ISBNBookTextBox = new TextBox();
            AddNewBookButton = new Button();
            SuspendLayout();
            // 
            // TitleBookTextBox
            // 
            TitleBookTextBox.Font = new Font("Sitka Text", 10.1999989F);
            TitleBookTextBox.Location = new Point(40, 63);
            TitleBookTextBox.Margin = new Padding(3, 4, 3, 4);
            TitleBookTextBox.Name = "TitleBookTextBox";
            TitleBookTextBox.Size = new Size(157, 29);
            TitleBookTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F);
            label1.Location = new Point(69, 29);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 1;
            label1.Text = "Назва книги";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(81, 117);
            label2.Name = "label2";
            label2.Size = new Size(107, 24);
            label2.TabIndex = 3;
            label2.Text = "ISBN номер";
            // 
            // ISBNBookTextBox
            // 
            ISBNBookTextBox.Font = new Font("Sitka Text", 10.1999989F);
            ISBNBookTextBox.Location = new Point(40, 157);
            ISBNBookTextBox.Margin = new Padding(3, 4, 3, 4);
            ISBNBookTextBox.Name = "ISBNBookTextBox";
            ISBNBookTextBox.Size = new Size(157, 29);
            ISBNBookTextBox.TabIndex = 2;
            // 
            // AddNewBookButton
            // 
            AddNewBookButton.Font = new Font("Sitka Text", 10.1999989F);
            AddNewBookButton.Location = new Point(40, 220);
            AddNewBookButton.Margin = new Padding(3, 4, 3, 4);
            AddNewBookButton.Name = "AddNewBookButton";
            AddNewBookButton.Size = new Size(180, 37);
            AddNewBookButton.TabIndex = 4;
            AddNewBookButton.Text = "Додати нову книгу";
            AddNewBookButton.UseVisualStyleBackColor = true;
            AddNewBookButton.Click += AddNewBookButton_Click;
            // 
            // AddNewBookInLibrary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 313);
            Controls.Add(AddNewBookButton);
            Controls.Add(label2);
            Controls.Add(ISBNBookTextBox);
            Controls.Add(label1);
            Controls.Add(TitleBookTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddNewBookInLibrary";
            Text = "AddNewBookInLibrary";
            Load += AddNewBookInLibrary_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TitleBookTextBox;
        private Label label1;
        private Label label2;
        public TextBox ISBNBookTextBox;
        private Button AddNewBookButton;
    }
}