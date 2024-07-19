﻿using SalesPro.Data;
using SalesPro.Entities;
using SalesPro.Interfaces;

namespace SalesPro.Services
{
    public class OrderService : IOrderService
    {
        private PgDbContext pgDbContext;

        public OrderService(PgDbContext pgDbContext)
        {
            this.pgDbContext = pgDbContext;
        }

        public void RecalculateOrder(Order order)
        {
            if (order.OrderItems == null)
            {
                pgDbContext.Entry(order).Collection(o => o.OrderItems!).Load();
            }

            if (order.Discounts == null)
            {
                pgDbContext.Entry(order).Collection(o => o.Discounts!).Load();
            }

            var itemsCurrencyTotalSum = order.OrderItems!.Sum(oi => oi.CurrencyTotal);
            order.CurrencyTotal = itemsCurrencyTotalSum - order.Discounts!.Sum(d => d.Value) - order.Refund;

            order.Total = order.CurrencyTotal * order.ExchangeRate;
            order.Quantity = order.OrderItems!.Sum(oi => oi.Quantity);
        }

        public async Task SaveAsync(Order order)
        {
            RecalculateOrder(order);

            if (order.Id > 0)
            {
                pgDbContext.Orders!.Update(order);
            }
            else
            {
                await pgDbContext.Orders!.AddAsync(order);
            }
        }

        public Task SaveRangeAsync(List<Order> items)
        {
            throw new NotImplementedException();
        }

        public void SetDBContext(PgDbContext pgDbContext)
        {
            this.pgDbContext = pgDbContext;
        }
    }
}