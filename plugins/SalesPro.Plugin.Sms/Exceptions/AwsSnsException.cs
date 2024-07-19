using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SalesPro.Plugin.Sms.Exceptions
{
    [Serializable]
    public class AwsSnsException : Exception
    {
        public AwsSnsException()
        {
        }

        public AwsSnsException(string? message)
            : base(message)
        {
        }

        public AwsSnsException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected AwsSnsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}