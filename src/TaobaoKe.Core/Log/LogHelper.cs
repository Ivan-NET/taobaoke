using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using TaobaoKe.Core.Util;

namespace TaobaoKe.Core.Log
{
    public delegate void OnLog(LogItem logItem);

    public class LogHelper
    {
        private static ILog _sysLogger = log4net.LogManager.GetLogger("System");

        public static OnLog OnLog { get; set; }

        public static void Log(LogLevel level, LogItemType type, string message)
        {
            LogItem item = new LogItem()
            {
                Level = (byte)level,
                Type = (byte)type,
                Content = message,
                CreateTime = DateTime.Now
            };
            switch (level)
            {
                case LogLevel.Fatal:
                    _sysLogger.Fatal(item);
                    break;
                case LogLevel.ERROR:
                    _sysLogger.Error(item);
                    break;
                case LogLevel.WARN:
                    _sysLogger.Warn(item);
                    break;
#if DEBUG
                case LogLevel.DEBUG:
                    _sysLogger.Debug(item);
                    break;
#endif
                case LogLevel.INFO:
                    _sysLogger.Info(item);
                    break;
                default:
                    break;
            }
            if (OnLog != null)
                OnLog(item);
        }

        public static void Log(LogLevel level, LogItemType type, string message, Exception ex)
        {
            string errMsg = ExceptionUtil.GetErrorMsg(ex);
            message = message + Environment.NewLine + errMsg;
            Log(level, type, message);
        }

        public static void Log(LogLevel level, LogItemType type, Exception ex)
        {
            string errMsg = ExceptionUtil.GetErrorMsg(ex);
            Log(level, type, errMsg);
        }
    }

    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel : byte
    {
        /// <summary>
        /// 致命
        /// </summary>
        [DescriptionAttribute("致命")]
        Fatal = 0,
        /// <summary>
        /// 错误
        /// </summary>
        [DescriptionAttribute("错误")]
        ERROR = 1,
        /// <summary>
        /// 警告
        /// </summary>
        [DescriptionAttribute("警告")]
        WARN = 2,
        /// <summary>
        /// 调试
        /// </summary>
        [DescriptionAttribute("调试")]
        DEBUG = 3,
        /// <summary>
        /// 信息
        /// </summary>
        [DescriptionAttribute("信息")]
        INFO = 4
    }
}
