﻿using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace SalesPro.DTOs;

public class EmailGroupCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}

public class EmailGroupUpdateDto
{
    [MinLength(1)]
    public string? Name { get; set; }
}

public class EmailGroupDetailsDto : EmailGroupCreateDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Ignore]
    public List<EmailTemplateDetailsDto>? EmailTemplates { get; set; }
}
