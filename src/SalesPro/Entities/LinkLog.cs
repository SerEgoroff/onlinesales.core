﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;

[Table("link_log")]
public class LinkLog : BaseCreateByEntity
{
    [Required]
    public int LinkId { get; set; }

    [JsonIgnore]
    [ForeignKey("LinkId")]
    public virtual Link? Link { get; set; }

    [Required]
    [Searchable]
    public string Destination { get; set; } = string.Empty;

    public string? Referrer { get; set; }
}