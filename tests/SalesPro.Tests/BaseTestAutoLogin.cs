using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SalesPro.Configuration;

namespace SalesPro.Tests;

public class BaseTestAutoLogin : BaseTest
{
    protected static readonly string LoginApi = "/api/identity/login";
    protected static readonly LoginDto AdminLoginData = GetLoginDtoFromConfiguration();

    private JWTokenDto? authToken;

    public BaseTestAutoLogin()
        : base()
    {
        LoginAsAdmin().Wait();
    }

    protected async Task<JWTokenDto?> LoginAsAdmin()
    {
        authToken = await PostTest<JWTokenDto>(LoginApi, AdminLoginData, HttpStatusCode.OK);
        return authToken;
    }

    protected void Logout()
    {
        authToken = null;
    }

    protected override AuthenticationHeaderValue? GetAuthenticationHeaderValue()
    {
        return authToken != null ? new AuthenticationHeaderValue("Bearer", authToken!.Token) : null;
    }

    private static LoginDto GetLoginDtoFromConfiguration()
    {
        var defaultUser = Program.GetApp()!.Configuration.GetSection("DefaultUsers").Get<DefaultUsersConfig>()![0];
        return new LoginDto()
        {
            Email = defaultUser.Email,
            Password = defaultUser.Password,
        };
    }
}
