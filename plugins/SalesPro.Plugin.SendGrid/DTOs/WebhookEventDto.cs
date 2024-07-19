using Newtonsoft.Json;

namespace SalesPro.Plugin.SendGrid.DTOs;

public class WebhookEventDto : EmailDto
{
    public double Timestamp { get; set; } = 0;

    public string Event { get; set; } = string.Empty;

    [JsonProperty("sg_message_id")]
    public string SendGridMessageId { get; set; } = string.Empty;

    [JsonProperty("sg_event_id")]
    public string SendGridEventId { get; set; } = string.Empty;

    public string Reason { get; set; } = string.Empty;

    public string? Ip { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
}