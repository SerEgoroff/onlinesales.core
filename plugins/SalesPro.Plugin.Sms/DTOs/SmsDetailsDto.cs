using System.ComponentModel.DataAnnotations;

namespace SalesPro.Plugin.Sms.DTOs;

public class SmsDetailsDto
{
    [Required]
    public string Recipient { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Message { get; set; } = string.Empty;
}