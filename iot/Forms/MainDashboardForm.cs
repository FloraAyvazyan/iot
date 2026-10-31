using System;
using System.Windows.Forms;
using iot.Utilities;
using iot.Services;

namespace iot.Forms
{
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();
        }

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
            // Countdown-ის ივენთების მიბმა
            AppServices.Countdown.OnTick += Countdown_OnTick;
            AppServices.Countdown.OnFinished += Countdown_OnFinished;

            // ენის გამოყენება და ღილაკების (EN/GE) დამატება
            ApplyLanguage();
            LanguageUIHelper.AttachLanguageButtons(this, ApplyLanguage);

            UpdateUI();
            ApplyTheme();
            uiTimer.Start();
        }

        // ⬇️ აი ეს მეთოდი აკლდა! ⬇️
        private void ApplyLanguage()
        {
            this.Text = LanguageService.T("ჭკვიანი ოთახი - პანელი", "Smart Room - Dashboard");

            // GroupBox-ის სათაური (შეცვალე groupBox1 შენი სახელით)
            groupBox1.Text = LanguageService.T("ოთახის სტატუსი", "Room Status");

            // სტატუსების სათაურები (შეცვალე lblOccupancyTitle და lblLightTitle შენი სახელებით)
            lblOccupancyTitle.Text = LanguageService.T("დაკავებულობა:", "Occupancy:");
            lblLightTitle.Text = LanguageService.T("შუქი:", "Light:");

            // ღილაკები
            btnPersonDetected.Text = LanguageService.T("ადამიანია", "Person Detected");
            btnNoPerson.Text = LanguageService.T("ცარიელია", "No Person");
            btnSettings.Text = LanguageService.T("პარამეტრები", "Settings");
            btnHistory.Text = LanguageService.T("ისტორია", "History");
            btnLogs.Text = LanguageService.T("ლოგები", "Logs");
            btnLogout.Text = LanguageService.T("გასვლა", "Logout");

            if (btnDarkMode.Text.Contains("Dark") || btnDarkMode.Text.Contains("მუქი"))
                btnDarkMode.Text = LanguageService.T("🌙 მუქი რეჟიმი", "🌙 Dark Mode");
            else
                btnDarkMode.Text = LanguageService.T("☀️ ნათელი რეჟიმი", "☀️ Light Mode");

            UpdateUI(); // სტატუსების განახლება
        }

        // ტაიმერი: ყოველ წამს ახლდება დრო და Countdown
        private void uiTimer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = LanguageService.T("დრო: ", "Time: ") + DateTime.Now.ToString("HH:mm:ss");

            // თუ უკუთვლა აქტიურია, ვამცირებთ დროს
            if (AppServices.Countdown.IsActive)
            {
                AppServices.Countdown.Update();
            }
        }

        private void btnPersonDetected_Click(object sender, EventArgs e)
        {
            AppServices.Countdown.StopCountdown();
            AppServices.Sensor.DetectPerson();
            AppServices.Light.TurnOnLight();

            // PersonDetected
            AppServices.History.Add("PersonDetected", "", AppServices.Auth.CurrentUser?.Username);
            AppServices.History.Add("LightOn", "", AppServices.Auth.CurrentUser?.Username);

            // NoPerson
            AppServices.History.Add("NoPerson", "", AppServices.Auth.CurrentUser?.Username);

             AppServices.History.Add("LightOff", "", AppServices.Auth.CurrentUser?.Username);

            UpdateUI();
        }

        private void btnNoPerson_Click(object sender, EventArgs e)
        {
            AppServices.Sensor.NoPersonDetected();

            AppServices.History.Add("NoPerson", LanguageService.T("ადამიანი მიატოვა ოთახი", "Person left the room"), AppServices.Auth.CurrentUser?.Username);

            int countdownSeconds = AppServices.Settings.Current.CountdownSeconds;
            if (countdownSeconds <= 0) countdownSeconds = 30;

            AppServices.Countdown.StartCountdown(countdownSeconds);

            UpdateUI();
        }

        private void Countdown_OnTick(int remainingSeconds, int totalSeconds)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Countdown_OnTick(remainingSeconds, totalSeconds)));
                return;
            }

            lblCountdown.Text = LanguageService.T($"უკუთვლა: {remainingSeconds}წმ", $"Countdown: {remainingSeconds}s");

            progressBarCountdown.Maximum = totalSeconds;
            progressBarCountdown.Value = remainingSeconds;
        }

        private void Countdown_OnFinished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Countdown_OnFinished()));
                return;
            }

            AppServices.Light.TurnOffLight();
            AppServices.History.Add("LightOff", LanguageService.T("უკუთვლის დასრულების შემდეგ შუქი გამოირთო", "Light turned off after countdown"), AppServices.Auth.CurrentUser?.Username);

            lblCountdown.Text = LanguageService.T("უკუთვლა: --", "Countdown: --");
            progressBarCountdown.Value = 0;

            UpdateUI();
        }

        // UI-ს განახლების დამხმარე მეთოდი
        private void UpdateUI()
        {
            // ოთახის სტატუსი
            if (AppServices.Sensor.IsPersonDetected)
            {
                lblRoomStatus.Text = LanguageService.T("დაკავებულია", "Occupied");
                lblRoomStatus.ForeColor = System.Drawing.Color.Green;

                // ⬇️ როცა ადამიანია: მწვანე ღილაკი ინთება, წითელი ქრება
                btnPersonDetected.BackColor = System.Drawing.Color.FromArgb(39, 174, 96); // მუქი მწვანე
                btnPersonDetected.Font = new System.Drawing.Font(btnPersonDetected.Font, System.Drawing.FontStyle.Bold);

                btnNoPerson.BackColor = System.Drawing.Color.FromArgb(189, 195, 199); // ნაცრისფერი
                btnNoPerson.Font = new System.Drawing.Font(btnNoPerson.Font, System.Drawing.FontStyle.Regular);
            }
            else
            {
                lblRoomStatus.Text = LanguageService.T("ცარიელია", "Empty");
                lblRoomStatus.ForeColor = System.Drawing.Color.Red;

                // ⬇️ როცა ცარიელია: წითელი ღილაკი ინთება, მწვანე ქრება
                btnNoPerson.BackColor = System.Drawing.Color.FromArgb(192, 57, 43); // მუქი წითელი
                btnNoPerson.Font = new System.Drawing.Font(btnNoPerson.Font, System.Drawing.FontStyle.Bold);

                btnPersonDetected.BackColor = System.Drawing.Color.FromArgb(189, 195, 199); // ნაცრისფერი
                btnPersonDetected.Font = new System.Drawing.Font(btnPersonDetected.Font, System.Drawing.FontStyle.Regular);
            }

            // შუქის სტატუსი
            if (AppServices.Light.IsLightOn)
            {
                lblLightStatus.Text = LanguageService.T("ჩართულია", "ON");
                lblLightStatus.ForeColor = System.Drawing.Color.Gold;
            }
            else
            {
                lblLightStatus.Text = LanguageService.T("გამორთულია", "OFF");
                lblLightStatus.ForeColor = System.Drawing.Color.Gray;
            }

            // ბოლო დაფიქსირების დრო
            if (AppServices.Sensor.LastDetectionTime.HasValue)
            {
                lblLastDetection.Text = LanguageService.T("ბოლო დაფიქსირება: ", "Last Detection: ") + AppServices.Sensor.LastDetectionTime.Value.ToString("HH:mm:ss");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppServices.Auth.Logout();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var historyForm = new HistoryForm();
            historyForm.ShowDialog(this);
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            var logsForm = new LogsForm();
            logsForm.ShowDialog(this);
        }

        private void MainDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            var settings = AppServices.Settings.Current;
            settings.IsDarkMode = !settings.IsDarkMode;
            AppServices.Settings.Save(settings);

            ApplyTheme();
        }

        private void ApplyTheme()
        {
            bool isDark = AppServices.Settings.Current.IsDarkMode;

            if (isDark)
            {
                this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is GroupBox || ctrl is Panel)
                    {
                        ctrl.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                        ctrl.ForeColor = System.Drawing.Color.White;
                    }
                    else if (ctrl is Label && ctrl.Name != "lblRoomStatus" && ctrl.Name != "lblLightStatus")
                    {
                        ctrl.ForeColor = System.Drawing.Color.White;
                    }
                    else if (ctrl is Button btn && btn != btnPersonDetected && btn != btnNoPerson)
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(63, 63, 70);
                        btn.ForeColor = System.Drawing.Color.White;
                    }
                }
                // ენის შენარჩუნება თემის შეცვლისას
                btnDarkMode.Text = LanguageService.T("☀️ ნათელი რეჟიმი", "☀️ Light Mode");
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is GroupBox || ctrl is Panel)
                    {
                        ctrl.BackColor = System.Drawing.Color.White;
                        ctrl.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (ctrl is Label && ctrl.Name != "lblRoomStatus" && ctrl.Name != "lblLightStatus")
                    {
                        ctrl.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (ctrl is Button btn && btn != btnPersonDetected && btn != btnNoPerson)
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
                        btn.ForeColor = System.Drawing.Color.White;
                    }
                }
                btnDarkMode.Text = LanguageService.T("🌙 მუქი რეჟიმი", "🌙 Dark Mode");
            }
        }
    }
}