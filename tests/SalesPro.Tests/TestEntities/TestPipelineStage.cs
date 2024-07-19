namespace SalesPro.Tests.TestEntities;

public class TestPipelineStage : DealPipelineStageCreateDto
{
    private static int nextOrder = 1;

    public TestPipelineStage(string uid = "", int pipelineId = 0)
    {
        this.Name = $"TestPipelineStage{uid}";
        this.Order = nextOrder++;
        this.DealPipelineId = pipelineId;
    }
}