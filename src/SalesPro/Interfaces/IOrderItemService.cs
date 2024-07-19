using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IOrderItemService : IEntityService<OrderItem>
    {
        void Delete(OrderItem orderItem);
    }
}