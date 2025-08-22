using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public partial class TitleScreen : Form
    {
        private System.Windows.Forms.Timer animationTimer;
        private int blinkCounter = 0;
        private bool showPressStart = true;
        private CRTEffectPanel crtPanel;

        public TitleScreen()
        {
            // Form setup
            this.Text = "CODE CRAWLER";
            this.ClientSize = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.KeyPreview = true;
            this.KeyDown += TitleScreen_KeyDown;

            // Create CRT effect panel
            crtPanel = new CRTEffectPanel();
            crtPanel.Dock = DockStyle.Fill;
            crtPanel.BackColor = Color.Black;
            this.Controls.Add(crtPanel);

            // Handle painting on the CRT panel
            crtPanel.Paint += CrtPanel_Paint;

            // Animation timer for blinking text
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 500; // Blink every 500ms
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void CrtPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawTitleScreen(e);
        }

        private void DrawTitleScreen(PaintEventArgs e)
        {
            using (SolidBrush greenBrush = new SolidBrush(Color.Lime))
            using (SolidBrush darkGreenBrush = new SolidBrush(Color.FromArgb(100, 0, 255, 0)))
            using (Font titleFont = new Font("Consolas", 36, FontStyle.Bold))
            using (Font startFont = new Font("Consolas", 18, FontStyle.Italic))
            using (Font infoFont = new Font("Consolas", 12, FontStyle.Regular))
            {
                // Draw title with shadow effect
                e.Graphics.DrawString("CODE", titleFont, darkGreenBrush, 152, 102);
                e.Graphics.DrawString("CRAWLER", titleFont, darkGreenBrush, 132, 162);
                e.Graphics.DrawString("CODE", titleFont, greenBrush, 150, 100);
                e.Graphics.DrawString("CRAWLER", titleFont, greenBrush, 130, 160);

                // Draw blinking "PRESS ANY KEY" text
                if (showPressStart)
                {
                    e.Graphics.DrawString("PRESS ANY KEY", startFont, greenBrush, 200, 300);
                }

                // Draw additional arcade info
                e.Graphics.DrawString("© 2025 ASN & AGW STUDIOS", infoFont, darkGreenBrush, 220, 400);
                e.Graphics.DrawString("INSERT COIN TO START", infoFont, darkGreenBrush, 210, 430);
            }

            // Draw border
            using (Pen borderPen = new Pen(Color.Lime, 3))
            {
                e.Graphics.DrawRectangle(borderPen, 10, 10, this.Width - 20, this.Height - 20);
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            blinkCounter++;
            showPressStart = !showPressStart; // Toggle visibility
            crtPanel.Invalidate(); // Redraw the CRT panel
        }

        private void TitleScreen_KeyDown(object sender, KeyEventArgs e)
        {
            // Any key starts the game
            ArcadeSounds.PlayStartGameSound();
            animationTimer.Stop();

            this.Hide();
            MainForm gameForm = new MainForm();
            gameForm.FormClosed += (s, args) => this.Close();
            gameForm.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            animationTimer?.Stop();
            animationTimer?.Dispose();
            base.OnFormClosed(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            TitleScreen_KeyDown(this, new KeyEventArgs(Keys.Enter));
        }
    }
}