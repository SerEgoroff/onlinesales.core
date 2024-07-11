// <copyright file="IEmailService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using SalesPro.DTOs;

namespace SalesPro.Interfaces
{
    public interface IEmailService
    {
        Task<string> SendAsync(string subject, string fromEmail, string fromName, string[] recipients, string body, List<AttachmentDto>? attachments);
    }
}