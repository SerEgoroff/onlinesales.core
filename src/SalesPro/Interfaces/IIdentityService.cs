// <copyright file="IIdentityService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.Security.Claims;
using SalesPro.Entities;

namespace SalesPro.Interfaces;

public interface IIdentityService
{
    Task<User> FindOnRegister(string email);

    Task<ClaimsPrincipal> CreateUserClaimsPrincipal(User user);

    Task<List<Claim>> CreateUserClaims(User user);
}

