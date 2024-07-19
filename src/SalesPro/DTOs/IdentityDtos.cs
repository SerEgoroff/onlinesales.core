using System.ComponentModel.DataAnnotations;

namespace SalesPro.DTOs;

public class LoginDto
{
    [Required]
    [EmailAddress]
    required public string Email { get; set; }

    [Required]
    required public string Password { get; set; }
}

public class JWTokenDto
{
    [Required]
    required public string Token { get; set; }

    [Required]
    required public DateTime Expiration { get; set; }
}