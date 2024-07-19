using Microsoft.AspNetCore.Http.HttpResults;
using SalesPro.Interfaces;

namespace SalesPro.Tests.TestServices
{
    public class TestEmailService : IEmailService
    {
        public Task<string> SendAsync(string subject, string fromEmail, string fromName, string[] recipients, string body, List<AttachmentDto>? attachments)
        {
            // Test email sender method returns success.
            return new Task<string>(() => "messageId");
        }
    }
}