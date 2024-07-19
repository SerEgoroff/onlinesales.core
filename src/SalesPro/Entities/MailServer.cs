﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;

[SupportsChangeLog]
[Table("mail_server")]
[Index(nameof(Name), IsUnique = true)]
public class MailServer : BaseEntity
{
    private string name = string.Empty;

    [Required]
    [Searchable]
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value.ToLower();
        }
    }

    public bool WellKnown { get; set; } = false;

    public bool Verified { get; set; } = false;

    public int? Port { get; set; }

    public string? JoinMessage { get; set; }

    public string? HeloMessage { get; set; }    
}
