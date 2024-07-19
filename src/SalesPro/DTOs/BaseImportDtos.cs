﻿using CsvHelper.Configuration.Attributes;

namespace SalesPro.DTOs;

public class BaseImportDtoWithIdAndSource
{
    [Optional]
    public int? Id { get; set; }

    [Optional]
    public string? Source { get; set; }
}

public class BaseImportDtoWithDates : BaseImportDtoWithIdAndSource
{
    [Optional]
    public DateTime? CreatedAt { get; set; }

    [Optional]
    public DateTime? UpdatedAt { get; set; }
}

public class BaseImportDto : BaseImportDtoWithDates
{
    [Optional]
    public string? CreatedByIp { get; set; }

    [Optional]
    public string? CreatedById { get; set; }

    [Optional]
    public string? CreatedByUserAgent { get; set; }

    [Optional]
    public string? UpdatedByIp { get; set; }

    [Optional]
    public string? UpdatedById { get; set; }

    [Optional]
    public string? UpdatedByUserAgent { get; set; }
}