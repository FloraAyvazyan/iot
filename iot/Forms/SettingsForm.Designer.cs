namespace iot.Forms
{
    partial class SettingsForm
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
            label1 = new Label();
            label2 = new Label();
            numCountdown = new NumericUpDown();
            chkAutoMode = new CheckBox();
            chkNotifications = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCountdown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(233, 31);
            label1.TabIndex = 0;
            label1.Text = "Application Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(221, 23);
            label2.TabIndex = 1;
            label2.Text = "Countdown Time (seconds):";
            // 
            // numCountdown
            // 
            numCountdown.Location = new Point(30, 95);
            numCountdown.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numCountdown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numCountdown.Name = "numCountdown";
            numCountdown.Size = new Size(100, 30);
            numCountdown.TabIndex = 2;
            numCountdown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // chkAutoMode
            // 
            chkAutoMode.AutoSize = true;
            chkAutoMode.Location = new Point(30, 140);
            chkAutoMode.Name = "chkAutoMode";
            chkAutoMode.Size = new Size(174, 27);
            chkAutoMode.TabIndex = 3;
            chkAutoMode.Text = "Enable Auto Mode";
            chkAutoMode.UseVisualStyleBackColor = true;
            // 
            // chkNotifications
            // 
            chkNotifications.AutoSize = true;
            chkNotifications.Location = new Point(30, 170);
            chkNotifications.Name = "chkNotifications";
            chkNotifications.Size = new Size(184, 27);
            chkNotifications.TabIndex = 4;
            chkNotifications.Text = "Enable Notifications";
            chkNotifications.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(52, 152, 219);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(30, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save Settings";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(200, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(430, 348);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkNotifications);
            Controls.Add(chkAutoMode);
            Controls.Add(numCountdown);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)numCountdown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numCountdown;
        private CheckBox chkAutoMode;
        private CheckBox chkNotifications;
        private Button btnSave;
        private Button btnCancel;
    }
}