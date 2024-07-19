﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesPro.DataAnnotations;
using SalesPro.Entities;

namespace SalesPro.Plugin.Sms.Entities;

[Table("sms_log")]
[SupportsElastic]
[SupportsChangeLog]

public class SmsLog : BaseCreateByEntity
{
    public enum SmsStatus
    {
        NotSent = 0,
        Sent = 1,
    }

    [Searchable]
    [Required]
    public string Sender { get; set; } = string.Empty;

    [Searchable]
    [Required]
    public string Recipient { get; set; } = string.Empty;

    [Searchable]
    [Required]
    public string Message { get; set; } = string.Empty;

    [Required]
    public SmsStatus Status { get; set; }
}