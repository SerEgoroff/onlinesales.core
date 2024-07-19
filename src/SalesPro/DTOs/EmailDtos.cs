using System.Text.Json.Serialization;
using SalesPro.Helpers;

namespace SalesPro.DTOs;

public class EmailVerifyDetailsDto : DomainDetailsDto
{
    public string EmailAddress { get; set; } = string.Empty;
}

public class EmailVerifyInfoDto
{
    public string EmailAddress { get; set; } = string.Empty;

    [JsonConverter(typeof(JsonHelper.BooleanConverter))]
    public bool FreeCheck { get; set; }

    [JsonConverter(typeof(JsonHelper.BooleanConverter))]
    public bool DisposableCheck { get; set; }

    [JsonConverter(typeof(JsonHelper.BooleanConverter))]
    public bool CatchAllCheck { get; set; }
}