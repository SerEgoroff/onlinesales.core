using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;

[Table("deal_pipeline_stage")]
[SupportsElastic]
[SupportsChangeLog]
public class DealPipelineStage : BaseEntity
{
    [Required]
    [Searchable]
    public string Name { get; set; } = string.Empty;

    public int DealPipelineId { get; set; }

    [JsonIgnore]
    [ForeignKey("DealPipelineId")]
    public virtual DealPipeline? DealPipeline { get; set; }

    public int Order { get; set; }
}