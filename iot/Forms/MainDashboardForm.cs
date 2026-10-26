using System;
using System.Windows.Forms;
using iot.Utilities;

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

            UpdateUI();
            ApplyTheme(); // ⬅️ ეს დაამატე, რომ პროგრამა გახსნისას თემა გაიხსენოს
            uiTimer.Start();
        }

        // ტაიმერი: ყოველ წამს ახლდება დრო და Countdown
        private void uiTimer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = "Time: " + DateTime.Now.ToString("HH:mm:ss");

            // თუ უკუთვლა აქტიურია, ვამცირებთ დროს
            if (AppServices.Countdown.IsActive)
            {
                AppServices.Countdown.Update();
            }
        }

        // ღილაკი: ადამიანი დაფიქსირდა
        private void btnPersonDetected_Click(object sender, EventArgs e)
        {
            // თუ უკუთვლა მიდიოდა, ვაჩერებთ
            AppServices.Countdown.StopCountdown();

            // სენსორი: ადამიანია
            AppServices.Sensor.DetectPerson();

            // შუქის ჩართვა
            AppServices.Light.TurnOnLight();

            // ისტორიაში შენახვა
            AppServices.History.Add("PersonDetected", "ადამიანი დაფიქსირდა ოთახში", AppServices.Auth.CurrentUser?.Username);
            AppServices.History.Add("LightOn", "შუქი ჩაირთო", AppServices.Auth.CurrentUser?.Username);

            UpdateUI();
        }

        // ღილაკი: ადამიანი აღარ არის (იწყება Countdown!)
        private void btnNoPerson_Click(object sender, EventArgs e)
        {
            // სენსორი: ცარიელია
            AppServices.Sensor.NoPersonDetected();

            // ისტორიაში შენახვა
            AppServices.History.Add("NoPerson", "ადამიანი აღარ არის ოთახში", AppServices.Auth.CurrentUser?.Username);

            // ვიღებთ დროს settings-იდან (თუ არ არის, default 30 წამი)
            int countdownSeconds = AppServices.Settings.Current.CountdownSeconds;
            if (countdownSeconds <= 0) countdownSeconds = 30;

            // ვიწყებთ უკუთვლას
            AppServices.Countdown.StartCountdown(countdownSeconds);

            UpdateUI();
        }

        // Countdown-ის ივენთი: ყოველ წამს ახლდება ProgressBar
        private void Countdown_OnTick(int remainingSeconds, int totalSeconds)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Countdown_OnTick(remainingSeconds, totalSeconds)));
                return;
            }

            lblCountdown.Text = $"Countdown: {remainingSeconds}s";

            // ProgressBar-ის განახლება (0-100)
            progressBarCountdown.Maximum = totalSeconds;
            progressBarCountdown.Value = remainingSeconds;
        }

        // Countdown-ის ივენთი: დრო ამოიწურა
        private void Countdown_OnFinished()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Countdown_OnFinished()));
                return;
            }

            // შუქის გამორთვა
            AppServices.Light.TurnOffLight();
            AppServices.History.Add("LightOff", "უკუთვლის დასრულების შემდეგ შუქი გამოირთო", AppServices.Auth.CurrentUser?.Username);

            lblCountdown.Text = "Countdown: --";
            progressBarCountdown.Value = 0;

            UpdateUI();
        }

        // UI-ს განახლების დამხმარე მეთოდი
        private void UpdateUI()
        {
            // ოთახის სტატუსი
            if (AppServices.Sensor.IsPersonDetected)
            {
                lblRoomStatus.Text = "Occupied";
                lblRoomStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblRoomStatus.Text = "Empty";
                lblRoomStatus.ForeColor = System.Drawing.Color.Red;
            }

            // შუქის სტატუსი
            if (AppServices.Light.IsLightOn)
            {
                lblLightStatus.Text = "ON";
                lblLightStatus.ForeColor = System.Drawing.Color.Gold;
            }
            else
            {
                lblLightStatus.Text = "OFF";
                lblLightStatus.ForeColor = System.Drawing.Color.Gray;
            }

            // ბოლო დაფიქსირების დრო
            if (AppServices.Sensor.LastDetectionTime.HasValue)
            {
                lblLastDetection.Text = "Last Detection: " + AppServices.Sensor.LastDetectionTime.Value.ToString("HH:mm:ss");
            }
        }

        // Logout ღილაკი
        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppServices.Auth.Logout();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        // ფორმის დახურვისას
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
            // ვაბრუნებთ პარამეტრს (თუ იყო true, გახდება false და პირიქით)
            var settings = AppServices.Settings.Current;
            settings.IsDarkMode = !settings.IsDarkMode;
            AppServices.Settings.Save(settings);

            // ვიძახებთ თემის განახლების მეთოდს
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            bool isDark = AppServices.Settings.Current.IsDarkMode;

            if (isDark)
            {
                // 🌙 მუქი თემა
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
                btnDarkMode.Text = "☀️ Light Mode";
            }
            else
            {
                // ☀️ ნათელი თემა
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
                        btn.BackColor = System.Drawing.Color.FromArgb(52, 152, 219); // სტანდარტული ლურჯი
                        btn.ForeColor = System.Drawing.Color.White;
                    }
                }
                btnDarkMode.Text = "🌙 Dark Mode";
            }
        }
    }
}