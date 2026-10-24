namespace iot.Forms
{
    partial class ForgotPasswordForm
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
            lblInfo = new Label();
            txtUsername = new TextBox();
            btnSubmit = new Button();
            btnClose = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(30, 30);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(360, 25);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "შეიყვანე მომხმარებლის სახელი.";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(30, 70);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 31);
            txtUsername.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(52, 152, 219);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(30, 120);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(170, 40);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Send Recovery";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(149, 165, 166);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(220, 120);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(170, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(39, 174, 96);
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(30, 170);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(360, 50);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "(ცარიელი)";
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(452, 268);
            Controls.Add(lblStatus);
            Controls.Add(btnClose);
            Controls.Add(btnSubmit);
            Controls.Add(txtUsername);
            Controls.Add(lblInfo);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Forgot Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private TextBox txtUsername;
        private Button btnSubmit;
        private Button btnClose;
        private Label lblStatus;
    }
}