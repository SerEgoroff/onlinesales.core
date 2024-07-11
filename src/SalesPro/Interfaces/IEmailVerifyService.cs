// <copyright file="IEmailVerifyService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IEmailVerifyService
    {
        Task<Domain> Verify(string email);
    }
}