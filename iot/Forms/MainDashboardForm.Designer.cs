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
            uiTimer = new System.Windows.Forms.Timer(components);
            btnLogout = new Button();
            groupBox1 = new GroupBox();
            progressBarCountdown = new ProgressBar();
            lblCountdown = new Label();
            lblCurrentTime = new Label();
            lblLastDetection = new Label();
            lblLightStatus = new Label();
            lblLightTitle = new Label();
            lblRoomStatus = new Label();
            lblOccupancyTitle = new Label();
            btnPersonDetected = new Button();
            btnNoPerson = new Button();
            btnSettings = new Button();
            btnHistory = new Button();
            btnLogs = new Button();
            btnDarkMode = new Button();
            group = new GroupBox();
            groupBox1.SuspendLayout();
            group.SuspendLayout();
            SuspendLayout();
            // 
            // uiTimer
            // 
            uiTimer.Enabled = true;
            uiTimer.Interval = 1000;
            uiTimer.Tick += uiTimer_Tick;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Silver;
            btnLogout.Location = new Point(340, 571);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(179, 37);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBarCountdown);
            groupBox1.Controls.Add(lblCountdown);
            groupBox1.Controls.Add(lblCurrentTime);
            groupBox1.Controls.Add(lblLastDetection);
            groupBox1.Controls.Add(lblLightStatus);
            groupBox1.Controls.Add(lblLightTitle);
            groupBox1.Controls.Add(lblRoomStatus);
            groupBox1.Controls.Add(lblOccupancyTitle);
            groupBox1.Location = new Point(12, 39);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(507, 312);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Room Status";
            // 
            // progressBarCountdown
            // 
            progressBarCountdown.Location = new Point(20, 255);
            progressBarCountdown.Name = "progressBarCountdown";
            progressBarCountdown.Size = new Size(300, 20);
            progressBarCountdown.TabIndex = 7;
            // 
            // lblCountdown
            // 
            lblCountdown.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountdown.ForeColor = Color.FromArgb(230, 126, 34);
            lblCountdown.Location = new Point(20, 211);
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
            lblLastDetection.Location = new Point(20, 129);
            lblLastDetection.Name = "lblLastDetection";
            lblLastDetection.Size = new Size(178, 23);
            lblLastDetection.TabIndex = 4;
            lblLastDetection.Text = "Last Detection: --:--:--";
            // 
            // lblLightStatus
            // 
            lblLightStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLightStatus.ForeColor = Color.Gray;
            lblLightStatus.Location = new Point(303, 80);
            lblLightStatus.Name = "lblLightStatus";
            lblLightStatus.Size = new Size(62, 25);
            lblLightStatus.TabIndex = 3;
            lblLightStatus.Text = "OFF";
            // 
            // lblLightTitle
            // 
            lblLightTitle.AutoSize = true;
            lblLightTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLightTitle.Location = new Point(20, 80);
            lblLightTitle.Name = "lblLightTitle";
            lblLightTitle.Size = new Size(60, 25);
            lblLightTitle.TabIndex = 2;
            lblLightTitle.Text = "Light:";
            // 
            // lblRoomStatus
            // 
            lblRoomStatus.AutoSize = true;
            lblRoomStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomStatus.ForeColor = Color.Red;
            lblRoomStatus.Location = new Point(303, 40);
            lblRoomStatus.Name = "lblRoomStatus";
            lblRoomStatus.Size = new Size(66, 25);
            lblRoomStatus.TabIndex = 1;
            lblRoomStatus.Text = "Empty";
            // 
            // lblOccupancyTitle
            // 
            lblOccupancyTitle.AutoSize = true;
            lblOccupancyTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOccupancyTitle.Location = new Point(20, 40);
            lblOccupancyTitle.Name = "lblOccupancyTitle";
            lblOccupancyTitle.Size = new Size(111, 25);
            lblOccupancyTitle.TabIndex = 0;
            lblOccupancyTitle.Text = "Occupancy:";
            // 
            // btnPersonDetected
            // 
            btnPersonDetected.AutoSize = true;
            btnPersonDetected.BackColor = Color.FromArgb(46, 204, 113);
            btnPersonDetected.FlatStyle = FlatStyle.Flat;
            btnPersonDetected.ForeColor = Color.White;
            btnPersonDetected.Location = new Point(12, 366);
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
            btnNoPerson.Location = new Point(340, 366);
            btnNoPerson.Name = "btnNoPerson";
            btnNoPerson.Size = new Size(179, 50);
            btnNoPerson.TabIndex = 3;
            btnNoPerson.Text = "No Person";
            btnNoPerson.UseVisualStyleBackColor = false;
            btnNoPerson.Click += btnNoPerson_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(52, 152, 219);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(12, 422);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(179, 50);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.FromArgb(52, 152, 219);
            btnHistory.Cursor = Cursors.Hand;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(340, 422);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(179, 50);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnLogs
            // 
            btnLogs.BackColor = Color.FromArgb(52, 152, 219);
            btnLogs.Cursor = Cursors.Hand;
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.ForeColor = Color.White;
            btnLogs.Location = new Point(340, 478);
            btnLogs.Name = "btnLogs";
            btnLogs.Size = new Size(179, 50);
            btnLogs.TabIndex = 6;
            btnLogs.Text = "Logs";
            btnLogs.UseVisualStyleBackColor = false;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnDarkMode
            // 
            btnDarkMode.BackColor = Color.FromArgb(52, 152, 219);
            btnDarkMode.Cursor = Cursors.Hand;
            btnDarkMode.FlatStyle = FlatStyle.Flat;
            btnDarkMode.ForeColor = Color.White;
            btnDarkMode.Location = new Point(12, 478);
            btnDarkMode.Name = "btnDarkMode";
            btnDarkMode.Size = new Size(179, 50);
            btnDarkMode.TabIndex = 7;
            btnDarkMode.Text = "Toggle Dark Mode";
            btnDarkMode.UseVisualStyleBackColor = false;
            btnDarkMode.Click += btnDarkMode_Click;
            // 
            // group
            // 
            group.Anchor = AnchorStyles.None;
            group.Controls.Add(btnDarkMode);
            group.Controls.Add(btnLogs);
            group.Controls.Add(btnHistory);
            group.Controls.Add(btnSettings);
            group.Controls.Add(btnNoPerson);
            group.Controls.Add(btnPersonDetected);
            group.Controls.Add(groupBox1);
            group.Controls.Add(btnLogout);
            group.Location = new Point(39, 6);
            group.MaximumSize = new Size(600, 700);
            group.Name = "group";
            group.Size = new Size(531, 627);
            group.TabIndex = 8;
            group.TabStop = false;
            // 
            // MainDashboardForm
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(599, 713);
            Controls.Add(group);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MinimumSize = new Size(600, 700);
            Name = "MainDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Room - Dashboard";
            FormClosed += MainDashboardForm_FormClosed;
            Load += MainDashboardForm_Load;
            Resize += MainDashboardForm_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            group.ResumeLayout(false);
            group.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer uiTimer;
        private Button btnLogout;
        private GroupBox groupBox1;
        private ProgressBar progressBarCountdown;
        private Label lblCountdown;
        private Label lblCurrentTime;
        private Label lblLastDetection;
        private Label lblLightStatus;
        private Label lblLightTitle;
        private Label lblRoomStatus;
        private Label lblOccupancyTitle;
        private Button btnPersonDetected;
        private Button btnNoPerson;
        private Button btnSettings;
        private Button btnHistory;
        private Button btnLogs;
        private Button btnDarkMode;
        private GroupBox group;
    }
}