namespace LibraryTeamWinFormApp
{
    partial class EditBookForm
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
            SetButton = new Button();
            TitleBookTextBox = new TextBox();
            ISBNBookTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // SetButton
            // 
            SetButton.Location = new Point(73, 180);
            SetButton.Name = "SetButton";
            SetButton.Size = new Size(98, 39);
            SetButton.TabIndex = 0;
            SetButton.Text = "Set";
            SetButton.UseVisualStyleBackColor = true;
            SetButton.Click += SetButton_Click;
            // 
            // TitleBookTextBox
            // 
            TitleBookTextBox.Location = new Point(33, 56);
            TitleBookTextBox.Name = "TitleBookTextBox";
            TitleBookTextBox.Size = new Size(187, 23);
            TitleBookTextBox.TabIndex = 1;
            // 
            // ISBNBookTextBox
            // 
            ISBNBookTextBox.Location = new Point(33, 131);
            ISBNBookTextBox.Name = "ISBNBookTextBox";
            ISBNBookTextBox.Size = new Size(187, 23);
            ISBNBookTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 31);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 3;
            label1.Text = "The title of book";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 104);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 4;
            label2.Text = "ISBN number";
            // 
            // EditBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 252);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ISBNBookTextBox);
            Controls.Add(TitleBookTextBox);
            Controls.Add(SetButton);
            Name = "EditBookForm";
            Text = "EditBookForm";
            Load += EditBookForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SetButton;
        private TextBox TitleBookTextBox;
        private TextBox ISBNBookTextBox;
        private Label label1;
        private Label label2;
    }
}