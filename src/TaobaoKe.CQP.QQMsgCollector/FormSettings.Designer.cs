namespace Rap.CQP.QQMsgCollector
{
    partial class FormSettings
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.lblServerId = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQQGroupNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(530, 128);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(300, 62);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新(&S)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(36, 65);
            this.lblServerStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(58, 24);
            this.lblServerStatus.TabIndex = 1;
            this.lblServerStatus.Text = "状态";
            // 
            // lblClientStatus
            // 
            this.lblClientStatus.AutoSize = true;
            this.lblClientStatus.Location = new System.Drawing.Point(36, 157);
            this.lblClientStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(58, 24);
            this.lblClientStatus.TabIndex = 1;
            this.lblClientStatus.Text = "状态";
            // 
            // lblServerId
            // 
            this.lblServerId.AutoSize = true;
            this.lblServerId.Location = new System.Drawing.Point(36, 23);
            this.lblServerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerId.Name = "lblServerId";
            this.lblServerId.Size = new System.Drawing.Size(106, 24);
            this.lblServerId.TabIndex = 1;
            this.lblServerId.Text = "ServerId";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(36, 113);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(106, 24);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "ClientId";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(530, 46);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(300, 62);
            this.btnStart.TabIndex = 0;
            this.btnStart.Tag = "";
            this.btnStart.Text = "启动(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "监听QQ";
            // 
            // lblQQGroupNo
            // 
            this.lblQQGroupNo.AutoSize = true;
            this.lblQQGroupNo.Location = new System.Drawing.Point(149, 203);
            this.lblQQGroupNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQQGroupNo.Name = "lblQQGroupNo";
            this.lblQQGroupNo.Size = new System.Drawing.Size(154, 24);
            this.lblQQGroupNo.TabIndex = 1;
            this.lblQQGroupNo.Text = "lblQQGroupNo";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 248);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.lblClientStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblServerId);
            this.Controls.Add(this.lblQQGroupNo);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRefresh);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSettings";
            this.Text = "QQ消息采集设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.Label lblServerId;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQQGroupNo;
    }
}