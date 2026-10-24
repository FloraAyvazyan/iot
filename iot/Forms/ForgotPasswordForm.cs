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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "გთხოვთ შეიყვანოთ მომხმარებლის სახელი.";
                return;
            }

            var user = AppServices.Users.FindByUsername(username);
            if (user == null)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "მომხმარებელი ვერ მოიძებნა.";
                return;
            }

            // TODO: რეალური email სერვისი მოგვიანებით დაემატება
            AppServices.Logger.LogInfo($"პაროლის აღდგენის მოთხოვნა: {username}", "Auth", username);
            AppServices.History.Add(HistoryService.EventLogin, $"პაროლის აღდგენის მოთხოვნა: {username}", username);

            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Text = "პაროლის აღდგენის ინსტრუქცია გაიგზავნა (სიმულაცია).";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}