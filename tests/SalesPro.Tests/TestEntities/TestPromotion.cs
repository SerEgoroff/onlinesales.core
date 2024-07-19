namespace SalesPro.Tests.TestEntities;

public class TestPromotion : PromotionCreateDto
{
    public TestPromotion(string uid)
    {
        Code = "PromotionCode_" + uid;
        Name = "Name_" + uid;
    }
}