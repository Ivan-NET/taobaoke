using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TaobaoKe.Common.Models;
using TaobaoKe.Core.IPC;
using TaobaoKe.Core.Log;
using TaobaoKe.Core.Util;
using TaobaoKe.Forms.Settings;
using TaobaoKe.Forms.Util;
using TaobaoKe.Repository;

namespace TaobaoKe.Forms
{
    [ComVisible(true)]
    public partial class FormMain : FormBase
    {
        DataTable _dataSource = null;
        DataTable _dataSourcePaymentDetails = null;
        private string _htmlEditValue = string.Empty;
        TransmitTaskRepository _transmitTaskRepository = new TransmitTaskRepository();
        Regex _regexCQImage = new Regex(@"\[CQ:image,file=(.+)\]");
        bool _transmitting = false;
        bool _monitorStarted = false;
        bool _transmitStarted = false;
        private bool _suspendPreview = false;
        Regex _regexUrl = new Regex(@"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?");
        Regex _regexTaoToken = new Regex(@"￥\w+￥");
        Regex _regexSellerId = new Regex(@"sellerId=(\d+)");
        Regex _regCoupon = new Regex("<dt>(.+)优惠券</dt>");
        Regex _regCouponCount = new Regex(@"<span class=""count"">(\d+)</span>");
        Regex _regCouponRest = new Regex(@"<span class=""rest"">(\d+)</span>");
        private readonly string _detailItemUrl = "https://detail.tmall.com/item.htm?id=";
        bool isShotcutTimesSetting = false;

        public FormMain()
        {
            InitializeComponent();
            InitializeControl();
        }

        #region 初始化

