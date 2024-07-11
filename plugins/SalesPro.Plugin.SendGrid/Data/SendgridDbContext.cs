﻿// <copyright file="SendgridDbContext.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesPro.Data;
using SalesPro.Interfaces;
using SalesPro.Plugin.SendGrid.Entities;

namespace SalesPro.Plugin.SendGrid.Data;

public class SendgridDbContext : PluginDbContextBase
{
    public SendgridDbContext()
        : base()
    {
    }

    public SendgridDbContext(DbContextOptions<PgDbContext> options, IConfiguration configuration, IHttpContextHelper httpContextHelper)
        : base(options, configuration, httpContextHelper)
    {
    }

    public DbSet<SendgridEvent>? SendgridEvents { get; set; }
}