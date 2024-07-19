using System.Runtime.Serialization;

namespace SalesPro.Exceptions;

[Serializable]
public class PluginDbContextNotFoundException : PluginDbContextException
{
    private static readonly string HardcodedMessage = "Plugin database context is not registered in service provider";

    public PluginDbContextNotFoundException()
        : base()
    {
    }

    public PluginDbContextNotFoundException(Type? unregisteredDbContext)
        : base(HardcodedMessage, unregisteredDbContext)
    {
    }

    public PluginDbContextNotFoundException(Type? unregisteredDbContext, Exception? innerException)
        : base(HardcodedMessage, unregisteredDbContext, innerException)
    {
    }

    protected PluginDbContextNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}