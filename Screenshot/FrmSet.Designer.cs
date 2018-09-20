namespace Screenshot
{
    partial class FrmSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSendToApp = new System.Windows.Forms.CheckBox();
            this.chkSaveToDisk = new System.Windows.Forms.CheckBox();
            this.chkSaveToCliboard = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new Screenshot.DWMButton();
            this.btnEdit = new Screenshot.DWMButton();
            this.lblSaveDirectory = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtShortKeyScreenShot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new Screenshot.DWMButton();
            this.btnCancel = new Screenshot.DWMButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEdit2 = new Screenshot.DWMButton();
            this.lblSendAppName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkSendToApp);
            this.groupBox1.Controls.Add(this.chkSaveToDisk);
            this.groupBox1.Controls.Add(this.chkSaveToCliboard);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "双击截图设置";
            // 
            // chkSendToApp
            // 
            this.chkSendToApp.AutoSize = true;
            this.chkSendToApp.Location = new System.Drawing.Point(235, 26);
            this.chkSendToApp.Name = "chkSendToApp";
            this.chkSendToApp.Size = new System.Drawing.Size(84, 16);
            this.chkSendToApp.TabIndex = 2;
            this.chkSendToApp.Text = "发送至软件";
            this.chkSendToApp.UseVisualStyleBackColor = true;
            this.chkSendToApp.CheckedChanged += new System.EventHandler(this.chkSendApp_CheckedChanged);
            // 
            // chkSaveToDisk
            // 
            this.chkSaveToDisk.AutoSize = true;
            this.chkSaveToDisk.Location = new System.Drawing.Point(133, 26);
            this.chkSaveToDisk.Name = "chkSaveToDisk";
            this.chkSaveToDisk.Size = new System.Drawing.Size(84, 16);
            this.chkSaveToDisk.TabIndex = 1;
            this.chkSaveToDisk.Text = "保存至硬盘";
            this.chkSaveToDisk.UseVisualStyleBackColor = true;
            this.chkSaveToDisk.CheckedChanged += new System.EventHandler(this.chkSaveToDisk_CheckedChanged);
            // 
            // chkSaveToCliboard
            // 
            this.chkSaveToCliboard.AutoSize = true;
            this.chkSaveToCliboard.Location = new System.Drawing.Point(19, 26);
            this.chkSaveToCliboard.Name = "chkSaveToCliboard";
            this.chkSaveToCliboard.Size = new System.Drawing.Size(96, 16);
            this.chkSaveToCliboard.TabIndex = 0;
            this.chkSaveToCliboard.Text = "保存至剪切板";
            this.chkSaveToCliboard.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.lblSaveDirectory);
            this.groupBox2.Location = new System.Drawing.Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存至硬盘";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOpen.Location = new System.Drawing.Point(259, 23);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(57, 21);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "打开(&O)";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEdit.Location = new System.Drawing.Point(196, 23);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 21);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改(&D)";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblSaveDirectory
            // 
            this.lblSaveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaveDirectory.AutoEllipsis = true;
            this.lblSaveDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaveDirectory.Location = new System.Drawing.Point(19, 24);
            this.lblSaveDirectory.Name = "lblSaveDirectory";
            this.lblSaveDirectory.Size = new System.Drawing.Size(171, 18);
            this.lblSaveDirectory.TabIndex = 0;
            this.lblSaveDirectory.Text = "label1";
            this.lblSaveDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtShortKeyScreenShot);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "全局热键设置";
            // 
            // txtShortKeyScreenShot
            // 
            this.txtShortKeyScreenShot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtShortKeyScreenShot.BackColor = System.Drawing.SystemColors.Window;
            this.txtShortKeyScreenShot.Location = new System.Drawing.Point(107, 23);
            this.txtShortKeyScreenShot.Name = "txtShortKeyScreenShot";
            this.txtShortKeyScreenShot.ReadOnly = true;
            this.txtShortKeyScreenShot.Size = new System.Drawing.Size(175, 21);
            this.txtShortKeyScreenShot.TabIndex = 1;
            this.txtShortKeyScreenShot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortKeyScreenShot_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "截图";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Location = new System.Drawing.Point(1, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnEdit2);
            this.groupBox4.Controls.Add(this.lblSendAppName);
            this.groupBox4.Location = new System.Drawing.Point(12, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 56);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "发送至软件";
            // 
            // btnEdit2
            // 
            this.btnEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEdit2.Location = new System.Drawing.Point(259, 23);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(57, 21);
            this.btnEdit2.TabIndex = 5;
            this.btnEdit2.Text = "修改(&A)";
            this.btnEdit2.UseVisualStyleBackColor = false;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
            // 
            // lblSendAppName
            // 
            this.lblSendAppName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSendAppName.AutoEllipsis = true;
            this.lblSendAppName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSendAppName.Location = new System.Drawing.Point(19, 24);
            this.lblSendAppName.Name = "lblSendAppName";
            this.lblSendAppName.Size = new System.Drawing.Size(234, 18);
            this.lblSendAppName.TabIndex = 0;
            this.lblSendAppName.Text = "label1";
            this.lblSendAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSet
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(353, 289);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FrmSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSaveToDisk;
        private System.Windows.Forms.CheckBox chkSaveToCliboard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSaveDirectory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShortKeyScreenShot;
        private DWMButton btnOpen;
        private DWMButton btnEdit;
        private DWMButton btnSave;
        private DWMButton btnCancel;
        private System.Windows.Forms.CheckBox chkSendToApp;
        private System.Windows.Forms.GroupBox groupBox4;
        private DWMButton btnEdit2;
        private System.Windows.Forms.Label lblSendAppName;
    }
}