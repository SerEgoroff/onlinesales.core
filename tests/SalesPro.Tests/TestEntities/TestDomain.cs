namespace SalesPro.Tests.TestEntities;

public class TestDomain : DomainCreateDto
{
    public TestDomain(string name = "")
    {
        Name = $"gmail{name}.com";
    }
}