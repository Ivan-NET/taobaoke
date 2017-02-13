using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaobaoKe.Forms.Settings;

namespace TaobaoKe.Forms
{
    public partial class FormAlimamaLogin : FormBase
    {
        private readonly string _account;
        private readonly string _password;
        private static readonly int offset = 20;
        private bool logging = false;
        private bool logged = false;
        private object loggingLock = new object();
        private byte loggingCountDown = 0;
        private bool retried = false;

        public FormAlimamaLogin(string account, string password)
        {
            _account = account;
            _password = password;
            if(string.IsNullOrEmpty(_account))
                throw new Exception("淘宝帐号不允许为空");
            if (string.IsNullOrEmpty(_password))
                throw new Exception("淘宝密码不允许为空");
            InitializeComponent();
            this.webBrowserLogin.ScriptErrorsSuppressed = true;
            this.tslnkRetry.Visible = false;
        }

        public string TbToken { get; private set; }

        public string Cookie { get; private set; }

        private void FormAlimamaLogin_MouseMove(object sender, MouseEventArgs e)
        {
            //this.webBrowser1.Location
            string s = string.Format("WebBrowse:({0},{1}), Mouse:({2},{3}), ({4},{5})"
                , this.webBrowserLogin.Location.X, this.webBrowserLogin.Location.Y
                , e.X, e.Y
                , e.X - this.webBrowserLogin.Location.X, e.Y - this.webBrowserLogin.Location.Y);
            this.statusAlimamaLogin.Text = s;
        }

        private void FormAlimamaLogin_Load(object sender, EventArgs e)
        {
            // 跳转到登录页面
            string url = "https://login.taobao.com/member/login.jhtml?style=mini&from=alimama&redirectURL=http%3A%2F%2Flogin.taobao.com%2Fmember%2Ftaobaoke%2Flogin.htm%3Fis_login%3d1&full_redirect=true&disableQuickLogin=true";
            // 设置帐号
            InternetSetCookie(url, "lgc", _account);
            InternetSetCookie(url, "tracknick", _account);
            webBrowserLogin.Navigate(url);
        }

