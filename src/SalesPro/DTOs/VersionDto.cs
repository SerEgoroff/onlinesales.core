using Microsoft.Extensions.Primitives;

namespace SalesPro.DTOs;
public class VersionDto
{
    public string? Version { get; set; } = string.Empty;

    public string? IP { get; set; } = string.Empty;

    public string? IPv4 { get; set; } = string.Empty;

    public string? IPv6 { get; set; } = string.Empty;

    public List<KeyValuePair<string, StringValues>> Headers { get; set; } = new List<KeyValuePair<string, StringValues>>();
}
