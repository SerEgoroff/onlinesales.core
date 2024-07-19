﻿using System.ComponentModel.DataAnnotations;

namespace SalesPro.Tests.TestEntities;

public class TestOrderItem : OrderItemCreateDto
{
    public TestOrderItem(string uid = "", int orderId = 0)
    {
        Currency = "USD";
        ProductName = $"ProductName{uid}";
        UnitPrice = 1.99m;
        Quantity = 1;
        OrderId = orderId;
    }
}

public class TestOrderItemUpdateWithTotal : OrderItemUpdateDto
{
    [Required]
    public decimal Total { get; set; } = 0;
}

public class TestOrderItemUpdateWithCurrencyTotal : OrderItemUpdateDto
{
    [Required]
    public decimal CurrencyTotal { get; set; } = 0;
}