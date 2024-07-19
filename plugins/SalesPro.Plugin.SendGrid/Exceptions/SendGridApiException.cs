namespace SalesPro.Plugin.SendGrid.Exceptions;

public class SendGridApiException : Exception
{
    public SendGridApiException(string message)
        : base(message)
    {
    }
}