using SalesPro.DTOs;

namespace SalesPro.Interfaces
{
    public interface IAccountExternalService
    {
        Task<AccountDetailsInfo?> GetAccountDetails(string domain);
    }
}