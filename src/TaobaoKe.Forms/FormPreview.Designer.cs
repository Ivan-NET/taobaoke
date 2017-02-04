namespace TaobaoKe.Forms
{
    partial class FormPreview
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
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbPreview
            // 
            this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPreview.Location = new System.Drawing.Point(0, 0);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.Size = new System.Drawing.Size(574, 729);
            this.wbPreview.TabIndex = 0;
            // 
            // FormPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(574, 729);
            this.Controls.Add(this.wbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormPreview";
            this.Text = "预览";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPreview_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPreview;
    }
}