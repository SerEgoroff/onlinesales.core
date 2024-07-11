// <copyright file="SendGridPlugin.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesPro.Data;
using SalesPro.Interfaces;
using SalesPro.Plugin.SendGrid.Configuration;
using SalesPro.Plugin.SendGrid.Data;
using SalesPro.Plugin.SendGrid.Tasks;
using SalesPro.SendGrid.Tasks;

namespace SalesPro.Plugin.SendGrid;

public class SendGridPlugin : IPlugin
{
    public static PluginConfig Configuration { get; private set; } = new PluginConfig();

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var pluginConfig = configuration.Get<PluginConfig>();

        if (pluginConfig != null)
        {
            Configuration = pluginConfig;
        }

        services.AddScoped<PluginDbContextBase, SendgridDbContext>();
        services.AddScoped<SendgridDbContext, SendgridDbContext>();

        services.AddScoped<ITask, SyncSuppressionsTask>();
        services.AddScoped<ITask, SyncActivityLogTask>();
    }
}