using iot.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iot.Forms
{
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // სისტემიდან გასვლა
            AppServices.Auth.Logout();

            // Login ფორმის გახსნა და Dashboard-ის დახურვა
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void MainDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
