namespace SalesPro.Plugin.TestPlugin.Exceptions;
public class TestDbContextException : Exception
{
    public TestDbContextException(string message)
        : base(message)
    {
    }
}