using System;
using System.Drawing;
using System.Windows.Forms;

namespace Screenshot
{
    class DWMButton : Button
    {
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            const int WM_PAINT = 0xf;
            switch (m.Msg)
            {
                case WM_PAINT:
                    RedrawControlAsBitmap(this.Handle);
                    break;
            }
        }

        public void RedrawControlAsBitmap(IntPtr hwnd)
        {
            using (Bitmap bm = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bm, this.ClientRectangle);
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawImage(bm, new Rectangle(2, 2, this.Width - 4, this.Height - 4), new Rectangle(2, 2, this.Width - 4, this.Height - 4), GraphicsUnit.Pixel);
                }
            }
        }
    }
}
