namespace LibraryTeamWinFormApp
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
            TitleBookTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ISBNBookTextBox = new TextBox();
            AddNewBookButton = new Button();
            SuspendLayout();
            // 
            // TitleBookTextBox
            // 
            TitleBookTextBox.Location = new Point(35, 47);
            TitleBookTextBox.Name = "TitleBookTextBox";
            TitleBookTextBox.Size = new Size(138, 23);
            TitleBookTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 22);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "The title of book";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 88);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "ISBN number";
            // 
            // ISBNBookTextBox
            // 
            ISBNBookTextBox.Location = new Point(35, 118);
            ISBNBookTextBox.Name = "ISBNBookTextBox";
            ISBNBookTextBox.Size = new Size(138, 23);
            ISBNBookTextBox.TabIndex = 2;
            // 
            // AddNewBookButton
            // 
            AddNewBookButton.Location = new Point(35, 165);
            AddNewBookButton.Name = "AddNewBookButton";
            AddNewBookButton.Size = new Size(138, 51);
            AddNewBookButton.TabIndex = 4;
            AddNewBookButton.Text = "AddNewBookButton";
            AddNewBookButton.UseVisualStyleBackColor = true;
            AddNewBookButton.Click += AddNewBookButton_Click;
            // 
            // AddNewBookInLibrary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(219, 235);
            Controls.Add(AddNewBookButton);
            Controls.Add(label2);
            Controls.Add(ISBNBookTextBox);
            Controls.Add(label1);
            Controls.Add(TitleBookTextBox);
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
        private TextBox ISBNBookTextBox;
        private Button AddNewBookButton;
    }
}