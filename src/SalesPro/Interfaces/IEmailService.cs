using SalesPro.DTOs;

namespace SalesPro.Interfaces
{
    public interface IEmailService
    {
        Task<string> SendAsync(string subject, string fromEmail, string fromName, string[] recipients, string body, List<AttachmentDto>? attachments);
    }
}