using System.ComponentModel.DataAnnotations;
using SalesPro.DataAnnotations;

namespace SalesPro.DTOs
{
    public class ImageCreateDto
    {
        [Required]
        [MediaExtension]
        public IFormFile? Image { get; set; }

        [Required]
        public string ScopeUid { get; set; } = string.Empty;
    }
}