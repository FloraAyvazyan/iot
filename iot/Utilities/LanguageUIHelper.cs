using System;
using System.Drawing;
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
            btnEn.Size = new Size(40, 25);
            btnEn.Location = new Point(form.ClientSize.Width - 95, 10);
            btnEn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEn.FlatStyle = FlatStyle.Flat;
            btnEn.BackColor = Color.FromArgb(52, 152, 219);
            btnEn.ForeColor = Color.White;
            btnEn.Cursor = Cursors.Hand;
            btnEn.Click += (s, e) =>
            {
                LanguageService.SetLanguage("EN");
                onLanguageChanged?.Invoke(); // ეუბნება ფორმას, რომ ტექსტები განაახლოს
            };

            // ქართული (GE)
            Button btnKa = new Button();
            btnKa.Text = "GE";
            btnKa.Size = new Size(40, 25);
            btnKa.Location = new Point(form.ClientSize.Width - 50, 10);
            btnKa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKa.FlatStyle = FlatStyle.Flat;
            btnKa.BackColor = Color.FromArgb(46, 204, 113);
            btnKa.ForeColor = Color.White;
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