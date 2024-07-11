// <copyright file="IHttpContextHelper.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using Microsoft.AspNetCore.Identity;
using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IHttpContextHelper
    {
        public HttpRequest Request { get; }

        public string? IpAddress { get; }

        public string? IpAddressV4 { get; }

        public string? IpAddressV6 { get; }

        public string? UserAgent { get; }

        public Task<User?> GetCurrentUserAsync();

        public Task<string?> GetCurrentUserIdAsync();
    }
}