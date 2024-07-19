namespace SalesPro.Interfaces
{
    public interface ISmsService
    {
        Task SendAsync(string recipient, string message);

        string GetSender(string recipient);
    }
}