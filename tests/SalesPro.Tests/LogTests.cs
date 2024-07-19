namespace SalesPro.Tests;

public class LogTests : BaseTestAutoLogin
{
    /// <summary>
    /// Simply verifies that logs API can be successfully executed and returns HTTP 200.
    /// We can not really verify log records as they are added to Elastic asynchromously.
    /// </summary>
    [Fact]
    public async Task GetLogsTest()
    {
        await GetTest("/api/logs");
    }
}