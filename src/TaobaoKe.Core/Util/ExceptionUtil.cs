using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.Util
{
    public class ExceptionUtil
    {
        /// <summary>
        /// 获取内部实际异常
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Exception GetInnerException(Exception exception)
        {
            Exception ex = exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        /// <summary>
        /// 获取完整的异常信息（包含完整的信息和堆栈）
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetErrorMsg(Exception exception)
        {
            List<string> lstErrors = new List<string>();
            Exception ex = exception;
            do
            {
                lstErrors.Add(ex.Message + Environment.NewLine + ex.StackTrace);
                ex = ex.InnerException;
            }
            while (ex != null);
            StringBuilder builder = new StringBuilder();
            int stackCount = lstErrors.Count;
            for (int i = 0; i < stackCount; i++)
            {
                builder.AppendLine(lstErrors[i]);
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
