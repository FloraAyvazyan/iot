using System;
using System.Windows.Forms;
using iot.Services;  
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

            // ⬇️ 1. ენის გამოყენება და ღილაკების (EN/GE) დამატება
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);

            // ⬇️ 2. Remember Me ლოგიკა
            var settings = AppServices.Settings.Current;
            if (settings.RememberLastUser && !string.IsNullOrWhiteSpace(settings.LastLoggedInUser))
            {
                txtUsername.Text = settings.LastLoggedInUser;
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
            else
            {
                txtUsername.Focus();
            }
        }

        // ⬇️ 3. ენის შეცვლის მეთოდი
        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("ჭკვიანი ოთახი - შესვლა", "Smart Room - Login");
            lblTitle.Text = LanguageService.T("ჭკვიანი ოთახის მონიტორი", "Smart Room Monitor");
            lblSubtitle.Text = LanguageService.T("გთხოვთ გაიაროთ ავტორიზაცია", "Please log in");
            lblUsername.Text = LanguageService.T("მომხმარებელი", "Username");
            lblPassword.Text = LanguageService.T("პაროლი", "Password");
            chkRemember.Text = LanguageService.T("დამიმახსოვრე", "Remember Me");
            btnLogin.Text = LanguageService.T("შესვლა", "Login");
            btnRegister.Text = LanguageService.T("რეგისტრაცია", "Register");
            btnForgotPassword.Text = LanguageService.T("დაგავიწყდა პაროლი?", "Forgot Password?");
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

            // თუ წარმატებით შემოვიდა, ვინახავთ settings.json-ში
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

        // ეს ცარიელი მეთოდი შემთხვევით გქონდა შექმნილი, შეგიძლია წაშალო, ოღონდ თუ Designer-ში არის მიბმული, დატოვე.
        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}