        private void webBrowserLogin_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBrowserLogin.Url.Host == "login.taobao.com")
            {
                if (!logging && !logged)
                {
                    this.statusAlimamaLogin.Text = "登录页面已打开，准备自动登录";
                    StartLogging();
                }
                else if (logged)
                {
                    if (!retried)
                    {
                        this.statusAlimamaLogin.Text = "登录失败，准备重试";
                        StartLogging();
                        retried = true;
                    }
                    else
                    {
                        this.statusAlimamaLogin.Text = "登录失败";
                        this.tslnkRetry.Visible = true;
                    }
                }
            }
            else if (this.webBrowserLogin.Url.Host == "www.alimama.com")
            {
                Cookie = GetCookies("http://www.alimama.com");
                CookieCollection c = GetCookieFromString(Cookie);
                Cookie cookieTbToken = c["_tb_token_"];
                TbToken = cookieTbToken == null ? null : cookieTbToken.Value;
                if (TbToken != null)
                {
                    this.statusAlimamaLogin.Text = "登录成功";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void StartLogging()
        {
            lock (loggingLock)
            {
                logging = true;
                loggingCountDown = 3;
                retried = false;
                timerTick.Start();
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (logging && loggingCountDown > 0)
            {
                this.statusAlimamaLogin.Text = loggingCountDown + "秒后开始自动登录";
                loggingCountDown--;
                if (loggingCountDown == 0)
                {
                    this.bgwSimulateDoWork.RunWorkerAsync();
                    timerTick.Stop();
                }
            }
        }

        private void bgwSimulateDoWork_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (loggingLock)
            {
                this.Invoke((EventHandler)delegate
                {
                    DoLogin();
                    logging = false;
                    logged = true;
                });
            }
        }

        private void tslnkRetry_Click(object sender, EventArgs e)
        {
            StartLogging();
            this.tslnkRetry.Visible = false;
        }

        private void DoLogin()
        {
            this.statusAlimamaLogin.Text = "自动登录中";
            // 密码输入框
            IHTMLDocument2 document = webBrowserLogin.Document.DomDocument as IHTMLDocument2;
            IHTMLElement2 element = this.webBrowserLogin.Document.GetElementById("TPL_password_1").DomElement as IHTMLElement2;
            var rec = element.getBoundingClientRect();
            Point p1 = this.webBrowserLogin.PointToClient(new Point(rec.left, rec.top));
            Point p = this.webBrowserLogin.PointToScreen(new Point(0, 0));
            SetCursorPos(p.X + rec.left + offset, p.Y + rec.top + offset);

            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, 0);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, 0);

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            SendKeys.Send(_password);

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            // 滑块
            var ele3 = this.webBrowserLogin.Document.GetElementById("nc_1__scale_text");
            if (ele3 != null)
            {
                IHTMLElement2 element3 = ele3.DomElement as IHTMLElement2;
                var rec3 = element3.getBoundingClientRect();
                SetCursorPos(p.X + rec3.left + offset, p.Y + rec3.top + offset);

                System.Threading.Thread.Sleep(500);
                Application.DoEvents();

                mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, 0);
                for (int i = 10; i < element3.clientWidth; i = i + 10)
                {
                    mouse_event(MouseEventFlag.Move, 10, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    Application.DoEvents();
                }
                mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, 0);
            }

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            // 点击登录
            IHTMLElement2 element2 = this.webBrowserLogin.Document.GetElementById("J_SubmitStatic").DomElement as IHTMLElement2;
            var rec2 = element2.getBoundingClientRect();
            SetCursorPos(p.X + rec2.left + offset, p.Y + rec2.top + 20);

            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, 0);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, 0);

            Application.DoEvents();
        }

        #region 私有方法

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, int dwExtraInfo);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        private static string GetCookies(string url)
        {
            uint datasize = 1024;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;

                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }

        private CookieCollection GetCookieFromString(string cookieString)
        {
            //排除空字符串
            if (string.IsNullOrWhiteSpace(cookieString))
            {
                return null;
            }
            CookieCollection cookieCollection = new CookieCollection();
            //先简化Cookie
            cookieString = GetSmallCookie(cookieString);
            //将Cookie字符串以,;分开，生成一个字符数组，并删除里面的空项
            string[] list = cookieString.ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in list)
            {
                string[] cookie = item.ToString().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (cookie.Length == 2)
                {
                    cookieCollection.Add(new Cookie() { Name = cookie[0].Trim(), Value = cookie[1].Trim() });
                }
            }
            return cookieCollection;
        }

        /// <summary>
        /// 根据字符生成Cookie和精简串，将排除path,expires,domain以及重复项
        /// </summary>
        /// <param name="cookieString">Cookie字符串</param>
        /// <returns>精简串</returns>
        internal static string GetSmallCookie(string cookieString)
        {
            if (string.IsNullOrWhiteSpace(cookieString))
            {
                return string.Empty;
            }
            List<string> cookielist = new List<string>();
            //将Cookie字符串以,;分开，生成一个字符数组，并删除里面的空项
            string[] list = cookieString.ToString().Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in list)
            {
                string itemcookie = item.ToLower().Trim().Replace("\r\n", string.Empty).Replace("\n", string.Empty);
                //排除空字符串
                if (string.IsNullOrWhiteSpace(itemcookie)) continue;
                //排除不存在=号的Cookie项
                if (!itemcookie.Contains("=")) continue;
                //排除path项
                if (itemcookie.Contains("path=")) continue;
                //排除expires项
                if (itemcookie.Contains("expires=")) continue;
                //排除domain项
                if (itemcookie.Contains("domain=")) continue;
                //排除重复项
                if (cookielist.Contains(item)) continue;

                //对接Cookie基本的Key和Value串
                cookielist.Add(string.Format("{0};", item));
            }
            return string.Join(";", cookielist);
        }

        #endregion
    }

    [Flags]
    enum MouseEventFlag : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        Wheel = 0x0800,
        VirtualDesk = 0x4000,
        Absolute = 0x8000
    }
}
