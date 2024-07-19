using SalesPro.Geography;

namespace SalesPro.Tests.TestEntities;

public class TestAccount : AccountCreateDto
{
    public TestAccount(string uid = "")
    {
        Name = $"WaveAccess {uid}";
        EmployeesRange = "500 - 1000";
        CountryCode = Country.LK;
        SocialMedia = new Dictionary<string, string>()
        {
            { "Facebook", "https://fb.com/waveaccess" },
            { "Instagram", "https://www.instagram.com//waveaccess" },
        };

        Tags = new string[] { "Information technology", "App Development" };
    }
}