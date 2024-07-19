using CsvHelper.Configuration.Attributes;
using SalesPro.DataAnnotations;
using SalesPro.Entities;

namespace SalesPro.DTOs;

public class UnsubscribeDto
{
    public int ContactId { get; set; }

    public string Reason { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;
}

public class UnsubscribeDetailsDto : UnsubscribeDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }
}

public class UnsubscribeImportDto : BaseImportDtoWithIdAndSource
{
    public string Reason { get; set; } = string.Empty;

    public int ContactId { get; set; }

    [Optional]
    [SurrogateForeignKey(typeof(Contact), "Email", "ContactId")]
    public string ContactEmail { get; set; } = string.Empty;

    [Optional]
    public DateTime? CreatedAt { get; set; }
}