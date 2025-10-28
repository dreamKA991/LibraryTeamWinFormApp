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
            SetButton.Font = new Font("Sitka Text", 10.1999989F);
            SetButton.Location = new Point(83, 240);
            SetButton.Margin = new Padding(3, 4, 3, 4);
            SetButton.Name = "SetButton";
            SetButton.Size = new Size(123, 36);
            SetButton.TabIndex = 0;
            SetButton.Text = "Встановити";
            SetButton.UseVisualStyleBackColor = true;
            SetButton.Click += SetButton_Click;
            // 
            // TitleBookTextBox
            // 
            TitleBookTextBox.Font = new Font("Sitka Text", 10.1999989F);
            TitleBookTextBox.Location = new Point(38, 75);
            TitleBookTextBox.Margin = new Padding(3, 4, 3, 4);
            TitleBookTextBox.Name = "TitleBookTextBox";
            TitleBookTextBox.Size = new Size(213, 29);
            TitleBookTextBox.TabIndex = 1;
            // 
            // ISBNBookTextBox
            // 
            ISBNBookTextBox.Font = new Font("Sitka Text", 10.1999989F);
            ISBNBookTextBox.Location = new Point(38, 175);
            ISBNBookTextBox.Margin = new Padding(3, 4, 3, 4);
            ISBNBookTextBox.Name = "ISBNBookTextBox";
            ISBNBookTextBox.Size = new Size(213, 29);
            ISBNBookTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F);
            label1.Location = new Point(98, 41);
            label1.Name = "label1";
            label1.Size = new Size(114, 24);
            label1.TabIndex = 3;
            label1.Text = "Назва книги";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(102, 139);
            label2.Name = "label2";
            label2.Size = new Size(107, 24);
            label2.TabIndex = 4;
            label2.Text = "ISBN номер";
            // 
            // EditBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 336);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ISBNBookTextBox);
            Controls.Add(TitleBookTextBox);
            Controls.Add(SetButton);
            Margin = new Padding(3, 4, 3, 4);
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