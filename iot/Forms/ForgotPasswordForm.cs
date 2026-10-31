using iot.Services; // ⬅️ აუცილებელია LanguageService-ისთვის
using iot.Utilities;
using SmartRoomMonitor.Services;
using System;
using System.Windows.Forms;

namespace iot.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;

            // ⬇️ 1. ენის გამოყენება და ღილაკების (EN/GE) დამატება
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);
        }

        // ⬇️ 2. ენის შეცვლის მეთოდი
        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("პაროლის აღდგენა", "Forgot Password");
            lblInfo.Text = LanguageService.T("შეიყვანე მომხმარებლის სახელი.", "Enter your username.");
            btnSubmit.Text = LanguageService.T("გაგზავნა", "Send Recovery");
            btnClose.Text = LanguageService.T("დახურვა", "Close");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = LanguageService.T("გთხოვთ შეიყვანოთ მომხმარებლის სახელი.", "Please enter a username.");
                return;
            }

            var user = AppServices.Users.FindByUsername(username);
            if (user == null)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = LanguageService.T("მომხმარებელი ვერ მოიძებნა.", "User not found.");
                return;
            }

            // TODO: რეალური email სერვისი მოგვიანებით დაემატება
            AppServices.Logger.LogInfo($"პაროლის აღდგენის მოთხოვნა: {username}", "Auth", username);
            AppServices.History.Add(HistoryService.EventLogin, $"პაროლის აღდგენის მოთხოვნა: {username}", username);

            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Text = LanguageService.T("პაროლის აღდგენის ინსტრუქცია გაიგზავნა (სიმულაცია).", "Password recovery instructions sent (simulation).");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
    }
}