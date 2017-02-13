namespace TaobaoKe.Forms
{
    partial class FormAlimamaLogin
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
            this.components = new System.ComponentModel.Container();
            this.webBrowserLogin = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusAlimamaLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwSimulateDoWork = new System.ComponentModel.BackgroundWorker();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserLogin
            // 
            this.webBrowserLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserLogin.Location = new System.Drawing.Point(0, 0);
            this.webBrowserLogin.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLogin.Name = "webBrowserLogin";
            this.webBrowserLogin.Size = new System.Drawing.Size(773, 779);
            this.webBrowserLogin.TabIndex = 0;
            this.webBrowserLogin.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserLogin.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserLogin_DocumentCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusAlimamaLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 779);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(773, 36);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusAlimamaLogin
            // 
            this.statusAlimamaLogin.Name = "statusAlimamaLogin";
            this.statusAlimamaLogin.Size = new System.Drawing.Size(206, 31);
            this.statusAlimamaLogin.Text = "正在打开登录页面";
            // 
            // bgwSimulateDoWork
            // 
            this.bgwSimulateDoWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSimulateDoWork_DoWork);
            // 
            // timerTick
            // 
            this.timerTick.Interval = 1000;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // FormAlimamaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 815);
            this.Controls.Add(this.webBrowserLogin);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAlimamaLogin";
            this.Text = "FormAlimamaLogin";
            this.Load += new System.EventHandler(this.FormAlimamaLogin_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserLogin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusAlimamaLogin;
        private System.ComponentModel.BackgroundWorker bgwSimulateDoWork;
        private System.Windows.Forms.Timer timerTick;
    }
}