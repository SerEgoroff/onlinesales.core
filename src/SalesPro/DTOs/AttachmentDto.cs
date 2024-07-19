using System.ComponentModel.DataAnnotations;

namespace SalesPro.DTOs;

public class AttachmentDto
{
    /// <summary>
    /// Gets or sets the email attachment converted to a byte array.
    /// </summary>
    [Required]
    public byte[] File { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// Gets or sets the attachment file name with the extension.
    /// </summary>
    [Required]
    public string FileName { get; set; } = string.Empty;
}