using System;
using System.Windows.Forms;
using iot.Services; 
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
            // ⬇️ 1. ენის გამოყენება და ღილაკების (EN/GE) დამატება
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);

            // ⬇️ 2. პარამეტრების ჩატვირთვა
            var settings = AppServices.Settings.Current;
            numCountdown.Value = settings.CountdownSeconds;
            chkAutoMode.Checked = settings.AutoMode;
            chkNotifications.Checked = settings.NotificationsEnabled;
        }

        // ⬇️ 3. ენის შეცვლის მეთოდი
        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("პარამეტრები", "Settings");
            lblTitle.Text = LanguageService.T("პარამეტრები", "Application Settings");
            lblCountdownTitle.Text = LanguageService.T("უკუთვლის დრო (წამი):", "Countdown Time (seconds):");
            chkAutoMode.Text = LanguageService.T("ავტომატური რეჟიმი", "Auto Mode");
            chkNotifications.Text = LanguageService.T("შეტყობინებები", "Notifications");
            btnSave.Text = LanguageService.T("შენახვა", "Save");
            btnCancel.Text = LanguageService.T("გაუქმება", "Cancel");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ვინახავთ ახალ პარამეტრებს
            var settings = AppServices.Settings.Current;
            settings.CountdownSeconds = (int)numCountdown.Value;
            settings.AutoMode = chkAutoMode.Checked;
            settings.NotificationsEnabled = chkNotifications.Checked;

            AppServices.Settings.Save(settings);

            // ისტორიაში შენახვა თარგმანით
            AppServices.History.Add("SettingsChanged", LanguageService.T("პარამეტრები შეიცვალა", "Settings changed"), AppServices.Auth.CurrentUser?.Username);

            // შეტყობინება თარგმანით
            MessageBox.Show(LanguageService.T("პარამეტრები წარმატებით შეინახა!", "Settings saved successfully!"),
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}