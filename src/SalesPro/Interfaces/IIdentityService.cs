using System.Security.Claims;
using SalesPro.Entities;

namespace SalesPro.Interfaces;

public interface IIdentityService
{
    Task<User> FindOnRegister(string email);

    Task<ClaimsPrincipal> CreateUserClaimsPrincipal(User user);

    Task<List<Claim>> CreateUserClaims(User user);
}

