namespace LibraryTeamWinFormApp
{
    partial class TakeBookForm
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
            TakeBookButton = new Button();
            label1 = new Label();
            returnDatePicker = new DateTimePicker();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // TakeBookButton
            // 
            TakeBookButton.Location = new Point(128, 125);
            TakeBookButton.Name = "TakeBookButton";
            TakeBookButton.Size = new Size(169, 34);
            TakeBookButton.TabIndex = 0;
            TakeBookButton.Text = "TakeBookButton";
            TakeBookButton.UseVisualStyleBackColor = true;
            TakeBookButton.Click += TakeBookButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 27);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 2;
            label1.Text = "Type user's id";
            // 
            // returnDatePicker
            // 
            returnDatePicker.Location = new Point(197, 58);
            returnDatePicker.MinDate = new DateTime(2025, 10, 5, 0, 0, 0, 0);
            returnDatePicker.Name = "returnDatePicker";
            returnDatePicker.Size = new Size(200, 23);
            returnDatePicker.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(265, 27);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 4;
            label2.Text = "Return date";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(31, 58);
            numericUpDown1.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TakeBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 179);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(returnDatePicker);
            Controls.Add(label1);
            Controls.Add(TakeBookButton);
            Name = "TakeBookForm";
            Text = "TakeBookForm";
            Load += TakeBookForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TakeBookButton;
        private Label label1;
        private DateTimePicker returnDatePicker;
        private Label label2;
        private NumericUpDown numericUpDown1;
    }
}