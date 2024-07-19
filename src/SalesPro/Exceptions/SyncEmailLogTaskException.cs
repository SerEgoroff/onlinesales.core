using System.Runtime.Serialization;

namespace SalesPro.Exceptions
{
    [Serializable]
    public class SyncEmailLogTaskException : Exception
    {
        public SyncEmailLogTaskException()
        {
        }

        public SyncEmailLogTaskException(string? message)
            : base(message)
        {
        }

        public SyncEmailLogTaskException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected SyncEmailLogTaskException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
