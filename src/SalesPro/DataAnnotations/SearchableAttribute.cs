using System.ComponentModel.DataAnnotations;

namespace SalesPro.DataAnnotations;

[AttributeUsage(AttributeTargets.Property)]
public class SearchableAttribute : Attribute
{
}