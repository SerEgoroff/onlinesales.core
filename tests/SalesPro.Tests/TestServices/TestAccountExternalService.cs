﻿using SalesPro.Geography;
using SalesPro.Interfaces;

namespace SalesPro.Tests.TestServices;

public class TestAccountExternalService : IAccountExternalService
{
    public Task<AccountDetailsInfo?> GetAccountDetails(string domain)
    {
        var account = new AccountDetailsInfo()
        {
            CityName = "Colombo",
            CountryCode = Country.LK,
            EmployeesRange = "500 - 1000",
            Name = "WaveAccess SL",
            Revenue = 90000000,
            State = "WA",
            SocialMedia = new Dictionary<string, string>()
            {
                { "Facebook", "https://fb.com/waveaccess" },
                { "Instagram", "https://www.instagram.com/waveaccess" },
            },

            Tags = new string[] { "Information technology", "App Development" },
        };

        return Task.FromResult<AccountDetailsInfo?>(account);
    }
}