﻿using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using SalesPro.DataAnnotations;
using SalesPro.Entities;

namespace SalesPro.DTOs;

public class OrderCreateDto
{
    [Required]
    public int ContactId { get; set; }

    [Required]
    public string RefNo { get; set; } = string.Empty;

    public string? OrderNumber { get; set; }

    public string? AffiliateName { get; set; }

    [Required]
    public decimal ExchangeRate { get; set; } = 1;

    [Required]
    public string Currency { get; set; } = string.Empty;

    public bool TestOrder { get; set; } = false;

    public string? Data { get; set; }

    [Optional]
    public string? Source { get; set; }
}

public class OrderUpdateDto
{
    [Required]
    public string RefNo { get; set; } = string.Empty;

    public string? AffiliateName { get; set; }

    public string? Data { get; set; }
}

public class OrderDetailsDto : OrderCreateDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    [Ignore]
    public List<OrderItemDetailsDto>? OrderItems { get; set; }

    [Ignore]
    public ContactDetailsDto? Contact { get; set; }
}

public class OrderImportDto : BaseImportDto
{
    [Optional]
    [SwaggerUnique]
    public string? RefNo { get; set; } = string.Empty;

    [Optional]
    public string? OrderNumber { get; set; }

    [Optional]
    public string? AffiliateName { get; set; }

    [Optional]
    public decimal? ExchangeRate { get; set; } = 1;

    [Required]
    public string? Currency { get; set; } = string.Empty;

    [Optional]
    public int? ContactId { get; set; }

    [Optional]
    [EmailAddress]
    [SurrogateForeignKey(typeof(Contact), "Email", "ContactId")]
    public string? ContactEmail { get; set; }

    [Optional]
    public bool? TestOrder { get; set; } = false;

    [Optional]
    public string? Data { get; set; }
}