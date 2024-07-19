using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IEmailVerifyService
    {
        Task<Domain> Verify(string email);
    }
}