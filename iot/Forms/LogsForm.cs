using System;
using System.Windows.Forms;
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
            var logs = AppServices.Logger.GetAll();
            dgvLogs.DataSource = logs;

            if (dgvLogs.Columns["Id"] != null) dgvLogs.Columns["Id"].Visible = false;
            if (dgvLogs.Columns["Exception"] != null) dgvLogs.Columns["Exception"].Visible = false; // ზედმეტად გრძელია

            if (dgvLogs.Columns["Timestamp"] != null) dgvLogs.Columns["Timestamp"].HeaderText = "Date & Time";
            if (dgvLogs.Columns["Level"] != null) dgvLogs.Columns["Level"].HeaderText = "Level";
            if (dgvLogs.Columns["Category"] != null) dgvLogs.Columns["Category"].HeaderText = "Category";
            if (dgvLogs.Columns["Message"] != null) dgvLogs.Columns["Message"].HeaderText = "Message";
            if (dgvLogs.Columns["Username"] != null) dgvLogs.Columns["Username"].HeaderText = "User";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}