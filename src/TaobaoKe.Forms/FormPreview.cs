using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaobaoKe.Forms
{
    public partial class FormPreview : Form
    {
        private static FormPreview _instance;

        public FormPreview()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(SystemInformation.WorkingArea.Width - this.Width - 18, SystemInformation.WorkingArea.Height - this.Height - 26);
        }

        public static FormPreview Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormPreview();
                return _instance;
            }
        }

        public string DocumentText
        {
            set
            {
                this.wbPreview.DocumentText = value;
            }
        }

        private void FormPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
    }
}
