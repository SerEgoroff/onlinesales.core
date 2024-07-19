namespace SalesPro.Tests;

public class EmailTests : BaseTestAutoLogin
{
    [Fact]
    public async Task RetrieveInformationsFromEmail()
    {
        var email = "hello@wave-access.com";
        var url = "/api/email/verify/" + email;
        var requestedData = await GetTest(url);

        requestedData.Should().NotBeNull();
    }
}