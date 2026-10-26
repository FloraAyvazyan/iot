namespace iot.Forms
{
    partial class MainDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnLogout = new Button();
            groupBox1 = new GroupBox();
            progressBarCountdown = new ProgressBar();
            lblCountdown = new Label();
            lblCurrentTime = new Label();
            lblLastDetection = new Label();
            lblLightStatus = new Label();
            label2 = new Label();
            lblRoomStatus = new Label();
            label1 = new Label();
            btnPersonDetected = new Button();
            btnNoPerson = new Button();
            uiTimer = new System.Windows.Forms.Timer(components);
            btnSettings = new Button();
            btnHistory = new Button();
            btnLogs = new Button();
            btnDarkMode = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(215, 541);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 37);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBarCountdown);
            groupBox1.Controls.Add(lblCountdown);
            groupBox1.Controls.Add(lblCurrentTime);
            groupBox1.Controls.Add(lblLastDetection);
            groupBox1.Controls.Add(lblLightStatus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblRoomStatus);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(30, 30);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(350, 299);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Room Status";
            // 
            // progressBarCountdown
            // 
            progressBarCountdown.Location = new Point(20, 230);
            progressBarCountdown.Name = "progressBarCountdown";
            progressBarCountdown.Size = new Size(300, 20);
            progressBarCountdown.TabIndex = 7;
            // 
            // lblCountdown
            // 
            lblCountdown.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountdown.ForeColor = Color.FromArgb(230, 126, 34);
            lblCountdown.Location = new Point(20, 200);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(159, 25);
            lblCountdown.TabIndex = 6;
            lblCountdown.Text = "Countdown: --";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(20, 170);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(128, 28);
            lblCurrentTime.TabIndex = 5;
            lblCurrentTime.Text = "Time: --:--:--";
            // 
            // lblLastDetection
            // 
            lblLastDetection.AutoSize = true;
            lblLastDetection.Font = new Font("Segoe UI", 10.2F);
            lblLastDetection.Location = new Point(20, 130);
            lblLastDetection.Name = "lblLastDetection";
            lblLastDetection.Size = new Size(178, 23);
            lblLastDetection.TabIndex = 4;
            lblLastDetection.Text = "Last Detection: --:--:--";
            // 
            // lblLightStatus
            // 
            lblLightStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLightStatus.ForeColor = Color.Gray;
            lblLightStatus.Location = new Point(150, 80);
            lblLightStatus.Name = "lblLightStatus";
            lblLightStatus.Size = new Size(62, 25);
            lblLightStatus.TabIndex = 3;
            lblLightStatus.Text = "OFF";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 80);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 2;
            label2.Text = "Light:";
            // 
            // lblRoomStatus
            // 
            lblRoomStatus.AutoSize = true;
            lblRoomStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomStatus.ForeColor = Color.Red;
            lblRoomStatus.Location = new Point(150, 40);
            lblRoomStatus.Name = "lblRoomStatus";
            lblRoomStatus.Size = new Size(66, 25);
            lblRoomStatus.TabIndex = 1;
            lblRoomStatus.Text = "Empty";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 40);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 0;
            label1.Text = "Occupancy:";
            // 
            // btnPersonDetected
            // 
            btnPersonDetected.AutoSize = true;
            btnPersonDetected.BackColor = Color.FromArgb(46, 204, 113);
            btnPersonDetected.FlatStyle = FlatStyle.Flat;
            btnPersonDetected.ForeColor = Color.White;
            btnPersonDetected.Location = new Point(30, 381);
            btnPersonDetected.Name = "btnPersonDetected";
            btnPersonDetected.Size = new Size(179, 50);
            btnPersonDetected.TabIndex = 2;
            btnPersonDetected.Text = "Person Detected";
            btnPersonDetected.UseVisualStyleBackColor = false;
            btnPersonDetected.Click += btnPersonDetected_Click;
            // 
            // btnNoPerson
            // 
            btnNoPerson.BackColor = Color.FromArgb(231, 76, 60);
            btnNoPerson.FlatStyle = FlatStyle.Flat;
            btnNoPerson.ForeColor = Color.White;
            btnNoPerson.Location = new Point(215, 381);
            btnNoPerson.Name = "btnNoPerson";
            btnNoPerson.Size = new Size(165, 50);
            btnNoPerson.TabIndex = 3;
            btnNoPerson.Text = "No Person";
            btnNoPerson.UseVisualStyleBackColor = false;
            btnNoPerson.Click += btnNoPerson_Click;
            // 
            // uiTimer
            // 
            uiTimer.Enabled = true;
            uiTimer.Interval = 1000;
            uiTimer.Tick += uiTimer_Tick;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(52, 152, 219);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(30, 447);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(150, 40);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.FromArgb(155, 89, 182);
            btnHistory.Cursor = Cursors.Hand;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(30, 493);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(150, 40);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnLogs
            // 
            btnLogs.BackColor = Color.FromArgb(52, 73, 94);
            btnLogs.Cursor = Cursors.Hand;
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.ForeColor = Color.White;
            btnLogs.Location = new Point(30, 539);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(150, 40);
            btnLogs.TabIndex = 6;
            btnLogs.Text = "Logs";
            btnLogs.UseVisualStyleBackColor = false;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnDarkMode
            // 
            btnDarkMode.BackColor = Color.FromArgb(52, 73, 94);
            btnDarkMode.Cursor = Cursors.Hand;
            btnDarkMode.FlatStyle = FlatStyle.Flat;
            btnDarkMode.ForeColor = Color.White;
            btnDarkMode.Location = new Point(215, 447);
            btnDarkMode.Name = "btnDarkMode";
            btnDarkMode.Size = new Size(150, 40);
            btnDarkMode.TabIndex = 7;
            btnDarkMode.Text = "Toggle Dark Mode";
            btnDarkMode.UseVisualStyleBackColor = false;
            btnDarkMode.Click += btnDarkMode_Click;
            // 
            // MainDashboardForm
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(408, 595);
            Controls.Add(btnDarkMode);
            Controls.Add(btnLogs);
            Controls.Add(btnHistory);
            Controls.Add(btnSettings);
            Controls.Add(btnNoPerson);
            Controls.Add(btnPersonDetected);
            Controls.Add(groupBox1);
            Controls.Add(btnLogout);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "MainDashboardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Smart Room - Dashboard";
            FormClosed += MainDashboardForm_FormClosed;
            Load += MainDashboardForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private GroupBox groupBox1;
        private Label lblLastDetection;
        private Label lblLightStatus;
        private Label label2;
        private Label lblRoomStatus;
        private Label label1;
        private Label lblCurrentTime;
        private Button btnPersonDetected;
        private Button btnNoPerson;
        private System.Windows.Forms.Timer uiTimer;
        private ProgressBar progressBarCountdown;
        private Label lblCountdown;
        private Button btnSettings;
        private Button btnHistory;
        private Button btnLogs;
        private Button btnDarkMode;
    }
}