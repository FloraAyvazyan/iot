using System;
using System.Windows.Forms;
using iot.Services;
using iot.Utilities;

namespace iot.Forms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);
            LoadHistory();
        }

        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("ისტორია", "Activity History");
            btnClose.Text = LanguageService.T("დახურვა", "Close");

            // სვეტების სათაურები
            if (dgvHistory.Columns["Timestamp"] != null) dgvHistory.Columns["Timestamp"].HeaderText = LanguageService.T("თარიღი/დრო", "Date & Time");
            if (dgvHistory.Columns["EventType"] != null) dgvHistory.Columns["EventType"].HeaderText = LanguageService.T("მოვლენა", "Event");
            if (dgvHistory.Columns["Username"] != null) dgvHistory.Columns["Username"].HeaderText = LanguageService.T("მომხმარებელი", "User");

            LoadHistory(); // ⬅️ აუცილებელია, რომ ენის შეცვლისას ცხრილის შიგთავსიც განახლდეს
        }

        private void LoadHistory()
        {
            var history = AppServices.History.GetAll();

            // ⬇️ ვქმნით ახალ სიას, სადაც მონაცემები უკვე თარგმნილი იქნება
            var translatedList = new List<iot.Models.HistoryRecord>();

            foreach (var record in history)
            {
                translatedList.Add(new iot.Models.HistoryRecord
                {
                    Id = record.Id,
                    Timestamp = record.Timestamp,
                    // მოვლენას ვთარგმნით
                    EventType = TranslateEventType(record.EventType),
                    Username = record.Username,
                    Description = "" // აღწერა აღარ გვჭირდება
                });
            }

            // ცხრილს ვაბამთ უკვე თარგმნილ სიას
            dgvHistory.DataSource = translatedList;

            // სვეტების გაფორმება
            if (dgvHistory.Columns["Id"] != null) dgvHistory.Columns["Id"].Visible = false;
            if (dgvHistory.Columns["Description"] != null) dgvHistory.Columns["Description"].Visible = false;

            if (dgvHistory.Columns["Timestamp"] != null) dgvHistory.Columns["Timestamp"].HeaderText = LanguageService.T("თარიღი/დრო", "Date & Time");
            if (dgvHistory.Columns["EventType"] != null) dgvHistory.Columns["EventType"].HeaderText = LanguageService.T("მოვლენა", "Event");
            if (dgvHistory.Columns["Username"] != null) dgvHistory.Columns["Username"].HeaderText = LanguageService.T("მომხმარებელი", "User");
        }

        private string TranslateEventType(string eventType)
        {
            switch (eventType)
            {
                case "PersonDetected": return LanguageService.T("ადამიანი დაფიქსირდა", "Person Detected");
                case "NoPerson": return LanguageService.T("ადამიანი წავიდა", "No Person");
                case "LightOn": return LanguageService.T("შუქი ჩაირთო", "Light On");
                case "LightOff": return LanguageService.T("შუქი გამოირთო", "Light Off");
                case "Login": return LanguageService.T("შესვლა", "Login");
                case "Logout": return LanguageService.T("გასვლა", "Logout");
                case "SettingsChanged": return LanguageService.T("პარამეტრები შეიცვალა", "Settings Changed");
                default: return eventType;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}