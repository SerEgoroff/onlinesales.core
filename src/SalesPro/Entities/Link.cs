using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;

[Table("link")]
[Index(nameof(Uid), IsUnique = true)]
[SupportsChangeLog]
public class Link : BaseEntity
{
    [Required]
    [Searchable]
    public string Uid { get; set; } = string.Empty;

    [Required]
    [Searchable]
    public string Destination { get; set; } = string.Empty;

    [Required]
    [Searchable]
    public string Name { get; set; } = string.Empty;
}