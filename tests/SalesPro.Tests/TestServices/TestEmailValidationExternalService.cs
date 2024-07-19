using SalesPro.Interfaces;

namespace SalesPro.Tests.TestServices
{
    public class TestEmailValidationExternalService : IEmailValidationExternalService
    {
        public Task<EmailVerifyInfoDto> Validate(string email)
        {
            var emailVerifyInfo = new EmailVerifyInfoDto()
            {
                EmailAddress = email,
                CatchAllCheck = true,
                DisposableCheck = false,
                FreeCheck = false,
            };

            return Task.FromResult(emailVerifyInfo);
        }
    }
}