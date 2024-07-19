using System.Runtime.Serialization;

namespace SalesPro.Plugin.Sms.Exceptions
{
    [Serializable]
    public class UnknownCountryCodeException : Exception
    {
        public UnknownCountryCodeException()
        {
        }

        public UnknownCountryCodeException(string? message)
            : base(message)
        {
        }

        public UnknownCountryCodeException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected UnknownCountryCodeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}