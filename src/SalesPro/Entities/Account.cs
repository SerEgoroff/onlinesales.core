﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SalesPro.DataAnnotations;
using SalesPro.Geography;

namespace SalesPro.Entities;

[Table("account")]
[SupportsElastic]
[SupportsChangeLog]
[Index(nameof(Name), IsUnique = true)]
public class Account : BaseEntity, ICommentable
{
    [Searchable]
    public string Name { get; set; } = string.Empty;

    [Searchable]
    public string? CityName { get; set; }

    [Searchable]
    public string? State { get; set; }

    [Searchable]
    public Continent? ContinentCode { get; set; }

    [Searchable]
    public Country? CountryCode { get; set; }

    [Searchable]
    public string? SiteUrl { get; set; }

    public string? LogoUrl { get; set; }

    [Searchable]
    public string? EmployeesRange { get; set; }

    [Searchable]
    public double? Revenue { get; set; }

    [Searchable]
    [Column(TypeName = "jsonb")]
    public string[]? Tags { get; set; }

    [Searchable]
    [Column(TypeName = "jsonb")]
    public Dictionary<string, string>? SocialMedia { get; set; }

    [Searchable]
    [Column(TypeName = "jsonb")]
    public string? Data { get; set; }

    [JsonIgnore]
    public virtual ICollection<Contact>? Contacts { get; set; }

    [JsonIgnore]
    public virtual ICollection<Domain>? Domains { get; set; }

    [JsonIgnore]
    public virtual ICollection<Deal>? Deals { get; set; }

    public static string GetCommentableType()
    {
        return "Account";
    }
}