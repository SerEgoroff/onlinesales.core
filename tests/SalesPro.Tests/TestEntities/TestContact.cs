namespace SalesPro.Tests.TestEntities;

public class TestContact : ContactCreateDto
{
    public TestContact(string uid = "")
    {
        Email = $"contact{uid}@test{uid}.net";
    }
}