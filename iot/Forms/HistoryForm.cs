using System;
using System.Windows.Forms;
using iot.Utilities;

namespace iot.Forms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            var history = AppServices.History.GetAll();

            // ვქმნით ცხრილს (DataTable-ის გარეშე, პირდაპირ ვაბამთ)
            dgvHistory.DataSource = history;

            // ვმალავთ არასაჭირო სვეტებს
            if (dgvHistory.Columns["Id"] != null) dgvHistory.Columns["Id"].Visible = false;

            // ვარქმევთ სვეტებს ქართულად/გასაგებად
            if (dgvHistory.Columns["Timestamp"] != null) dgvHistory.Columns["Timestamp"].HeaderText = "Date & Time";
            if (dgvHistory.Columns["EventType"] != null) dgvHistory.Columns["EventType"].HeaderText = "Event";
            if (dgvHistory.Columns["Description"] != null) dgvHistory.Columns["Description"].HeaderText = "Description";
            if (dgvHistory.Columns["Username"] != null) dgvHistory.Columns["Username"].HeaderText = "User";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}