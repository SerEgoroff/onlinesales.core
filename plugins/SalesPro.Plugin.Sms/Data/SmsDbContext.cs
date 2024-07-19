using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesPro.Data;
using SalesPro.Plugin.Sms.Entities;

namespace SalesPro.Plugin.Sms.Data;

public class SmsDbContext : PluginDbContextBase
{
    public SmsDbContext(DbContextOptions<PgDbContext> options, IConfiguration configuration, IHttpContextHelper httpContextHelper)
        : base(options, configuration, httpContextHelper)
    {
    }

    public DbSet<SmsLog>? SmsLogs { get; set; }
}