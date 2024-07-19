using SalesPro.DTOs;

namespace SalesPro.Interfaces
{
    public interface IEmailValidationExternalService
    {
        Task<EmailVerifyInfoDto> Validate(string email);
    }
}