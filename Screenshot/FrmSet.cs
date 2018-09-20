using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Screenshot
{
    public partial class FrmSet : Form
    {
        public FrmSet()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            margin = new Margin(0, 0, 0, 30);
            if (Program.DWMState)
            {
                this.BackColor = Color.Black;
            }
            else
            {
                btnSave.Left = 11;
                btnSave.Top = btnCancel.Top = 258;
                btnCancel.Left = this.Width - btnCancel.Width - 17;
            }
            groupBox1.BackColor = groupBox2.BackColor = groupBox3.BackColor = groupBox4.BackColor = SystemColors.Control;
            btnCancel.BackColor = btnEdit.BackColor = btnEdit2.BackColor = btnOpen.BackColor = btnSave.BackColor = SystemColors.Control;
        }

        private static FrmSet frmSet;

        public static FrmSet SetForm
        {
            get
            {
                if (frmSet == null)
                    frmSet = new FrmSet();
                return frmSet;
            }
        }

        public FrmMain mainForm;
        private Margin margin;

        private void FrmSet_Load(object sender, EventArgs e)
        {
            this.lblSaveDirectory.Text = Setter.UseSet.BaseFolder;
            this.chkSaveToCliboard.Checked = Setter.UseSet.SaveToCliboard;
            this.chkSaveToDisk.Checked = Setter.UseSet.SaveToDisk;
            this.txtShortKeyScreenShot.Text = Setter.GetKeyString(Setter.UseSet.KeysScreenshot);
            this.txtShortKeyScreenShot.Tag = Setter.UseSet.KeysScreenshot;
            this.lblSendAppName.Text = Setter.UseSet.SendAppName;
            this.chkSendToApp.Checked = Setter.UseSet.SendToApp;
            groupBox2.Enabled = chkSaveToDisk.Checked;
            groupBox4.Enabled = chkSendToApp.Checked;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgFb = new FolderBrowserDialog();
            dlgFb.Description = "请选择截图保存路径。";
            dlgFb.ShowNewFolderButton = true;

            if (dlgFb.ShowDialog() == DialogResult.OK)
            {
                lblSaveDirectory.Text = dlgFb.SelectedPath;
            }
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgFb = new OpenFileDialog();
            dlgFb.Filter = "应用程序(*.exe)|*.exe";
            dlgFb.Multiselect = false;
            dlgFb.Title = "请选择截图发送软件。";

            if (dlgFb.ShowDialog() == DialogResult.OK)
            {
                lblSendAppName.Text = dlgFb.FileName;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Setter.UseSet.BaseFolder);
        }

        private void txtShortKeyScreenShot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                btnSave.PerformClick();
                return;
            }
            else
            {
                txtShortKeyScreenShot.Text = Setter.GetKeyString(e.KeyData);// e.KeyData.ToString().Replace(',', '+');
                txtShortKeyScreenShot.Tag = e.KeyData;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!chkSaveToCliboard.Checked && !chkSaveToDisk.Checked && !chkSendToApp.Checked)
            {
                MessageBox.Show(this, "请至少选择一项保存方式。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                mainForm.RegisterHotkey((Keys)txtShortKeyScreenShot.Tag);
                Setter.UseSet.BaseFolder = lblSaveDirectory.Text.Trim();
                Setter.UseSet.KeysScreenshot = (Keys)txtShortKeyScreenShot.Tag;
                Setter.UseSet.SaveToCliboard = chkSaveToCliboard.Checked;
                Setter.UseSet.SaveToDisk = chkSaveToDisk.Checked;
                Setter.UseSet.SendAppName = lblSendAppName.Text.Trim();
                Setter.UseSet.SendToApp = chkSendToApp.Checked;
                Setter.UseSet.SaveSet();
                this.Close();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Program.DWMState)
            {
                FrmMain.DwmExtendFrameIntoClientArea(this.Handle, ref margin);
                e.Graphics.FillRectangle(SystemBrushes.Control, margin.Left, margin.Top, this.ClientRectangle.Width - margin.Left - margin.Right, this.ClientRectangle.Height - margin.Top - margin.Bottom);
            }
            else
            {
                e.Graphics.Clear(SystemColors.Control);
            }
        }

        private bool PointIsOnGlass(Point p)
        {
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

        private void chkSaveToDisk_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = chkSaveToDisk.Checked;
        }

        private void chkSendApp_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = chkSendToApp.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
