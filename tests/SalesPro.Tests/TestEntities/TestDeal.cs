namespace SalesPro.Tests.TestEntities;

public class TestDeal : DealCreateDto
{
    public TestDeal(string uid, HashSet<int> contactIds, int accountId, int dealPipelineId, string userId)
    {
        AccountId = accountId;
        ContactIds = contactIds;
        DealPipelineId = dealPipelineId;
        DealCurrency = "USD";
        ExpectedCloseDate = new DateTime(2023, 6, 1).ToUniversalTime();
        UserId = userId;
    }
}