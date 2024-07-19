using SalesPro.DTOs;

namespace SalesPro.Interfaces;

public interface IEmailFromTemplateService
{
    Task SendAsync(string templateName, string language, string[] recipients, Dictionary<string, string>? templateArguments, List<AttachmentDto>? attachments);

    Task SendToContactAsync(int contactId, string templateName, Dictionary<string, string>? templateArguments, List<AttachmentDto>? attachments, int scheduleId = 0);
}