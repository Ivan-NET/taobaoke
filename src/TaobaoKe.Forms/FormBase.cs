using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TaobaoKe.Forms.Properties;

namespace TaobaoKe.Forms
{
    [ComVisible(true)]
    public class FormBase : Form
    {
        public FormBase()
        {
            this.Icon = Resources.form_icon;
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        public void cbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                e.Graphics.DrawString(((ComboBox)sender).Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
            }
        }
    }
}
