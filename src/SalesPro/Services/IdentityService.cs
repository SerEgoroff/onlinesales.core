using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SalesPro.Entities;
using SalesPro.Interfaces;

namespace SalesPro.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> userManager;

    public IdentityService(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<User> FindOnRegister(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            user = new User
            {
                UserName = email,
                Email = email,
                CreatedAt = DateTime.UtcNow,
                DisplayName = email,
            };

            await userManager.CreateAsync(user);
        }

        return user;
    }

    public async Task<ClaimsPrincipal> CreateUserClaimsPrincipal(User user)
    {
        var claims = await CreateUserClaims(user);

        var identity = new ClaimsIdentity(claims);

        return new ClaimsPrincipal(identity);
    }

    public async Task<List<Claim>> CreateUserClaims(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

        var roles = await userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }
}