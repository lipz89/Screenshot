namespace Screenshot
{
    partial class FrmPicInfo
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.pnlRect = new Screenshot.MyPanel();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInfo.Controls.Add(this.lblSize);
            this.pnlInfo.Location = new System.Drawing.Point(66, 102);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(200, 16);
            this.pnlInfo.TabIndex = 1;
            this.pnlInfo.Visible = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSize.Location = new System.Drawing.Point(2, 2);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(41, 12);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "label2";
            // 
            // pnlRect
            // 
            this.pnlRect.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.pnlRect.Location = new System.Drawing.Point(66, 145);
            this.pnlRect.Name = "pnlRect";
            this.pnlRect.Size = new System.Drawing.Size(200, 100);
            this.pnlRect.TabIndex = 2;
            this.pnlRect.Visible = false;
            // 
            // FrmPicInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlRect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPicInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmPicInfo";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPicInfo_KeyDown);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlInfo;
        public System.Windows.Forms.Label lblSize;
        public MyPanel pnlRect;
    }
}