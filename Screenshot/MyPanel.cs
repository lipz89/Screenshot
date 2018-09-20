using System;
using System.Drawing;
using System.Windows.Forms;

namespace Screenshot
{
    public class MyPanel : Panel
    {
        private Color lineColor = Color.FromArgb(43, 145, 175);

        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }
        }
        /// <summary>
        /// 重写绘制事件，给截图区域绘制边框以及矩点
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gp = e.Graphics;
            using (Brush brush = new SolidBrush(lineColor))
            {
                gp.DrawRectangle(new Pen(lineColor), 1, 1, this.Width - 3, this.Height - 3);

                gp.FillRectangle(brush, 0, 0, 4, 4);
                gp.FillRectangle(brush, this.Width - 4, 0, 4, 4);
                gp.FillRectangle(brush, 0, this.Height - 4, 4, 4);
                gp.FillRectangle(brush, this.Width - 4, this.Height - 4, 4, 4);

                gp.FillRectangle(brush, 0, this.Height / 2 - 2, 4, 4);
                gp.FillRectangle(brush, this.Width / 2 - 2, 0, 4, 4);
                gp.FillRectangle(brush, this.Width / 2 - 2, this.Height - 4, 4, 4);
                gp.FillRectangle(brush, this.Width - 4, this.Height / 2 - 2, 4, 4);
            }
        }
        /// <summary>
        /// 改变大小时，重新绘制
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnResize(EventArgs eventargs)
        {
            this.SuspendLayout();
            base.OnResize(eventargs);
            this.Invalidate();
            this.ResumeLayout(false);
        }
    }
}
