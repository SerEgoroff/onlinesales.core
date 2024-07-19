using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesPro.Data;
using SalesPro.Plugin.Sms.Configuration;
using SalesPro.Plugin.Sms.Data;
using SalesPro.Plugin.Sms.Services;
using SalesPro.Plugin.Sms.Tasks;

namespace SalesPro.Plugin.Sms;

public class SmsPlugin : IPlugin
{
    public static PluginConfig Configuration { get; private set; } = new PluginConfig();

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var pluginConfig = configuration.Get<PluginConfig>();

        if (pluginConfig != null)
        {
            Configuration = pluginConfig;
        }

        services.AddScoped<PluginDbContextBase, SmsDbContext>();
        services.AddScoped<SmsDbContext, SmsDbContext>();
        
        services.AddSingleton<ISmsService, SmsService>();

        services.AddScoped<ITask, SyncSmsLogTask>();
    }
}