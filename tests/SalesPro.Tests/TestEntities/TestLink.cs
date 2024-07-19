namespace SalesPro.Tests.TestEntities;

public class TestLink : LinkCreateDto
{
    public TestLink()
    {
        Uid = "google_link";
        Destination = "https://google.com/";
        Name = "Google Link";
    }
}