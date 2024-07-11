// <copyright file="VstoDbContext.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesPro.Data;
using SalesPro.Plugin.Vsto.Entities;

namespace SalesPro.Plugin.Vsto.Data;

public class VstoDbContext : PluginDbContextBase
{
    public VstoDbContext()
        : base()
    {
    }

    public VstoDbContext(DbContextOptions<PgDbContext> options, IConfiguration configuration, IHttpContextHelper httpContextHelper)
        : base(options, configuration, httpContextHelper)
    {
    }

    // Below is the line of code showcasing how a new entity could be added on the plugin level
    public virtual DbSet<VstoUserVersion>? VstoUserVersions { get; set; }
}