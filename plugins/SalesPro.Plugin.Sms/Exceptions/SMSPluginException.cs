using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SalesPro.Plugin.Sms.Exceptions
{
    [Serializable]
    public class SmsPluginException : Exception
    {
        public SmsPluginException()
        {
        }

        public SmsPluginException(string? message)
            : base(message)
        {
        }

        public SmsPluginException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected SmsPluginException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}