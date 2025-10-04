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
            SuspendLayout();
            // 
            // AdminPanelButton
            // 
            AdminPanelButton.Location = new Point(86, 304);
            AdminPanelButton.Name = "AdminPanelButton";
            AdminPanelButton.Size = new Size(136, 54);
            AdminPanelButton.TabIndex = 0;
            AdminPanelButton.Text = "Open AdminPanelButton";
            AdminPanelButton.UseVisualStyleBackColor = true;
            AdminPanelButton.Click += AdminPanelButton_Click;
            // 
            // LibraryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AdminPanelButton);
            Name = "LibraryForm";
            Text = "LibraryForm";
            Load += Form3_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button AdminPanelButton;
    }
}