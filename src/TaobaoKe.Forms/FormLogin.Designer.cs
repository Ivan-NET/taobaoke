namespace TaobaoKe.Forms
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboxAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.chkRememberPwd = new System.Windows.Forms.CheckBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.lnkRetrievePwd = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐号";
            // 
            // cboxAccount
            // 
            this.cboxAccount.FormattingEnabled = true;
            this.cboxAccount.Location = new System.Drawing.Point(142, 57);
            this.cboxAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboxAccount.Name = "cboxAccount";
            this.cboxAccount.Size = new System.Drawing.Size(160, 27);
            this.cboxAccount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(142, 111);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(160, 25);
            this.txtPwd.TabIndex = 3;
            // 
            // chkRememberPwd
            // 
            this.chkRememberPwd.AutoSize = true;
            this.chkRememberPwd.ForeColor = System.Drawing.Color.DimGray;
            this.chkRememberPwd.Location = new System.Drawing.Point(142, 165);
            this.chkRememberPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRememberPwd.Name = "chkRememberPwd";
            this.chkRememberPwd.Size = new System.Drawing.Size(84, 24);
            this.chkRememberPwd.TabIndex = 4;
            this.chkRememberPwd.Text = "记住密码";
            this.chkRememberPwd.UseVisualStyleBackColor = true;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.ForeColor = System.Drawing.Color.DimGray;
            this.chkAutoLogin.Location = new System.Drawing.Point(287, 165);
            this.chkAutoLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(84, 24);
            this.chkAutoLogin.TabIndex = 4;
            this.chkAutoLogin.Text = "自动登录";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(142, 211);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(114, 36);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录(&L)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkRegister
            // 
            this.lnkRegister.AutoSize = true;
            this.lnkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkRegister.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkRegister.Location = new System.Drawing.Point(336, 62);
            this.lnkRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(65, 20);
            this.lnkRegister.TabIndex = 6;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "注册帐号";
            // 
            // lnkRetrievePwd
            // 
            this.lnkRetrievePwd.AutoSize = true;
            this.lnkRetrievePwd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkRetrievePwd.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkRetrievePwd.Location = new System.Drawing.Point(336, 114);
            this.lnkRetrievePwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkRetrievePwd.Name = "lnkRetrievePwd";
            this.lnkRetrievePwd.Size = new System.Drawing.Size(65, 20);
            this.lnkRetrievePwd.TabIndex = 6;
            this.lnkRetrievePwd.TabStop = true;
            this.lnkRetrievePwd.Text = "找回密码";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.lnkRetrievePwd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lnkRegister);
            this.panel1.Controls.Add(this.cboxAccount);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkAutoLogin);
            this.panel1.Controls.Add(this.chkRememberPwd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 268);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 158);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ImageLocation = "http://oivfje1d5.bkt.clouddn.com/login_banner.gif";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(462, 158);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 426);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.CheckBox chkRememberPwd;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.LinkLabel lnkRetrievePwd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}