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
            TakeBookButton.Font = new Font("Sitka Text", 10.1999989F);
            TakeBookButton.Location = new Point(86, 229);
            TakeBookButton.Margin = new Padding(3, 4, 3, 4);
            TakeBookButton.Name = "TakeBookButton";
            TakeBookButton.Size = new Size(193, 45);
            TakeBookButton.TabIndex = 0;
            TakeBookButton.Text = "Взяти книгу";
            TakeBookButton.UseVisualStyleBackColor = true;
            TakeBookButton.Click += TakeBookButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Text", 10.1999989F);
            label1.Location = new Point(51, 36);
            label1.Name = "label1";
            label1.Size = new Size(307, 24);
            label1.TabIndex = 2;
            label1.Text = "Введіть ідентифікатор користувача";
            // 
            // returnDatePicker
            // 
            returnDatePicker.Font = new Font("Sitka Text", 10.1999989F);
            returnDatePicker.Location = new Point(78, 176);
            returnDatePicker.Margin = new Padding(3, 4, 3, 4);
            returnDatePicker.MinDate = new DateTime(2025, 10, 5, 0, 0, 0, 0);
            returnDatePicker.Name = "returnDatePicker";
            returnDatePicker.Size = new Size(228, 29);
            returnDatePicker.TabIndex = 3;
            returnDatePicker.ValueChanged += returnDatePicker_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Text", 10.1999989F);
            label2.Location = new Point(115, 137);
            label2.Name = "label2";
            label2.Size = new Size(155, 24);
            label2.TabIndex = 4;
            label2.Text = "Дата повернення";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Sitka Text", 10.1999989F);
            numericUpDown1.Location = new Point(122, 78);
            numericUpDown1.Margin = new Padding(3, 5, 3, 5);
            numericUpDown1.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(157, 29);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // TakeBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 303);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(returnDatePicker);
            Controls.Add(label1);
            Controls.Add(TakeBookButton);
            Margin = new Padding(3, 4, 3, 4);
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