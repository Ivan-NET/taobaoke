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
            this.label1.Location = new System.Drawing.Point(102, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐号";
            // 
            // cboxAccount
            // 
            this.cboxAccount.FormattingEnabled = true;
            this.cboxAccount.Location = new System.Drawing.Point(284, 59);
            this.cboxAccount.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.cboxAccount.Name = "cboxAccount";
            this.cboxAccount.Size = new System.Drawing.Size(353, 43);
            this.cboxAccount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(284, 147);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(353, 43);
            this.txtPwd.TabIndex = 3;
            // 
            // chkRememberPwd
            // 
            this.chkRememberPwd.AutoSize = true;
            this.chkRememberPwd.ForeColor = System.Drawing.Color.DimGray;
            this.chkRememberPwd.Location = new System.Drawing.Point(284, 218);
            this.chkRememberPwd.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.chkRememberPwd.Name = "chkRememberPwd";
            this.chkRememberPwd.Size = new System.Drawing.Size(155, 39);
            this.chkRememberPwd.TabIndex = 4;
            this.chkRememberPwd.Text = "记住密码";
            this.chkRememberPwd.UseVisualStyleBackColor = true;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.ForeColor = System.Drawing.Color.DimGray;
            this.chkAutoLogin.Location = new System.Drawing.Point(482, 218);
            this.chkAutoLogin.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(155, 39);
            this.chkAutoLogin.TabIndex = 4;
            this.chkAutoLogin.Text = "自动登录";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(284, 308);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(228, 66);
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
            this.lnkRegister.Location = new System.Drawing.Point(672, 62);
            this.lnkRegister.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(123, 35);
            this.lnkRegister.TabIndex = 6;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "注册帐号";
            // 
            // lnkRetrievePwd
            // 
            this.lnkRetrievePwd.AutoSize = true;
            this.lnkRetrievePwd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkRetrievePwd.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkRetrievePwd.Location = new System.Drawing.Point(672, 150);
            this.lnkRetrievePwd.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lnkRetrievePwd.Name = "lnkRetrievePwd";
            this.lnkRetrievePwd.Size = new System.Drawing.Size(123, 35);
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
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 442);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 363);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::TaobaoKe.Forms.Properties.Resources.login_banner;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(924, 363);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 805);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
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