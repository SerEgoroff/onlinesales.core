// <copyright file="IEmailValidationExternalService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using SalesPro.DTOs;

namespace SalesPro.Interfaces
{
    public interface IEmailValidationExternalService
    {
        Task<EmailVerifyInfoDto> Validate(string email);
    }
}