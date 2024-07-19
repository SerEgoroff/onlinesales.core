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