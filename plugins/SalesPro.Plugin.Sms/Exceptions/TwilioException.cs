using System.Runtime.Serialization;

namespace SalesPro.Plugin.Sms.Exceptions
{
    [Serializable]
    public class TwilioException : Exception
    {
        public TwilioException()
        {
        }

        public TwilioException(string? message)
            : base(message)
        {
        }

        public TwilioException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected TwilioException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}