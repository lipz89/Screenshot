using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class FrmPicture : Form
    {
        /// <summary>
        /// 加载光标
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        private static Cursor ThisCur;

        /// <summary>
        /// 静态构造函数，加载光标
        /// </summary>
        static FrmPicture()
        {
            string tmp = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\tmpShot.cur";
            byte[] cursorbuffer = Properties.Resources.cur_arrow;
            FileStream fileStream = new FileStream(tmp, FileMode.OpenOrCreate);
            fileStream.Write(cursorbuffer, 0, cursorbuffer.Length);
            fileStream.Close();
            ThisCur = new Cursor(LoadCursorFromFile(tmp));
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        public FrmPicture()
        {
            InitializeComponent();
            this.pnlPic.Size = new Size(0, 0);
            frmInfo = new FrmPicInfo(ThisCur);
            frmInfo.Show(this);
            this.Cursor = ThisCur;

            frmInfo.Bounds = this.Bounds = Screen.PrimaryScreen.Bounds;
            if (Setter.UseSet.StopScreen)
            {
                this.BackgroundImage = CopyScreen();
                this.Opacity = 1;
            }
            else
            {
                this.Opacity = 0.1;
            }
        }

        private int mx, my, dx, dy;
        private bool frmDown = false;
        private bool pnlDown = false;
        private FrmPicInfo frmInfo;
        /// <summary>
        /// 获取截图区域的图像
        /// </summary>
        /// <returns></returns>
        private Image GetImage()
        {
            frmInfo.pnlRect.Visible = false;
            frmInfo.pnlInfo.Visible = false;
            if (this.pnlPic.Width > 0 && this.pnlPic.Height > 0)
            {
                Bitmap bmp = new Bitmap(this.pnlPic.Width, this.pnlPic.Height);
                Graphics g1 = Graphics.FromImage(bmp);
                g1.Clear(Color.Transparent);
                g1.CopyFromScreen(this.pnlPic.Location, new Point(0, 0), bmp.Size);
                return bmp;
            }
            return null;
        }
        /// <summary>
        /// 拷贝屏幕图像
        /// </summary>
        /// <returns></returns>
        private Image CopyScreen()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g1 = Graphics.FromImage(bmp);
            g1.Clear(Color.Transparent);
            g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
            bmp.Save("screen.jpg");
            return bmp;
        }
        /// <summary>
        /// 在截图过程中的鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (frmDown)
            {
                //SHIFT按键按下，截图区域为正方形
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    int dsy = Math.Abs(e.Y - dy);
                    this.pnlPic.Size = new Size(dsy, dsy);
                    this.pnlPic.Location = new Point(e.X < dx ? dx - dsy : dx, Math.Min(e.Y, dy));
                }
                //否则为普通长方形
                else
                {
                    this.pnlPic.Size = new Size(Math.Abs(e.X - dx), Math.Abs(e.Y - dy));
                    this.pnlPic.Location = new Point(Math.Min(e.X, dx), Math.Min(e.Y, dy));
                }
            }
        }
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPicture_MouseDown(object sender, MouseEventArgs e)
        {
            //如果是左键按下，初始化信息窗体
            if (e.Button == MouseButtons.Left)
            {
                dx = e.X;
                dy = e.Y;
                this.pnlPic.Size = new Size(0, 0);
                frmDown = true;
                pnlPic.Location = e.Location;
                int y = this.pnlPic.Top < frmInfo.pnlInfo.Height + 2 ? this.pnlPic.Top + 2 : this.pnlPic.Top - frmInfo.pnlInfo.Height - 2;
                frmInfo.pnlInfo.Location = new Point(this.pnlPic.Left + 2, y);
                frmInfo.pnlInfo.Visible = true;
                frmInfo.pnlRect.Location = new Point(this.pnlPic.Left - 1, this.pnlPic.Top - 1);
                frmInfo.pnlRect.Size = new Size(1, 1);
                frmInfo.pnlRect.Visible = true;
            }
            //右键按下，取消截图
            else if (e.Button == MouseButtons.Right)
            {
                if (frmInfo.pnlInfo.Visible)
                {
                    frmInfo.pnlInfo.Visible = false;
                    frmInfo.pnlRect.Visible = false;
                    this.pnlPic.Size = new Size(0, 0);
                }
                else
                {
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 鼠标按键释放，结束截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPicture_MouseUp(object sender, MouseEventArgs e)
        {
            frmDown = false;
            frmInfo.Activate();
        }
        /// <summary>
        /// 在截图区域移动状态中的鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlDown)
            {
                int x = Math.Min(Math.Max(0, this.pnlPic.Left + e.X - mx), this.Width - this.pnlPic.Width);
                int y = Math.Min(Math.Max(0, this.pnlPic.Top + e.Y - my), this.Height - this.pnlPic.Height);
                pnlPic.Location = new Point(x, y);
            }
        }
        /// <summary>
        /// 截图区域中的鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPic_MouseDown(object sender, MouseEventArgs e)
        {
            //左键按下，开始移动
            if (e.Button == MouseButtons.Left)
            {
                pnlDown = true;
                mx = e.X;
                my = e.Y;
            }
            //右键按下，放弃截图
            else if (e.Button == MouseButtons.Right)
            {
                if (frmInfo.pnlInfo.Visible)
                {
                    frmInfo.pnlInfo.Visible = false;
                    frmInfo.pnlRect.Visible = false;
                    this.pnlPic.Size = new Size(0, 0);
                }
                else
                {
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 鼠标释放，结束截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPic_MouseUp(object sender, MouseEventArgs e)
        {
            pnlDown = false;
            frmInfo.Activate();
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose(true);
            if (!frmInfo.IsDisposed)
            {
                frmInfo.Dispose();
            }
        }
        /// <summary>
        /// 鼠标双击截图区域，处理图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Image img = GetImage();
            if (img != null)
            {
                //存放在硬盘
                if (Setter.UseSet.SaveToDisk)
                {
                    string fileName = "img_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    img.Save(Setter.UseSet.BaseFolder + "\\" + fileName);
                }
                //存放在剪切板
                if (Setter.UseSet.SaveToCliboard)
                {
                    Clipboard.SetImage(img);
                }
                //发送至软件
                if (Setter.UseSet.SendToApp)
                {
                    string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\img_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    img.Save(fileName);
                    Process.Start(Setter.UseSet.SendAppName, "\"" + fileName + "\"");
                }
            }
            img.Dispose();
            this.Close();
        }
        /// <summary>
        /// 截图区域位置移动，截图信息跟随移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPic_LocationChanged(object sender, EventArgs e)
        {
            if (frmInfo != null)
            {
                int y = this.pnlPic.Top < frmInfo.pnlInfo.Height + 2 ? this.pnlPic.Top + 2 : this.pnlPic.Top - frmInfo.pnlInfo.Height - 2;
                frmInfo.pnlInfo.Location = new Point(this.pnlPic.Left + 2, y);
                frmInfo.pnlRect.Location = new Point(this.pnlPic.Left - 1, this.pnlPic.Top - 1);
            }
        }
        /// <summary>
        /// 截图区域大小改变，截图信息跟随改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlPic_SizeChanged(object sender, EventArgs e)
        {
            if (frmInfo != null)
            {
                frmInfo.lblSize.Text = string.Format("{0} * {1}", this.pnlPic.Width, this.pnlPic.Height);
                frmInfo.pnlRect.Size = new Size(this.pnlPic.Width + 3, this.pnlPic.Height + 3);
                int y = this.pnlPic.Top < frmInfo.pnlInfo.Height + 2 ? this.pnlPic.Top + 2 : this.pnlPic.Top - frmInfo.pnlInfo.Height - 2;
                frmInfo.pnlInfo.Location = new Point(this.pnlPic.Left + 2, y);
                frmInfo.pnlRect.Location = new Point(this.pnlPic.Left - 1, this.pnlPic.Top - 1);
            }
        }
    }
}
