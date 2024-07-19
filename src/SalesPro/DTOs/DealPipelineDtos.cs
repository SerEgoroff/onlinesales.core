using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;
using SalesPro.DataAnnotations;

namespace SalesPro.DTOs;

public class DealPipelineCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}

public class DealPipelineUpdateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}

public class DealPipelineDetailsDto : DealPipelineCreateDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [Ignore]
    public List<DealPipelineStageDetailsDto>? PipelineStages { get; set; }
}
