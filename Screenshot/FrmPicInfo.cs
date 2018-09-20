using System;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class FrmPicInfo : Form
    {
        public FrmPicInfo(Cursor cursor)
        {
            InitializeComponent();
            this.Cursor = this.defaultCursor = cursor;


            this.pnlRect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmPicInfo_MouseMove);
            this.pnlRect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlRect_MouseDown);
            this.pnlRect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlRect_MouseUp);
        }
        private bool isDown = false;
        private Cursor defaultCursor;
        private int dx, dy;
        private Pos pos = Pos.None;
        private int w, h, x, y;

        enum Pos
        {
            None, N, E, S, W, EN, ES, WN, WS
        }

        private void FrmPicInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Owner.Close();
            }
        }

        private void FrmPicInfo_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDown)
            {
                if (e.X >= 0 && e.X <= 4)
                {//左
                    if (e.Y >= 0 && e.Y <= 4)
                    {//上
                        this.Cursor = Cursors.SizeNWSE;
                        pos = Pos.WN;
                    }
                    else if (e.Y >= this.pnlRect.Height - 4 && e.Y <= this.pnlRect.Height)
                    {//下
                        this.Cursor = Cursors.SizeNESW;
                        pos = Pos.WS;
                    }
                    else if (e.Y >= this.pnlRect.Height / 2 - 2 && e.Y <= this.pnlRect.Height / 2 + 2)
                    {//中
                        this.Cursor = Cursors.SizeWE;
                        pos = Pos.W;
                    }
                    else
                    {
                        this.Cursor = this.defaultCursor;
                        pos = Pos.None;
                    }
                }
                else if (e.X >= this.pnlRect.Width - 4 && e.X <= this.pnlRect.Width)
                {//右
                    if (e.Y >= 0 && e.Y <= 4)
                    {//上
                        this.Cursor = Cursors.SizeNESW;
                        pos = Pos.EN;
                    }
                    else if (e.Y >= this.pnlRect.Height - 4 && e.Y <= this.pnlRect.Height)
                    {//下
                        this.Cursor = Cursors.SizeNWSE;
                        pos = Pos.ES;
                    }
                    else if (e.Y >= this.pnlRect.Height / 2 - 2 && e.Y <= this.pnlRect.Height / 2 + 2)
                    {//中
                        this.Cursor = Cursors.SizeWE;
                        pos = Pos.E;
                    }
                    else
                    {
                        this.Cursor = this.defaultCursor;
                        pos = Pos.None;
                    }
                }
                else if (e.X >= this.pnlRect.Width / 2 - 2 && e.X <= this.pnlRect.Width / 2 + 2)
                {//中
                    if (e.Y >= 0 && e.Y <= 4)
                    {//上
                        this.Cursor = Cursors.SizeNS;
                        pos = Pos.N;
                    }
                    else if (e.Y >= this.pnlRect.Height - 4 && e.Y <= this.pnlRect.Height)
                    {//下
                        this.Cursor = Cursors.SizeNS;
                        pos = Pos.S;
                    }
                    else
                    {
                        this.Cursor = this.defaultCursor;
                        pos = Pos.None;
                    }
                }
                else
                {
                    this.Cursor = this.defaultCursor;
                    pos = Pos.None;
                }
            }
            else
            {
                Panel pnlPic = ((FrmPicture)this.Owner).pnlPic;
                int ex = e.X + this.pnlRect.Left + 1;
                int ey = e.Y + this.pnlRect.Top + 1;
                switch (pos)
                {
                    case Pos.None:
                        break;
                    case Pos.N://上
                        pnlPic.Top = Math.Min(ey - 1, y + h);
                        pnlPic.Height = Math.Abs(dy - ey + h);
                        break;
                    case Pos.E://右
                        pnlPic.Left = Math.Min(x, ex - 1);
                        pnlPic.Width = Math.Abs(ex - 1 - x);
                        break;
                    case Pos.S://下
                        pnlPic.Top = Math.Min(y, ey - 1);
                        pnlPic.Height = Math.Abs(ey - 1 - y);
                        break;
                    case Pos.W://左
                        pnlPic.Left = Math.Min(ex - 1, x + w);
                        pnlPic.Width = Math.Abs(dx - ex + w);
                        break;
                    case Pos.EN://右上
                        pnlPic.Left = Math.Min(x, ex - 1);
                        pnlPic.Width = Math.Abs(ex - 1 - x);
                        pnlPic.Top = Math.Min(ey - 1, y + h);
                        pnlPic.Height = Math.Abs(dy - ey + h);
                        break;
                    case Pos.ES://右下
                        pnlPic.Left = Math.Min(x, ex - 1);
                        pnlPic.Width = Math.Abs(ex - 1 - x);
                        pnlPic.Top = Math.Min(y, ey - 1);
                        pnlPic.Height = Math.Abs(ey - 1 - y);
                        break;
                    case Pos.WN://左上
                        pnlPic.Left = Math.Min(ex - 1, x + w);
                        pnlPic.Width = Math.Abs(dx - ex + w);
                        pnlPic.Top = Math.Min(ey - 1, y + h);
                        pnlPic.Height = Math.Abs(dy - ey + h);
                        break;
                    case Pos.WS://左下
                        pnlPic.Left = Math.Min(ex - 1, x + w);
                        pnlPic.Width = Math.Abs(dx - ex + w);
                        pnlPic.Top = Math.Min(y, ey - 1);
                        pnlPic.Height = Math.Abs(ey - 1 - y);
                        break;
                    default:
                        break;
                }
            }
        }

        private void pnlRect_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Cursor != this.defaultCursor)
            {
                w = pnlRect.Width - 3;
                h = pnlRect.Height - 3;
                x = pnlRect.Left + 1;
                y = pnlRect.Top + 1;
                if (e.X >= 0 && e.X <= 4)
                {
                    dx = 1 + x;
                }
                else if (e.X >= this.pnlRect.Width - 4 && e.X <= this.pnlRect.Width)
                {
                    dx = this.pnlRect.Width - 2 + x;
                }
                else if (e.X >= this.pnlRect.Width / 2 - 2 && e.X <= this.pnlRect.Width / 2 + 2)
                {
                    dx = this.pnlRect.Width / 2 + x;
                }
                if (e.Y >= 0 && e.Y <= 4)
                {
                    dy = 1 + y;
                }
                else if (e.Y >= this.pnlRect.Height - 4 && e.Y <= this.pnlRect.Height)
                {
                    dy = this.pnlRect.Height - 2 + y;
                }
                else if (e.Y >= this.pnlRect.Height / 2 - 2 && e.Y <= this.pnlRect.Height / 2 + 2)
                {
                    dy = this.pnlRect.Height / 2 + y;
                }
                isDown = true;
            }
        }

        private void pnlRect_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }
    }
}
