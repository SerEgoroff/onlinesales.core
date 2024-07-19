﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.EntityFrameworkCore;
using SalesPro.DataAnnotations;
using SalesPro.Entities;

namespace SalesPro.Plugin.EmailSync.Entities;

[Table("imap_account")]
[SupportsChangeLog]
[Index(nameof(Host), nameof(UserName), IsUnique = true)]
public class ImapAccount : BaseEntity
{
    public string Host { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    [EncryptColumn]
    public string Password { get; set; } = string.Empty;

    public int Port { get; set; }

    public bool UseSsl { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}