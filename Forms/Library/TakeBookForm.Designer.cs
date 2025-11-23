namespace LibraryTeamWinFormApp.Forms.Library
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
            this.TakeBookButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.returnDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // TakeBookButton
            // 
            this.TakeBookButton.Location = new System.Drawing.Point(150, 180);
            this.TakeBookButton.Name = "TakeBookButton";
            this.TakeBookButton.Size = new System.Drawing.Size(200, 40);
            this.TakeBookButton.TabIndex = 0;
            this.TakeBookButton.Text = "Взяти книгу";
            this.TakeBookButton.UseVisualStyleBackColor = true;
            this.TakeBookButton.Click += new System.EventHandler(this.TakeBookButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID користувача:";
            // 
            // returnDatePicker
            // 
            this.returnDatePicker.Location = new System.Drawing.Point(150, 130);
            this.returnDatePicker.Name = "returnDatePicker";
            this.returnDatePicker.Size = new System.Drawing.Size(250, 22);
            this.returnDatePicker.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Повернути:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(189, 30);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 4;
            // 
            // TakeBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.returnDatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TakeBookButton);
            this.Name = "TakeBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Взяти книгу";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}