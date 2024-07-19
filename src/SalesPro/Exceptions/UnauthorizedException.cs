using System.Runtime.Serialization;

namespace SalesPro.Exceptions;

[Serializable]
public class UnauthorizedException : Exception
{
    public UnauthorizedException()
        : base("Failed to login")
    {
    }

    protected UnauthorizedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}