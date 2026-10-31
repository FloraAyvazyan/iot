using System;
using System.Collections.Generic;
using System.Windows.Forms;
using iot.Services;
using iot.Utilities;

namespace iot.Forms
{
    public partial class LogsForm : Form
    {
        public LogsForm()
        {
            InitializeComponent();
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);
        }

        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("სისტემის ლოგები", "System Logs");
            btnClose.Text = LanguageService.T("დახურვა", "Close");

            LoadLogs(); // აქ იძახებს
        }

        private void LoadLogs()
        {
            var logs = AppServices.Logger.GetAll();
            var translatedList = new List<iot.Models.LogRecord>();

            foreach (var log in logs)
            {
                translatedList.Add(new iot.Models.LogRecord
                {
                    Id = log.Id,
                    Timestamp = log.Timestamp,
                    Level = TranslateLevel(log.Level),
                    Category = TranslateCategory(log.Category),
                    Username = log.Username,
                    Message = ""
                });
            }

            dgvLogs.DataSource = translatedList;

            if (dgvLogs.Columns["Id"] != null) dgvLogs.Columns["Id"].Visible = false;
            if (dgvLogs.Columns["Exception"] != null) dgvLogs.Columns["Exception"].Visible = false;
            if (dgvLogs.Columns["Message"] != null) dgvLogs.Columns["Message"].Visible = false;

            if (dgvLogs.Columns["Timestamp"] != null) dgvLogs.Columns["Timestamp"].HeaderText = LanguageService.T("თარიღი/დრო", "Date & Time");
            if (dgvLogs.Columns["Level"] != null) dgvLogs.Columns["Level"].HeaderText = LanguageService.T("დონე", "Level");
            if (dgvLogs.Columns["Category"] != null) dgvLogs.Columns["Category"].HeaderText = LanguageService.T("კატეგორია", "Category");
            if (dgvLogs.Columns["Username"] != null) dgvLogs.Columns["Username"].HeaderText = LanguageService.T("მომხმარებელი", "User");
        }

        private string TranslateLevel(string level)
        {
            switch (level)
            {
                case "Info": return LanguageService.T("ინფო", "Info");
                case "Warning": return LanguageService.T("გაფრთხილება", "Warning");
                case "Error": return LanguageService.T("შეცდომა", "Error");
                default: return level;
            }
        }

        private string TranslateCategory(string category)
        {
            switch (category)
            {
                case "General": return LanguageService.T("ზოგადი", "General");
                case "Auth": return LanguageService.T("ავტორიზაცია", "Auth");
                case "Database": return LanguageService.T("მონაცემები", "Database");
                default: return category;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}