using System.Runtime.Serialization;

namespace SalesPro.Plugin.Sms.Exceptions;

[Serializable]
public class GetshoutoutException : Exception
{
    public GetshoutoutException()
    {
    }

    public GetshoutoutException(string? message)
        : base(message)
    {
    }

    public GetshoutoutException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected GetshoutoutException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}