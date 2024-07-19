using System.Runtime.Serialization;

namespace SalesPro.Plugin.Sms.Exceptions
{
    [Serializable]
    public class NotifyLkException : Exception
    {
        public NotifyLkException()
        {
        }

        public NotifyLkException(string? message)
            : base(message)
        {
        }

        public NotifyLkException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected NotifyLkException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}