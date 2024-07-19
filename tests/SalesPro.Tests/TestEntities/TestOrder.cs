﻿using System.ComponentModel.DataAnnotations;

namespace SalesPro.Tests.TestEntities;

public class TestOrder : OrderCreateDto
{
    public TestOrder(string uid = "", int contactId = 0)
    {
        RefNo = $"1000{uid}";
        Currency = "USD";
        ExchangeRate = 1.234M;
        ContactId = contactId;
    }
}

public class TestOrderWithQuantity : TestOrder
{
    [Required]
    public int Quantity { get; set; } = 10;
}

public class TestOrderWithTotal : TestOrder
{
    [Required]
    public decimal Total { get; set; } = 10;
}

public class TestOrderWithCurrencyTotal : TestOrder
{
    [Required]
    public decimal CurrencyTotal { get; set; } = 10;
}