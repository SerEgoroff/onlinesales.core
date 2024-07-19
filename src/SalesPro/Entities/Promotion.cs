using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Nest;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;

[Table("promotion")]
[SupportsElastic]
[SupportsChangeLog]
[Index(nameof(Code), IsUnique = true)]

public class Promotion : BaseEntity 
{
    [Required]
    public string Code { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}