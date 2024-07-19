using SalesPro.DataAnnotations;

namespace SalesPro.Tests;
public class DealPipelinesTests : SimpleTableTests<DealPipeline, TestDealPipeline, DealPipelineUpdateDto, IEntityService<DealPipeline>>
{
    public DealPipelinesTests()
        : base("/api/deal-pipelines")
    {
    }

    protected override DealPipelineUpdateDto UpdateItem(TestDealPipeline tdp)
    {
        var from = new DealPipelineUpdateDto();
        tdp.Name = from.Name = tdp.Name + "Updated";
        return from;
    }
}