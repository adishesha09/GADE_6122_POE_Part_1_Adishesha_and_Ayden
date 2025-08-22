using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public class CRTEffectPanel : Panel
    {
        public CRTEffectPanel()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw scanlines for CRT effect
            using (Pen scanlinePen = new Pen(Color.FromArgb(20, Color.Lime), 1))
            {
                for (int y = 0; y < this.Height; y += 3)
                {
                    e.Graphics.DrawLine(scanlinePen, 0, y, this.Width, y);
                }
            }

            // Add slight vignette effect
            using (Brush vignette = new LinearGradientBrush(
                this.ClientRectangle,
                Color.Transparent,
                Color.FromArgb(80, Color.Black),
                45f))
            {
                e.Graphics.FillRectangle(vignette, this.ClientRectangle);
            }
        }
    }
}
