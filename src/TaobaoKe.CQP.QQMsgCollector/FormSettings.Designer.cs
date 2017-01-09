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
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.lblServerId = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(265, 64);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(150, 31);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "测试与主程序的连接(&T)";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(53, 44);
            this.lblServerStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(29, 12);
            this.lblServerStatus.TabIndex = 1;
            this.lblServerStatus.Text = "状态";
            // 
            // lblClientStatus
            // 
            this.lblClientStatus.AutoSize = true;
            this.lblClientStatus.Location = new System.Drawing.Point(53, 94);
            this.lblClientStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(29, 12);
            this.lblClientStatus.TabIndex = 1;
            this.lblClientStatus.Text = "状态";
            // 
            // lblServerId
            // 
            this.lblServerId.AutoSize = true;
            this.lblServerId.Location = new System.Drawing.Point(53, 23);
            this.lblServerId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerId.Name = "lblServerId";
            this.lblServerId.Size = new System.Drawing.Size(53, 12);
            this.lblServerId.TabIndex = 1;
            this.lblServerId.Text = "ServerId";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Location = new System.Drawing.Point(53, 73);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(53, 12);
            this.lblClientId.TabIndex = 1;
            this.lblClientId.Text = "ClientId";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 124);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.lblClientStatus);
            this.Controls.Add(this.lblServerId);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.btnTestConnection);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSettings";
            this.Text = "QQ消息采集设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.Label lblServerId;
        private System.Windows.Forms.Label lblClientId;
    }
}