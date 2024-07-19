using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;

[Table("unsubscribe")]
[SupportsChangeLog]
[SupportsElastic]
public class Unsubscribe : BaseCreateByEntity
{
    [Searchable]
    public string Reason { get; set; } = string.Empty;
    
    public int? ContactId { get; set; }

    [JsonIgnore]
    [ForeignKey("ContactId")]
    public virtual Contact? Contact { get; set; }
}