using SalesPro.Tests.TestEntities;

namespace SalesPro.Tests;
public class PromotionTests : SimpleTableTests<Promotion, TestPromotion, PromotionUpdateDto, IEntityService<Promotion>>
{
    public PromotionTests()
        : base("/api/promotion")
    {
    }

    protected override PromotionUpdateDto UpdateItem(TestPromotion pcd)
    {
        var from = new PromotionUpdateDto();
        pcd.Name = from.Name = pcd.Name + "Updated";
        return from;
    }
}