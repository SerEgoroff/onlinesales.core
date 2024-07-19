using SalesPro.Entities;

namespace SalesPro.Interfaces;

public interface IOrderService : IEntityService<Order>
{
    public void RecalculateOrder(Order order);
}

