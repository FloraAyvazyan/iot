using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using iot.Services;

namespace iot.Utilities
{
    public static class LanguageUIHelper
    {
        public static void AttachLanguageButtons(Form form, Action onLanguageChanged)
        {
            // ინგლისური (EN)
            Button btnEn = new Button();
            btnEn.Text = "EN";
            btnEn.Size = new Size(45, 25);
            btnEn.Location = new Point(form.ClientSize.Width - 105, 10);
            btnEn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEn.FlatStyle = FlatStyle.Flat;
            btnEn.FlatAppearance.BorderSize = 0; // საზღვრის გარეშე
            btnEn.BackColor = Color.FromArgb(52, 152, 219); // ლამაზი ლურჯი
            btnEn.ForeColor = Color.White;
            btnEn.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            btnEn.Cursor = Cursors.Hand;
            btnEn.Click += (s, e) =>
            {
                LanguageService.SetLanguage("EN");
                onLanguageChanged?.Invoke();
            };

            // ქართული (GE)
            Button btnKa = new Button();
            btnKa.Text = "GE";
            btnKa.Size = new Size(45, 25);
            btnKa.Location = new Point(form.ClientSize.Width - 55, 10);
            btnKa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKa.FlatStyle = FlatStyle.Flat;
            btnKa.FlatAppearance.BorderSize = 0;
            btnKa.BackColor = Color.FromArgb(46, 204, 113); // ლამაზი მწვანე
            btnKa.ForeColor = Color.White;
            btnKa.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            btnKa.Cursor = Cursors.Hand;
            btnKa.Click += (s, e) =>
            {
                LanguageService.SetLanguage("KA");
                onLanguageChanged?.Invoke();
            };

            form.Controls.Add(btnEn);
            form.Controls.Add(btnKa);
            btnEn.BringToFront();
            btnKa.BringToFront();
        }
    }
}