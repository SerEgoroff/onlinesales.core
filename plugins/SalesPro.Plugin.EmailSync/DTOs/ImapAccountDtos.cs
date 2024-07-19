﻿using System.ComponentModel.DataAnnotations;

namespace SalesPro.Plugin.EmailSync.DTOs;

public class ImapAccountBaseDto
{
    [Required]
    public string Host { get; set; } = string.Empty;

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public int Port { get; set; }

    [Required]
    public bool UseSsl { get; set; }
}

public class ImapAccountCreateDto : ImapAccountBaseDto
{
    [Required]
    public string Password { get; set; } = string.Empty;
}

public class ImapAccountUpdateDto
{
    public string? Host { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }   

    public int? Port { get; set; }

    public bool? UseSsl { get; set; }
}

public class ImapAccountDetailsDto : ImapAccountBaseDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
