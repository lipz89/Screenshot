using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            margin = new Margin(0, 0, 0, 30);
            if (Program.DWMState)
            {
                DwmExtendFrameIntoClientArea(this.Handle, ref margin);
                this.BackColor = Color.Black;
                lblShotrKey.BackColor = label1.BackColor = bColor;
            }
            else
            {
                pLbl.Y = 169;
                btnExit.Location = new Point(223, 164);
                btnSet.Location = new Point(8, 164);
                lblLine.Visible = true;
                this.BackColor = lblShotrKey.BackColor = label1.BackColor = bColor;
            }
            this.Text = MutexOnly.ApplicationName;
            niScreenShot.Icon = this.Icon;
            niScreenShot.Text = this.Text;

            FrmSet.SetForm.mainForm = this;
        }

        private void TransparentToShowForm()
        {
            for (double d = 0.1; d < 1.01; d += 0.05)
            {
                this.Opacity = d;
                Application.DoEvents();
                System.Threading.Thread.Sleep(30);
            }
        }

        private void TransparentToHideForm()
        {
            for (double d = this.Opacity; d > 0.1; d -= 0.05)
            {
                this.Opacity = d;
                Application.DoEvents();
                System.Threading.Thread.Sleep(30);
            }
        }

        private Point pLbl = new Point(97, 174);

        private Margin margin;
        private int keysscreenshot;
        private Hotkey hotkey;
        private Point LastLocation, HideLocation = new Point(-500, 0);
        private Color bColor = Color.FromArgb(215, 228, 242);

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Setter.LoadSet();

            Keys key = Setter.UseSet.KeysScreenshot;
            lblShotrKey.Text = "截图快捷键：" + Setter.GetKeyString(key);

            hotkey = new Hotkey(this.Handle);
            RegisterHotkey(key);
            hotkey.OnHotkey += new HotkeyEventHandler(OnHotkey);
            tsmiDo.ShortcutKeys = key;
            LastLocation = Location;
            this.Invalidate();
            TransparentToShowForm();
        }

        public void RegisterHotkey(Keys key)
        {
            hotkey.UnregisterHotkeys();

            keysscreenshot = hotkey.RegisterHotkey(key);   //定义快键(ALT + SHIFT + A)
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            FrmSet.SetForm.ShowDialog();
            lblShotrKey.Text = "截图快捷键：" + Setter.GetKeyString(Setter.UseSet.KeysScreenshot);
            tsmiDo.ShortcutKeys = Setter.UseSet.KeysScreenshot;
            btnStart.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f is FrmPicture)
                {
                    flag = true;
                    return;
                }
            }
            if (!flag)
            {
                TransparentToHideForm();
                Location = HideLocation;
                new FrmPicture().Show();
            }
        }

        private void tsmiShowOrHide_Click(object sender, EventArgs e)
        {
            if (Location == HideLocation)
            {
                Location = LastLocation;
                this.Activate();
                TransparentToShowForm();
            }
            else
            {
                TransparentToHideForm();
                Location = HideLocation;
            }
        }

        private void niScreenShot_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsmiShowOrHide.PerformClick();
        }

        public void OnHotkey(int HotkeyID)
        {
            if (HotkeyID == keysscreenshot)
            {
                btnStart.PerformClick();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Program.DWMState)
            {
                e.Graphics.FillRectangle(new SolidBrush(bColor), margin.Left, margin.Top, this.ClientRectangle.Width - margin.Left - margin.Right, this.ClientRectangle.Height - margin.Top - margin.Bottom);
            }
            else
            {
                e.Graphics.Clear(bColor);
            }
            using (Image image = new Bitmap(105, 12))
            {
                using (Graphics gp = Graphics.FromImage(image))
                {
                    gp.DrawString("李小虾 2012-04-13", this.Font, new SolidBrush(this.ForeColor), new Point(0, 0));
                }
                e.Graphics.DrawImage(image, pLbl);
            }
        }

        private bool PointIsOnGlass(Point p)
        {
            if (margin.Left < 0 || margin.Right < 0 || margin.Top < 0 || margin.Bottom < 0)
                return true;
            Rectangle rect = new Rectangle(margin.Left, margin.Top, this.ClientRectangle.Width - margin.Left - margin.Right, this.ClientRectangle.Height - margin.Top - margin.Bottom);
            return !rect.Contains(p);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 0x01;
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (HTCLIENT == m.Result.ToInt32())
                    {
                        Point p = new Point();
                        p.X = (m.LParam.ToInt32() & 0xFFFF);// low order word
                        p.Y = (m.LParam.ToInt32() >> 16); // hi order word
                        p = PointToClient(p);
                        if (PointIsOnGlass(p))
                            m.Result = new IntPtr(2);
                    }
                    break;
            }
        }

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margin pMarInset);

        private void FrmMain_Move(object sender, EventArgs e)
        {
            tsmiShowOrHide.Text = Location == LastLocation ? "隐藏界面(&U)" : "显示界面(&U)";
            if (Location == LastLocation)
                this.Activate();
            else if (Location != HideLocation)
                LastLocation = Location;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            TransparentToHideForm();
            switch (e.CloseReason)
            {
                case CloseReason.FormOwnerClosing:
                case CloseReason.MdiFormClosing:
                case CloseReason.UserClosing:
                    Location = HideLocation;
                    e.Cancel = true;
                    break;
                case CloseReason.WindowsShutDown:
                case CloseReason.ApplicationExitCall:
                case CloseReason.None:
                case CloseReason.TaskManagerClosing:
                default:
                    break;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Margin
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;

        public Margin(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
        }
    }
}
