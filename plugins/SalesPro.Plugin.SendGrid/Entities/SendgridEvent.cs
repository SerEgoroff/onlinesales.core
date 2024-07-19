using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Nest;
using SalesPro.Entities;

namespace SalesPro.Plugin.SendGrid.Entities;

[Table("sendgrid_event")]
public class SendgridEvent : BaseEntityWithId
{
    public DateTime CreatedAt { get; set; }

    public string Event { get; set; } = string.Empty;

    public string MessageId { get; set; } = string.Empty;

    public string Reason { get; set; } = string.Empty;

    public string? Ip { get; set; } = string.Empty;

    public string? EventId { get; set; } = string.Empty;

    public int? ContactId { get; set; }

    [Ignore]
    [JsonIgnore]
    [ForeignKey("ContactId")]
    public virtual Contact? Contact { get; set; }
}