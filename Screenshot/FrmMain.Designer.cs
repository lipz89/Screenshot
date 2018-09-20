namespace Screenshot
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShotrKey = new System.Windows.Forms.Label();
            this.wpTop = new Screenshot.WavePicture();
            this.btnExit = new Screenshot.DWMButton();
            this.btnSet = new Screenshot.DWMButton();
            this.lblLine = new System.Windows.Forms.Label();
            this.niScreenShot = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsScreenShot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowOrHide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.wpTop)).BeginInit();
            this.cmsScreenShot.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnStart.Location = new System.Drawing.Point(113, 75);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始截图";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "本软件提供简单屏幕截图功能";
            // 
            // lblShotrKey
            // 
            this.lblShotrKey.ForeColor = System.Drawing.Color.Red;
            this.lblShotrKey.Location = new System.Drawing.Point(12, 108);
            this.lblShotrKey.Name = "lblShotrKey";
            this.lblShotrKey.Size = new System.Drawing.Size(277, 12);
            this.lblShotrKey.TabIndex = 5;
            this.lblShotrKey.Text = "截图快捷键：";
            this.lblShotrKey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // wpTop
            // 
            this.wpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.wpTop.Image = global::Screenshot.Properties.Resources.screenshot;
            this.wpTop.Location = new System.Drawing.Point(0, 0);
            this.wpTop.Name = "wpTop";
            this.wpTop.Size = new System.Drawing.Size(301, 53);
            this.wpTop.TabIndex = 8;
            this.wpTop.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(231, 169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 21);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSet.Location = new System.Drawing.Point(1, 169);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(69, 21);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "设置(&S)";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Location = new System.Drawing.Point(0, 158);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(302, 2);
            this.lblLine.TabIndex = 9;
            this.lblLine.Text = "label2";
            this.lblLine.Visible = false;
            // 
            // niScreenShot
            // 
            this.niScreenShot.ContextMenuStrip = this.cmsScreenShot;
            this.niScreenShot.Text = "notifyIcon1";
            this.niScreenShot.Visible = true;
            this.niScreenShot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niScreenShot_MouseDoubleClick);
            // 
            // cmsScreenShot
            // 
            this.cmsScreenShot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDo,
            this.tsmiShowOrHide,
            this.tsmiOption,
            this.toolStripSeparator1,
            this.tsmiExit});
            this.cmsScreenShot.Name = "cmsScreenShot";
            this.cmsScreenShot.Size = new System.Drawing.Size(142, 98);
            // 
            // tsmiDo
            // 
            this.tsmiDo.Name = "tsmiDo";
            this.tsmiDo.Size = new System.Drawing.Size(141, 22);
            this.tsmiDo.Text = "截图";
            this.tsmiDo.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tsmiShowOrHide
            // 
            this.tsmiShowOrHide.Name = "tsmiShowOrHide";
            this.tsmiShowOrHide.Size = new System.Drawing.Size(141, 22);
            this.tsmiShowOrHide.Text = "隐藏界面(&U)";
            this.tsmiShowOrHide.Click += new System.EventHandler(this.tsmiShowOrHide_Click);
            // 
            // tsmiOption
            // 
            this.tsmiOption.Name = "tsmiOption";
            this.tsmiOption.Size = new System.Drawing.Size(141, 22);
            this.tsmiOption.Text = "设置(&S)";
            this.tsmiOption.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(141, 22);
            this.tsmiExit.Text = "退出(&E)";
            this.tsmiExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(301, 191);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.wpTop);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblShotrKey);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简单截图工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.wpTop)).EndInit();
            this.cmsScreenShot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShotrKey;
        private WavePicture wpTop;
        private DWMButton btnExit;
        private DWMButton btnSet;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.NotifyIcon niScreenShot;
        private System.Windows.Forms.ContextMenuStrip cmsScreenShot;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowOrHide;
        private System.Windows.Forms.ToolStripMenuItem tsmiOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDo;
    }
}

