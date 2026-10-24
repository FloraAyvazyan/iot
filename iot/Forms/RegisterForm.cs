using System;
using System.Windows.Forms;
using iot.Utilities;

namespace iot.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            if (password != confirm)
            {
                lblError.Text = "პაროლები არ ემთხვევა ერთმანეთს.";
                return;
            }

            bool success = AppServices.Auth.Register(fullName, username, password, out string error);

            if (!success)
            {
                lblError.Text = error;
                return;
            }

            MessageBox.Show("რეგისტრაცია წარმატებით დასრულდა! ახლა შეგიძლია შეხვიდე სისტემაში.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}