using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;
using System.IO;

namespace TaobaoKe.Core.Log
{
    public class LogItemLayout : log4net.Layout.PatternLayout
    {
        public LogItemLayout()
        {
            this.AddConverter("LogItem", typeof(LogItemLayoutConverter));
        }
    }

    internal sealed class LogItemLayoutConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (Option == null)
            {
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.Properties);
            }
            else
            {
                object value = GetPropertyValue(Option, loggingEvent.MessageObject);
                WriteObject(writer, loggingEvent.Repository, value);
            }
        }

        private object GetPropertyValue(string property, object instance)
        {
            object result = null;
            var propertyInfo = instance.GetType().GetProperty(property);
            if (propertyInfo != null)
                result = propertyInfo.GetValue(instance, null);
            return result;
        }
    }
}
