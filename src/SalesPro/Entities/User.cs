﻿using Microsoft.AspNetCore.Identity;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities;
public class User : IdentityUser
{
    public string AvatarUrl { get; set; } = string.Empty;

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastTimeLoggedIn { get; set; }

    [Searchable]
    public string DisplayName { get; set; } = string.Empty;

    public Dictionary<string, object>? Data { get; set; }
}