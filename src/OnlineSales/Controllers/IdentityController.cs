// <copyright file="IdentityController.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineSales.Configuration;
using OnlineSales.DTOs;
using OnlineSales.Entities;

namespace OnlineSales.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private const string SecretRefreshRole = "OnlineSalesSecretRefreshRole";
    private readonly SignInManager<User> signInManager;
    private readonly IOptions<JwtConfig> jwtConfig;
    // private readonly string refreshTokenDummyHead = Guid.NewGuid().ToString();

    public IdentityController(SignInManager<User> signInManager, IOptions<JwtConfig> jwtConfig)
    {
        this.signInManager = signInManager;
        this.jwtConfig = jwtConfig;
    }

    [HttpGet("external-login")]
    public ActionResult ExternalLogin(string returnUrl)
    {
        const string provider = "OpenIdConnect";
        var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
        return new ChallengeResult(provider, properties);
    }

    [HttpGet("callback")]
    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    {
        var info = await signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            throw new IdentityException("Failed to retrieve external login info");
        }

        var result = await signInManager.ExternalLoginSignInAsync(
            info.LoginProvider,
            info.ProviderKey,
            isPersistent: false,
            bypassTwoFactor: true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
            {
                throw new IdentityException("Account locked out");
            }

            if (result.IsNotAllowed)
            {
                throw new IdentityException("Sign in with specified account is prohibited");
            }
        }

        return LocalRedirect(returnUrl);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    public async Task<ActionResult> Login([FromBody] LoginDto input)
    {
        var userManager = signInManager.UserManager;

        var user = await userManager.FindByEmailAsync(input.Email);

        if (user == null)
        {
            throw new UnauthorizedException();
        }

        if(!user.EmailConfirmed)
        {
            throw new IdentityException("Email is not confirmed");
        }

        if (await userManager.IsLockedOutAsync(user))
        {
            throw new IdentityException("Account locked out");
        }

        var signResult = await signInManager.CheckPasswordSignInAsync(user, input.Password, true);
        if (!signResult.Succeeded)
        {
            if (signResult.IsLockedOut)
            {
                throw new TooManyRequestsException();
            }
            else
            {
                throw new UnauthorizedException();
            }
        }

        var authClaims = await GetAuthClaims(userManager, user);
        var accessToken = GetToken(authClaims, jwtConfig.Value.AccessTokenExpiration);

        var refreshClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Role, SecretRefreshRole),
        };
        var refreshToken = GetToken(refreshClaims, jwtConfig.Value.RefreshTokenExpiration);

        /*user.RefreshToken = refreshToken;
        user.RefreshTokenValidTo = refreshValidTo;
        await userManager.UpdateAsync(user);*/

        return Ok(new JWTokenDto()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            Expiration = accessToken.ValidTo,
            RefreshToken = /*refreshTokenDummyHead + */new JwtSecurityTokenHandler().WriteToken(refreshToken),
            TokenType = JwtBearerDefaults.AuthenticationScheme,
        });
    }

    [HttpPost("refresh")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Refresh([FromBody] string input)
    {
        var userManager = signInManager.UserManager;

        /*var header = HttpContext.Request.Headers.Authorization.FirstOrDefault();
        if(header == null)
        {
            throw new IdentityException("Refresh token is not specified.");
        }

        var auth = AuthenticationHeaderValue.Parse(header);
        if(auth == null || auth.Parameter == null || auth.Scheme != JwtBearerDefaults.AuthenticationScheme)
        {
            throw new UnauthorizedException();
        }

        var tokenString = auth.Parameter.Substring(refreshTokenDummyHead.Length);*/
        var tokenString = input; // .Substring(refreshTokenDummyHead.Length);
        // var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
        var validationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtConfig.Value.Issuer, // The issuer of the token

            ValidateAudience = true,
            ValidAudience = jwtConfig.Value.Audience, // The audience of the token

            ValidateLifetime = true, // Validate the token's expiration

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Value.Secret)), // The key used to sign the token

            ClockSkew = TimeSpan.Zero, // Optional: adjust for clock skew if necessary
        };

        SecurityToken token;
        var principal = new JwtSecurityTokenHandler().ValidateToken(tokenString, validationParameters, out token);
        if(principal == null)
        {
            throw new UnauthorizedException();
        }

        var claims = principal.Claims;
        var email = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);

        // var email = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
        if (email == null)
        {
            throw new UnauthorizedException();
        }

        var user = await userManager.FindByEmailAsync(email.Value);
        if (user == null)
        {
            throw new UnauthorizedException();
        }

        if (await userManager.IsLockedOutAsync(user))
        {
            throw new IdentityException("Account locked out");
        }

        // if (user.RefreshTokenValidTo <= DateTime.UtcNow)
        /*if (token.ValidTo <= DateTime.UtcNow)
        {
            // user.RefreshToken = null;
            // user.RefreshTokenValidTo = null;
            // await userManager.UpdateAsync(user);

            throw new UnauthorizedException();
        }*/

        var authClaims = await GetAuthClaims(userManager, user);

        var accessToken = GetToken(authClaims, jwtConfig.Value.AccessTokenExpiration);

        return Ok(new JWTokenDto()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            Expiration = accessToken.ValidTo,
            RefreshToken = input,
            TokenType = JwtBearerDefaults.AuthenticationScheme,
        });
    }

    private async Task<List<Claim>> GetAuthClaims(UserManager<User> userManager, User user)
    {
        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        return authClaims;
    }

    private JwtSecurityToken GetToken(List<Claim> claims, double expireInMinutes)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Value.Secret));
        var token = new JwtSecurityToken(
            issuer: jwtConfig.Value.Issuer,
            audience: jwtConfig.Value.Audience,
            expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return token;
    }
}