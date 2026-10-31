using System;
using System.Windows.Forms;
using iot.Services;  
using iot.Utilities;

namespace iot.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            // ⬇️ 1. ენის გამოყენება და ღილაკების (EN/GE) დამატება
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);
        }

        // ⬇️ 2. ენის შეცვლის მეთოდი
        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("რეგისტრაცია", "Register");
            lblTitle.Text = LanguageService.T("რეგისტრაცია", "Create Account");
            lblFullName.Text = LanguageService.T("სახელი და გვარი", "Full Name");
            lblUsername.Text = LanguageService.T("მომხმარებელი", "Username");
            lblPassword.Text = LanguageService.T("პაროლი", "Password");
            lblConfirm.Text = LanguageService.T("გაიმეორე პაროლი", "Confirm Password");
            btnRegister.Text = LanguageService.T("რეგისტრაცია", "Register");
            btnCancel.Text = LanguageService.T("გაუქმება", "Cancel");
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
                lblError.Text = LanguageService.T("პაროლები არ ემთხვევა ერთმანეთს.", "Passwords do not match.");
                return;
            }

            bool success = AppServices.Auth.Register(fullName, username, password, out string error);

            if (!success)
            {
                lblError.Text = error;
                return;
            }

            MessageBox.Show(LanguageService.T("რეგისტრაცია წარმატებით დასრულდა! ახლა შეგიძლია შეხვიდე სისტემაში.",
                                              "Registration successful! You can now log in."),
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