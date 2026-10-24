namespace iot.Forms
{
    partial class LoginForm
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
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkRemember = new CheckBox();
            btnLogin = new Button();
            btnRegister = new Button();
            btnForgotPassword = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Smart Room Monitor";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //lblTitle.Click += lblTitle_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Location = new Point(30, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(360, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "გთხოვთ გაიაროთ ავტორიზაცია";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            //lblSubtitle.Click += label1_Click_2;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(50, 130);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 25);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(50, 160);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(320, 31);
            txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(50, 205);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 25);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(50, 235);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(320, 31);
            txtPassword.TabIndex = 5;
            // 
            // chkRemember
            // 
            chkRemember.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRemember.Location = new Point(50, 275);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(200, 25);
            chkRemember.TabIndex = 6;
            chkRemember.Text = "Remember Me";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(52, 152, 219);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 315);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(320, 40);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(46, 204, 113);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 365);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(155, 35);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.BackColor = Color.FromArgb(149, 165, 166);
            btnForgotPassword.Cursor = Cursors.Hand;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.ForeColor = Color.White;
            btnForgotPassword.Location = new Point(215, 365);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(155, 35);
            btnForgotPassword.TabIndex = 9;
            btnForgotPassword.Text = "Forgot Password?";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.FromArgb(231, 76, 60);
            lblError.Location = new Point(50, 410);
            lblError.Name = "lblError";
            lblError.Size = new Size(320, 30);
            lblError.TabIndex = 10;
            lblError.Text = "(ცარიელი)";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(402, 433);
            Controls.Add(lblError);
            Controls.Add(btnForgotPassword);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(chkRemember);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Smart Room - Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkRemember;
        private Button btnLogin;
        private Button btnRegister;
        private Button btnForgotPassword;
        private Label lblError;
    }
}