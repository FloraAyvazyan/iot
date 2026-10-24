using System;
using System.Windows.Forms;
using iot.Utilities;

namespace iot.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // ვტვირთავთ მიმდინარე პარამეტრებს
            var settings = AppServices.Settings.Current;
            numCountdown.Value = settings.CountdownSeconds;
            chkAutoMode.Checked = settings.AutoMode;
            chkNotifications.Checked = settings.NotificationsEnabled;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ვინახავთ ახალ პარამეტრებს
            var settings = AppServices.Settings.Current;
            settings.CountdownSeconds = (int)numCountdown.Value;
            settings.AutoMode = chkAutoMode.Checked;
            settings.NotificationsEnabled = chkNotifications.Checked;

            AppServices.Settings.Save(settings);
            AppServices.History.Add("SettingsChanged", "პარამეტრები შეიცვალა", AppServices.Auth.CurrentUser?.Username);

            MessageBox.Show("პარამეტრები წარმატებით შეინახა!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}