        private void InitializeControl()
        {
            this.statusStartAt.Text = DateTime.Now.ToString() + "开始运行";
            this.imgList.ImageSize = new System.Drawing.Size(24, 24);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imgList.Images.Add("transmit", Properties.Resources.transmit);
            this.imgList.Images.Add("add_task", Properties.Resources.add_task);
            this.imgList.Images.Add("payment_detail", Properties.Resources.payment_detail);
            this.tpageTransmit.ImageKey = "transmit";
            this.tpageAddTask.ImageKey = "add_task";
            this.tpagePaymentDetails.ImageKey = "payment_detail";

            this.ResetTransmitButtonState();
            this.ResetMonitorButtonState();

            this.wbTransmit.Url = new System.Uri(Constants.HtmlEditorPath);
            this.wbTransmit.ObjectForScripting = this;

            _dataSource = new DataTable("Master");
            _dataSource.Columns.Add("RowNo", typeof(int));
            _dataSource.Columns.Add("Id", typeof(int));
            _dataSource.Columns.Add("Content", typeof(string));
            _dataSource.Columns.Add("From", typeof(string));
            _dataSource.Columns.Add("CommissionRate", typeof(decimal));
            _dataSource.Columns.Add("Coupon", typeof(string));
            _dataSource.Columns.Add("CreateTime", typeof(DateTime));
            bsTasks.DataSource = _dataSource;
            bsTasks.DataMember = "";

            _dataSourcePaymentDetails = new DataTable("Master");
            _dataSourcePaymentDetails.Columns.Add("CreateTime", typeof(string)); // 创建时间
            _dataSourcePaymentDetails.Columns.Add("AuctionInfo", typeof(string)); // 商品信息
            _dataSourcePaymentDetails.Columns.Add("AuctionUrl", typeof(string)); // 商品链接
            _dataSourcePaymentDetails.Columns.Add("PayStatus", typeof(string)); // 订单状态
            _dataSourcePaymentDetails.Columns.Add("DiscountAndSubsidyToString", typeof(string)); // 收入比率
            _dataSourcePaymentDetails.Columns.Add("ShareRate", typeof(string)); // 分成比率
            _dataSourcePaymentDetails.Columns.Add("RealPayFeeString", typeof(string)); // 付款金额
            _dataSourcePaymentDetails.Columns.Add("PubShareFeeString", typeof(string)); // 效果预估
            _dataSourcePaymentDetails.Columns.Add("EarningTime", typeof(string)); // 结算时间
            _dataSourcePaymentDetails.Columns.Add("TotalAlipayFeeString", typeof(string)); // 结算金额
            _dataSourcePaymentDetails.Columns.Add("FeeString", typeof(string)); // 预估收入
            _dataSourcePaymentDetails.Columns.Add("TerminalType", typeof(string)); // 成交平台
            bsPaymentDetails.DataSource = _dataSourcePaymentDetails;
            bsPaymentDetails.DataMember = "";

            this.cboxPayStatus.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbox_DrawItem);
            this.cboxQueryType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbox_DrawItem);
            this.cboxShortcutTimes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbox_DrawItem);

            this.cboxPayStatus.SelectedIndexChanged += new System.EventHandler(this.cboxQueryPaymentDetails_SelectValueChanged);
            this.timeTo.ValueChanged += new System.EventHandler(this.cboxQueryPaymentDetails_SelectValueChanged);
            this.timeFrom.ValueChanged += new System.EventHandler(this.cboxQueryPaymentDetails_SelectValueChanged);

            SetQueryTypeDropDownItems();
            SetShortcutTimesDropDownItems();

            this.cboxQueryType.SelectedIndex = 0;
            this.cboxShortcutTimes.SelectedIndex = 0;

            this.toolTipDownloadPaymentDetails.SetToolTip(btnDownloadPaymentDetails, "下载报表");

            LoadUntransmittedTasks();
        }

        private void LoadUntransmittedTasks()
        {
            _dataSource.BeginLoadData();
            try
            {
                foreach (var item in _transmitTaskRepository.GetUntransmittedTasks())
                {
                    AddToDataSource(item);
                }
                ResetRowNo();
            }
            finally
            {
                _dataSource.EndLoadData();
            }
            _dataSource.AcceptChanges();
        }

        #endregion

        #region HtmlEditor

        public string HtmlEditValue
        {
            get
            {
                return GetContent();
            }
            set
            {
                _htmlEditValue = value;
                SetDetailContent();
            }
        }

        // 此方法为kindeditor必须声明的方法
        public string GetContent()
        {
            return _htmlEditValue;
        }

        // 此方法为kindeditor必须声明的方法
        public void SetDetailContent()
        {
            wbTransmit.Document.InvokeScript("setContent", new object[] { _htmlEditValue });
        }

        // 此方法为kindeditor必须声明的方法
        public void RequestContent(string str)
        {
            _htmlEditValue = str;
        }

        private void wbTransmit_Resize(object sender, EventArgs e)
        {
            this.wbTransmit.Refresh();
        }

        #endregion

        #region 采集相关

        private void lnkMonitor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_monitorStarted)
            {
                StopMonitor();
            }
            else
            {
                StartMonitor();
            }
            ResetMonitorButtonState();
        }

        private void StartMonitor()
        {
            CheckCQProcess();
            if (!NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Start();
                NamedPipedIpcClient.Default_A.Recieve += Ipc_Recieve;
            }
            _monitorStarted = true;
        }

        private void StopMonitor()
        {
            if (NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Stop();
            }
            _monitorStarted = false;
        }

        private void ResetMonitorButtonState()
        {
            if (_monitorStarted)
            {
                this.lnkMonitor.Text = "停止采集";
                this.lnkMonitor.LinkColor = Color.OrangeRed;
                this.statusMonitor.Text = "采集中";
                this.statusMonitor.ForeColor = Color.DodgerBlue;
            }
            else
            {
                this.lnkMonitor.Text = "启动采集";
                this.lnkMonitor.LinkColor = Color.DodgerBlue;
                this.statusMonitor.Text = "未采集";
                this.statusMonitor.ForeColor = Color.OrangeRed;
            }
        }

        private void CheckCQProcess()
        {
            if (Process.GetProcessesByName("CQA").Length == 0)
                Process.Start(Constants.CQPath);
            if (Process.GetProcessesByName("Flexlive.CQP.CSharpProxy").Length == 0)
                Process.Start(Constants.CQProxyPath);
        }

        string Ipc_Recieve(IpcArgs args)
        {
            if (args.Content == "$GetMonitorQQGroupNo$")
            {
                return GlobalSetting.Instance.MonitorSetting.QQGroupNo;
            }
            else
            {
                QQMessage qqMessage = JsonConvert.DeserializeObject<QQMessage>(args.Content);
                LogHelper.Log(LogLevel.INFO, LogItemType.Receive, qqMessage.ToString());
                AddTask(qqMessage);
                return "";
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask(false);
        }

        private void btnAddTaskAtOnce_Click(object sender, EventArgs e)
        {
            AddTask(true);
            Transmit();
        }

        private void AddTask(bool addToTop)
        {
            if (!string.IsNullOrEmpty(this.HtmlEditValue))
            {
                QQMessage qqMessage = new QQMessage()
                {
                    Message = this.HtmlEditValue
                };
                AddTask(qqMessage, addToTop);
                this.HtmlEditValue = string.Empty;
                this.tabMain.SelectedTab = this.tpageTransmit;
            }
        }

        private void AddTask(QQMessage qqMessage, bool addToTop = false)
        {
            TransmitTask transmitTask = new TransmitTask()
            {
                Content = qqMessage.Message,
                From = qqMessage.fromGroup > 0 ? qqMessage.fromGroup.ToString() : "手工添加",
                CreateTime = DateTime.Now,
                Priority = addToTop ? 1 : 0,
                Coupon = GetCoupon(qqMessage.Message)
            };
            _transmitTaskRepository.Add(transmitTask);
            AddToDataSource(transmitTask, addToTop, true);
            this.Invoke((EventHandler)delegate
            {
                gridTasks.Refresh();
            });
        }

        private string GetCoupon(string message)
        {
            string activityId = string.Empty, itemId = string.Empty;
            UrlTransform(message, "", out activityId, out itemId, false);
            if (!string.IsNullOrEmpty(activityId) && !string.IsNullOrEmpty(itemId))
            {
                string html = WebRequestHelper.Get(_detailItemUrl + itemId);
                Match match = _regexSellerId.Match(html);
                if (match != null && match.Groups.Count > 1)
                {
                    //match.Groups
                    string sellerId = match.Groups[1].Value;
                    string couponUrl = string.Format("https://shop.m.taobao.com/shop/coupon.htm?seller_id={0}&activityId={1}", sellerId, activityId);
                    //string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                    string userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1";
                    html = WebRequestHelper.Get(couponUrl, "", userAgent);
                    Match matchCoupon = _regCoupon.Match(html);
                    Match matchCouponCount = _regCouponCount.Match(html);
                    Match matchCouponRest = _regCouponRest.Match(html);
                    string coupon = matchCoupon.Groups.Count > 1 ? matchCoupon.Groups[1].Value : "";
                    string couponRest = matchCouponRest.Groups.Count > 1 ? matchCouponRest.Groups[1].Value : "";
                    string couponCount = matchCouponCount.Groups.Count > 1 ? matchCouponCount.Groups[1].Value : "";
                    return string.Format("{0} 剩{1}张 已领用{2}张", coupon, couponRest, couponCount);
                }
            }
            return "";
        }

        #endregion

        #region 转发Timer

        private void linkTransmit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_transmitStarted)
            {
                StopTransmit();
            }
            else
            {
                StartTransmit();
            }
            ResetTransmitButtonState();
        }

        private void StartTransmit()
        {
            timerTransmit.Interval = GlobalSetting.Instance.TransmitSetting.TransmitInterval * 1000;
            timerTransmit.Start();
            _transmitStarted = true;
        }

        private void StopTransmit()
        {
            timerTransmit.Stop();
            _transmitStarted = false;
        }

        private void ResetTransmitButtonState()
        {
            if (_transmitStarted)
            {
                this.lnkTransmit.Text = "停止转发";
                this.lnkTransmit.LinkColor = Color.OrangeRed;
                this.statusTransmit.Text = "转发中";
                this.statusTransmit.ForeColor = Color.DodgerBlue;
            }
            else
            {
                this.lnkTransmit.Text = "启动转发";
                this.lnkTransmit.LinkColor = Color.DodgerBlue;
                this.statusTransmit.Text = "未转发";
                this.statusTransmit.ForeColor = Color.OrangeRed;
            }
        }

        private void timerTransmit_Tick(object sender, EventArgs e)
        {
            Transmit();
        }

        private void Transmit()
        {
            if (!_transmitting && _dataSource.Rows.Count > 0)
            {
                _transmitting = true;
                try
                {
                    DataRow row = _dataSource.Rows[0];
                    TransmitTask transmitTask = GetTransmitTaskFromRow(row);
                    Transmit(transmitTask);
                    _transmitTaskRepository.UpdateStatus(transmitTask.Id);
                    _dataSource.Rows.Remove(row);
                    ResetRowNo();
                    this.gridTasks.Refresh();
                }
                finally
                {
                    _transmitting = false;
                }
            }
        }

        void Transmit(TransmitTask transmitTask)
        {
            string tempImagePath = string.Empty;
            string msg = ParseCQMessage(transmitTask.Content, out tempImagePath);
            // 打开群快捷方式，进行粘贴
            if (string.IsNullOrEmpty(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath))
            {
                throw new Exception("群快捷方式路径为空，请在全局设置中设置");
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath);
                this.Invoke((EventHandler)delegate
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        // 转链接
                        string qqGroupName = Path.GetFileNameWithoutExtension(file.Name);
                        string transformedMsg = UrlTransform(msg, qqGroupName);
                        // 复制到剪切板
                        this.Invoke((EventHandler)delegate
                        {
                            ClipboardHelper.CopyToClipboard(transformedMsg, "");
                        });
                        using (Process.Start(file.FullName))
                        {
                            Thread.Sleep(GlobalSetting.Instance.TransmitSetting.SleepInterval);
                            SendKeys.Send("^v"); // Paster
                            Thread.Sleep(GlobalSetting.Instance.TransmitSetting.SleepInterval);
                            SendKeys.Send("%s"); // Send
                        }
                    }
                });
            }
            if (File.Exists(tempImagePath))
                File.Delete(tempImagePath);

            LogHelper.Log(LogLevel.INFO, LogItemType.Transmit, string.Format("任务ID{0}转发成功", transmitTask.Id));
        }

        #endregion

        #region 转换相关

        private void btnUrlTrans_Click(object sender, EventArgs e)
        {
            _htmlEditValue = UrlTransform(_htmlEditValue);
            SetDetailContent();
        }

        private string UrlTransform(string message, string qqGroupName = "")
        {
            string activityId = string.Empty, itemId = string.Empty;
            return UrlTransform(message, qqGroupName, out activityId, out itemId);
        }

        private string UrlTransform(string message, string qqGroupName, out string activityId, out string itemId, bool urlTransform = true)
        {
            activityId = string.Empty;
            itemId = string.Empty;
            if (!string.IsNullOrEmpty(message))
            {
                MatchCollection matchesUrl = _regexUrl.Matches(message);
                if (matchesUrl.Count == 1)
                {
                    string ulandTaobaoUrl = string.Empty;
                    Match matchUrl = matchesUrl[0];
                    string url = matchUrl.Value;
                    using (var response = WebRequestHelper.GetWebResponse(url))
                    {
                        ulandTaobaoUrl = response.ResponseUri.ToString();
                    }
                    if (!string.IsNullOrEmpty(ulandTaobaoUrl))
                    {
                        string[] paramValues = WebRequestHelper.GetQueryParamValues(ulandTaobaoUrl, "activityId", "itemId");
                        activityId = paramValues[0];
                        itemId = paramValues[1];
                    }
                    if (urlTransform)
                    {
                        string towInOneLink = DoUrlTransform(qqGroupName, activityId, itemId);
                        //将长链接转短连接
                        string source = "1681459862";//新浪接口要求的请求者标识,暂时写死这个,有访问次数风险
                        string shortUrl = ShortUrlConvert.Convert(towInOneLink, source);

                        message = message.Replace(matchUrl.Value, shortUrl);
                        // 淘口令
                        //message = _regexTaoToken.Replace(message, transformResult.TaoToken);
                    }
                }
                else if (matchesUrl.Count >= 2)
                {
                    // 共找到 3 处匹配：
                    //http://img0.qingtaoke.com/www/img/goods/20170113/524855101182.jpg
                    //https://shop.m.taobao.com/shop/coupon.htm?seller_id=2227168127&amp;activityId=3ce6dd5e39df4d648afb032dddad8397
                    //https://detail.tmall.com/item.htm?id=524855101182
                    Match matchActivity = matchesUrl[matchesUrl.Count - 2];
                    Match matchItemId = matchesUrl[matchesUrl.Count - 1];
                    activityId = WebRequestHelper.GetQueryParamValue(matchActivity.Value, "activityId");
                    itemId = WebRequestHelper.GetQueryParamValue(matchItemId.Value, "id");
                    if (urlTransform)
                    {
                        string towInOneLink = DoUrlTransform(qqGroupName, activityId, itemId);
                        //将长链接转短连接
                        string source = "1681459862";//新浪接口要求的请求者标识,暂时写死这个,有访问次数风险
                        string shortUrl = ShortUrlConvert.Convert(towInOneLink, source);

                        int start = message.LastIndexOf('>', matchActivity.Index) + 1;
                        int end = message.IndexOf("<br", matchItemId.Index);
                        string msg = string.Format("领优惠券下单地址：{0}", shortUrl);
                        message = message.Remove(start, end - start).Insert(start, msg);
                        //message = message.Replace(matchUrl.Value, shortUrl);
                    }
                }
            }
            return message;
        }

        private string DoUrlTransform(string qqGroupName, string activityId, string itemId)
        {
            string adZoneId = GetAdZoneId(qqGroupName);
            if (string.IsNullOrEmpty(adZoneId))
            {
                throw new Exception("推广位未设置，请检查淘客设置");
            }
            String src = "huacai";//标示请求源,不影响链接转化
            String dx = "1";//是否定向,不影响链接转化
            String pId = AlimamaAPI.GetPId(adZoneId);
            TwoInOneLink twoInOneLink = new TwoInOneLink(activityId, pId, itemId, src, dx);
            return twoInOneLink.GenerateLink();
            //TransformParam transformParam = new TransformParam()
            //{
            //    SiteId = siteAdZone.SiteId,
            //    AdZoneId = siteAdZone.AdZoneId,
            //    PromotionURL = _detailItemUrl + itemId,
            //    T = DateUtil.GetUnixTimestamp(),
            //    PvId = "0",
            //    TbToken = _alimamaTbToken,
            //    InputCharset = "utf-8"

            //};
            //return AlimamaUrlTrans.Transform(transformParam, _alimamaCookie);
        }

        private string GetAdZoneId(string qqGroupName)
        {
            string result = null;
            if (!string.IsNullOrEmpty(qqGroupName))
            {
                GlobalSetting.Instance.TaokeSetting.QQGroupAdZones.TryGetValue(qqGroupName, out result);
            }
            if (result == null)
                result = GlobalSetting.Instance.TaokeSetting.DefaultAdZoneId;
            return result;
        }

        #endregion

        #region 订单明细

        private void ResetPayStatusDropDownItems(int queryType)
        {
            this.cboxPayStatus.Items.Clear();
            if (queryType == 0)
            {
                this.cboxPayStatus.Items.Add("全部订单");
                this.cboxPayStatus.Items.Add("订单结算");
                this.cboxPayStatus.Items.Add("订单付款");
                this.cboxPayStatus.Items.Add("订单失效");
                this.cboxPayStatus.Items.Add("订单成功");
            }
            else if (queryType == 1)
            {
                this.cboxPayStatus.Items.Add("订单结算");
            }
            this.cboxPayStatus.SelectedIndex = 0;
        }

        private void SetQueryTypeDropDownItems()
        {
            this.cboxQueryType.Items.Add("创建时间");
            this.cboxQueryType.Items.Add("结算时间");
        }

        private void SetShortcutTimesDropDownItems()
        {
            this.cboxShortcutTimes.Items.Add("快捷日期");
            this.cboxShortcutTimes.Items.Add("昨天");
            this.cboxShortcutTimes.Items.Add("过去7天");
            this.cboxShortcutTimes.Items.Add("过去15天");
            this.cboxShortcutTimes.Items.Add("过去30天");
            this.cboxShortcutTimes.Items.Add("过去60天");
            this.cboxShortcutTimes.Items.Add("过去90天");
        }

        private void cboxQueryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPayStatusDropDownItems(cboxQueryType.SelectedIndex);
        }

        private void cboxShortcutTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Visible && this.cboxShortcutTimes.SelectedIndex != 0)
            {
                DateTime now = DateTime.Now;
                DateTime from = now, to = now;
                switch (this.cboxShortcutTimes.SelectedIndex)
                {
                    case 1:
                        from = now.AddDays(-1);
                        to = now.AddDays(-1);
                        break;
                    case 2:
                        from = now.AddDays(-7);
                        to = now.AddDays(-1);
                        break;
                    case 3:
                        from = now.AddDays(-15);
                        to = now.AddDays(-1);
                        break;
                    case 4:
                        from = now.AddDays(-30);
                        to = now.AddDays(-1);
                        break;
                    case 5:
                        from = now.AddDays(-60);
                        to = now.AddDays(-1);
                        break;
                    case 6:
                        from = now.AddDays(-90);
                        to = now.AddDays(-1);
                        break;
                }
                isShotcutTimesSetting = true;
                try
                {
                    this.timeFrom.Value = from;
                    this.timeTo.Value = to;
                }
                finally
                {
                    isShotcutTimesSetting = false;
                }
                QueryPaymentDetails();
            }
        }

        private void cboxQueryPaymentDetails_SelectValueChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                QueryPaymentDetails();
            }
        }

        private void QueryPaymentDetails(bool exportReport = false)
        {
            if (!isShotcutTimesSetting && timeFrom.Value <= timeTo.Value)
            {
                string payStatus = GetPayStatus(this.cboxPayStatus.SelectedIndex);
                if (this.cboxQueryType.SelectedIndex == 1)
                    payStatus = GetPayStatus(1);
                string startTime = this.timeFrom.Value.ToString("yyyy-MM-dd");
                string endTime = this.timeTo.Value.ToString("yyyy-MM-dd");
                if (exportReport)
                {
                    using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            string savePath = Path.Combine(dialog.SelectedPath
                                , string.Format("淘宝客推广订单明细{0}-{1}{2}.xls", startTime, endTime, GetPayStatusName(payStatus)));
                            AlimamaAPI.ExportPaymentDetailsReport(payStatus, startTime, endTime, savePath);
                            Process.Start("explorer", dialog.SelectedPath);
                        }
                    }
                }
                else
                {
                    _dataSourcePaymentDetails.Clear();
                    List<Payment> details = AlimamaAPI.QueryPaymentDetails(payStatus, startTime, endTime);
                    foreach (var item in details)
                    {
                        DataRow row = _dataSourcePaymentDetails.NewRow();
                        row["CreateTime"] = item.createTime;
                        row["AuctionInfo"] = "【商品描述】" + item.auctionTitle + "    【所属店铺】" + item.exShopTitle;
                        row["AuctionUrl"] = item.auctionUrl;
                        row["PayStatus"] = item.payStatus;
                        row["DiscountAndSubsidyToString"] = item.discountAndSubsidyToString;
                        row["ShareRate"] = item.shareRate;
                        row["RealPayFeeString"] = item.realPayFeeString;
                        row["PubShareFeeString"] = item.tkPubShareFeeString;
                        row["EarningTime"] = item.earningTime;
                        row["TotalAlipayFeeString"] = item.totalAlipayFeeString;
                        row["FeeString"] = item.feeString;
                        row["TerminalType"] = item.terminalType;
                        _dataSourcePaymentDetails.Rows.Add(row);
                    }
                }
            }
        }

        private string GetPayStatus(int selectedIndex)
        {
            if (selectedIndex == 0) // 全部订单
                return "";
            if (selectedIndex == 1) // 订单结算
                return "3";
            if (selectedIndex == 2) // 订单付款
                return "12";
            if (selectedIndex == 3) // 订单失效
                return "13";
            if (selectedIndex == 4) // 订单成功
                return "14";
            return "";
        }

        private string GetPayStatusName(string payStatus)
        {
            if (payStatus == "3")
                return "订单结算";
            else if (payStatus == "12")
                return "订单付款";
            else if (payStatus == "13")
                return "订单失效";
            else if (payStatus == "14")
                return "订单成功";
            return "";
        }

        private Color GetPayStatusColor(string payStatus)
        {
            if (payStatus == "3")
                return Color.Green;
            else if (payStatus == "12")
                return Color.Blue;
            else if (payStatus == "13")
                return Color.Red;
            else if (payStatus == "14")
                return Color.Green;
            return Color.Black;
        }

        private void gridPaymentDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataRowView rowView = (DataRowView)this.bsPaymentDetails[e.RowIndex];
                string payStatus = rowView["PayStatus"].ToString();
                e.Value = GetPayStatusName(payStatus);
                e.CellStyle.ForeColor = GetPayStatusColor(payStatus);
            }
        }

        private void gridPaymentDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataRowView rowView = (DataRowView)this.bsPaymentDetails[e.RowIndex];
                Process.Start(rowView["AuctionUrl"].ToString());
            }
        }

        private void btnDownloadPaymentDetails_Click(object sender, EventArgs e)
        {
            QueryPaymentDetails(true);
        }

        #endregion

        #region 其它事件

        private void lnkSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            if (DialogResult.OK == formSetting.ShowDialog())
            {
                timerTransmit.Interval = GlobalSetting.Instance.TransmitSetting.TransmitInterval * 1000;
                try
                {
                    NamedPipedIpcClient.Default_A.Send(new IpcArgs(GlobalSetting.Instance.MonitorSetting.QQGroupNo));
                }
                catch
                {
                    // 酷Q代理未启动的情况，不需要抛出异常
                }
            }
        }

        private void gridTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1) // 转发内容
            {
                e.Value = _regexCQImage.Replace(e.Value.ToString(), "[图片]");
            }
            else if (e.ColumnIndex == 5) // 创建时间
            {
                e.Value = e.Value.ToString();
            }
        }

        private void gridTasks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                DataRowView rowView = (DataRowView)this.bsTasks[e.RowIndex];
                string content = Convert.ToString(rowView["Content"]);
                if (!FormPreview.Instance.Visible)
                    FormPreview.Instance.Show();
                string tempImagePath;
                FormPreview.Instance.DocumentText = ParseCQMessage(content, out tempImagePath);
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab == this.tpageTransmit)
            {
                if (_suspendPreview && !FormPreview.Instance.Visible)
                {
                    FormPreview.Instance.Show();
                    _suspendPreview = false;
                }
            }
            else
            {
                if (FormPreview.Instance.Visible)
                {
                    FormPreview.Instance.Hide();
                    _suspendPreview = true;
                }
            }
        }

        private void statusShowLog_Click(object sender, EventArgs e)
        {
            FormLog.Instance.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("确定要退出淘宝客？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerTransmit.Dispose();
            Application.Exit();
        }

        #endregion

        #region 私有方法

        private void ResetRowNo()
        {
            for (int i = 0; i < _dataSource.Rows.Count; i++)
            {
                _dataSource.Rows[i]["RowNo"] = i + 1;
            }
        }

        private void AddToDataSource(TransmitTask transmitTask, bool addToTop = false, bool resetRowNo = false)
        {
            DataRow newRow = _dataSource.NewRow();
            newRow["Id"] = transmitTask.Id;
            newRow["Content"] = transmitTask.Content;
            newRow["From"] = transmitTask.From;
            newRow["CommissionRate"] = transmitTask.CommissionRate;
            newRow["Coupon"] = transmitTask.Coupon;
            newRow["CreateTime"] = transmitTask.CreateTime;
            if (addToTop)
                _dataSource.Rows.InsertAt(newRow, 0);
            else
                _dataSource.Rows.Add(newRow);

            if (resetRowNo)
            {
                if (addToTop)
                    ResetRowNo();
                else
                {
                    if (_dataSource.Rows.Count > 1)
                    {
                        newRow["RowNo"] = Convert.ToInt32(_dataSource.Rows[_dataSource.Rows.Count - 2]["RowNo"]) + 1;
                    }
                    else
                    {
                        newRow["RowNo"] = 1;
                    }
                }
            }
        }

        private TransmitTask GetTransmitTaskFromRow(DataRow row)
        {
            return new TransmitTask()
            {
                Id = Convert.ToInt32(row["Id"]),
                Content = Convert.ToString(row["Content"]),
                From = Convert.ToString(row["From"]),
                CommissionRate = Convert.ToInt32(row["CommissionRate"]),
                Coupon = Convert.ToString(row["Coupon"]),
                CreateTime = Convert.ToDateTime(row["CreateTime"])
            };
        }

        // 替换CQ消息为html文本（cqimg图片）
        private string ParseCQMessage(string msg, out string tempImagePath)
        {
            Match match = _regexCQImage.Match(msg);
            tempImagePath = string.Empty;
            if (match.Success && match.Groups.Count > 1)
            {
                string imageName = match.Groups[1].Value;
                tempImagePath = Path.Combine(Constants.CQImagePath, imageName);
                string iniFilePath = tempImagePath + ".cqimg";
                string imageUrl = IniFileUtil.ReadIniData("image", "url", "", iniFilePath);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    if (!File.Exists(tempImagePath))
                        WebRequestHelper.DownloadFile(tempImagePath, imageUrl);
                    msg = msg.Remove(match.Index, match.Length);
                    msg = msg.Insert(match.Index, string.Format("<img src='file:///{0}' height='200'>", tempImagePath));
                }
            }
            return msg.Replace("\r\n", "<br />");
        }

        #endregion
    }
}
