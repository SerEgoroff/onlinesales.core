// <copyright file="EmailSyncPlugin.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesPro.Data;
using SalesPro.EmailSync.Tasks;
using SalesPro.Interfaces;
using SalesPro.Plugin.EmailSync.Data;

namespace SalesPro.Plugin.EmailSync
{
    public class EmailSyncPlugin : IPlugin
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(EmailSyncPlugin));

            services.AddScoped<ITask, EmailSyncTask>();
            services.AddScoped<PluginDbContextBase, EmailSyncDbContext>();
            services.AddScoped<EmailSyncDbContext, EmailSyncDbContext>();
        }
    }
}