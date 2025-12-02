using System.Drawing;
using System.Windows.Forms;
using LibraryTeamWinFormApp.Core.Extensions;

namespace LibraryTeamWinFormApp.Forms.Shared
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            InitializeBaseForm();
        }

        private void InitializeBaseForm()
        {
            this.ApplyLibraryTheme();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.AutoScaleMode = AutoScaleMode.Font;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        }

        protected void CenterControls(params Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control != null)
                {
                    control.Left = (this.ClientSize.Width - control.Width) / 2;
                }
            }
        }

        protected void ShowError(string message)
        {
            MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected bool ValidateDatabaseConnection()
        {
            return Core.Database.Db.ValidateConnection();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}