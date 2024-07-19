namespace SalesPro.Tests.TestEntities;

public class TestDealPipeline : DealPipelineCreateDto
{
    public TestDealPipeline(string uid = "")
    {
        Name = $"TestDealPipeline{uid}";
    }
}