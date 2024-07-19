using System.Runtime.Serialization;

namespace SalesPro.Exceptions;

[Serializable]
public class PluginDbContextTooManyException : PluginDbContextException
{
    private static readonly string HardcodedMessage = "Plugin database context is registered in service provider more than once";

    public PluginDbContextTooManyException()
        : base()
    {
    }

    public PluginDbContextTooManyException(Type? unregisteredDbContext)
        : base(HardcodedMessage, unregisteredDbContext)
    {
    }

    public PluginDbContextTooManyException(Type? unregisteredDbContext, Exception? innerException)
        : base(HardcodedMessage, unregisteredDbContext, innerException)
    {
    }

    protected PluginDbContextTooManyException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}