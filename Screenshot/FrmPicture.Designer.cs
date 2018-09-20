namespace Screenshot
{
    partial class FrmPicture
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
            this.pnlPic = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlPic
            // 
            this.pnlPic.BackColor = System.Drawing.Color.White;
            this.pnlPic.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlPic.Location = new System.Drawing.Point(48, 34);
            this.pnlPic.Name = "pnlPic";
            this.pnlPic.Size = new System.Drawing.Size(200, 100);
            this.pnlPic.TabIndex = 0;
            this.pnlPic.LocationChanged += new System.EventHandler(this.pnlPic_LocationChanged);
            this.pnlPic.SizeChanged += new System.EventHandler(this.pnlPic_SizeChanged);
            this.pnlPic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlPic_MouseDoubleClick);
            this.pnlPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPic_MouseDown);
            this.pnlPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPic_MouseMove);
            this.pnlPic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlPic_MouseUp);
            // 
            // FrmPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(165, 122);
            this.Controls.Add(this.pnlPic);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPicture";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmPicture";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPicture_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmPicture_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmPicture_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmPicture_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlPic;



    }
}