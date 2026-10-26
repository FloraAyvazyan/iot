using System;
using System.Windows.Forms;
using iot.Utilities;

namespace iot.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            // ⬇️ აქ პროგრამა ამოწმებს settings.json-ს, ხომ არ არის იუზერი დამახსოვრებული
            var settings = AppServices.Settings.Current;
            if (settings.RememberLastUser && !string.IsNullOrWhiteSpace(settings.LastLoggedInUser))
            {
                txtUsername.Text = settings.LastLoggedInUser;
                chkRemember.Checked = true;
                txtPassword.Focus(); // კურსორი გადადის პაროლის ველზე
            }
            else
            {
                txtUsername.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // ავტორიზაცია
            bool success = AppServices.Auth.Login(username, password, chkRemember.Checked, out string error);

            if (!success)
            {
                lblError.Text = error;
                return;
            }

            // ⬇️ თუ წარმატებით შემოვიდა, ვინახავთ settings.json-ში, რომ შემდეგ ჯერზე გაიხსენოს
            var settings = AppServices.Settings.Current;
            settings.RememberLastUser = chkRemember.Checked;
            settings.LastLoggedInUser = chkRemember.Checked ? username : string.Empty;
            AppServices.Settings.Save(settings);

            // Dashboard-ზე გადასვლა
            var dashboard = new MainDashboardForm();
            dashboard.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog(this);
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            var forgotForm = new ForgotPasswordForm();
            forgotForm.ShowDialog(this);
        }
    }
}