using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesPro.Data;
using SalesPro.Interfaces;
using SalesPro.Plugin.EmailSync.Entities;

namespace SalesPro.Plugin.EmailSync.Data;

public class EmailSyncDbContext : PluginDbContextBase
{
    private readonly IEncryptionProvider? encryptionProvider = null;

    public EmailSyncDbContext()
        : base()
    {
    }

    public EmailSyncDbContext(DbContextOptions<PgDbContext> options, IConfiguration configuration, IHttpContextHelper httpContextHelper)
        : base(options, configuration, httpContextHelper)
    {
        var key = configuration.GetSection("EmailSync:EncryptionKey").Get<string>();
        if (key == null )
        {
            throw new ArgumentNullException(key);
        }

        encryptionProvider = new GenerateEncryptionProvider(key);
    }

    public DbSet<ImapAccount>? ImapAccounts { get; set; }

    public DbSet<ImapAccountFolder>? ImapAccountFolders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        if (encryptionProvider != null)
        {
            builder.UseEncryption(encryptionProvider);
        }            
    }
}