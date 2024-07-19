namespace SalesPro.Exceptions;

public class DealPipelineStageException : Exception
{
    public DealPipelineStageException(string message)
        : base(message)
    {        
    }
}