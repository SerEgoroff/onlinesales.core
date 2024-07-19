namespace SalesPro.Tests.TestEntities;

public class TestEmailGroup : EmailGroupCreateDto
{
    public TestEmailGroup(string uid = "")
    {
        Name = $"TestEmailGroup{uid}";
    }
}