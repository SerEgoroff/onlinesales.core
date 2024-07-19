﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using SalesPro.Data;
using SalesPro.Plugin.TestPlugin.Data;
using SalesPro.Tests.TestServices;

namespace SalesPro.Tests.Environment;

public class TestApplication : WebApplicationFactory<Program>
{
    public TestApplication()
    {
        var projectDir = Directory.GetCurrentDirectory();
        var configPath = Path.Combine(projectDir, "appsettings.tests.json");

        Program.AddAppSettingsJsonFile(configPath);
    }

    public void CleanDatabase()
    {
        using (var scope = Services.CreateScope())
        {
            var dataContaxt = scope.ServiceProvider.GetRequiredService<PgDbContext>();
            RenewDatabase(dataContaxt);
            Program.CreateDefaultIdentity(scope).Wait();

            var esDbContext = scope.ServiceProvider.GetRequiredService<EsDbContext>();
            esDbContext.ElasticClient.Indices.Delete("*");
        }
    }

    public ElasticClient GetElasticClient()
    {
        using (var scope = Services.CreateScope())
        {
            var esDbContext = scope.ServiceProvider.GetRequiredService<EsDbContext>();
            return esDbContext.ElasticClient;
        }
    }

    public void PopulateBulkData<T, TS>(dynamic bulkItems)
        where T : BaseEntityWithId
        where TS : IEntityService<T>
    {
        using (var scope = Services.CreateScope())
        {
            var dataContaxt = scope.ServiceProvider.GetRequiredService<PgDbContext>();

            var saveService = scope.ServiceProvider.GetService<TS>();

            if (saveService != null)
            {
                saveService.SaveRangeAsync(bulkItems).Wait();
            }
            else
            {
                dataContaxt.AddRange(bulkItems);
            }

            dataContaxt.SaveChangesAsync().Wait();
        }
    }

    public PgDbContext? GetDbContext()
    {
        var scope = Services.CreateScope();
        var dataContext = scope.ServiceProvider.GetRequiredService<PgDbContext>();
        return dataContext;
    }

    public IMapper GetMapper()
    {
        using (var serviceScope = Services.CreateScope())
        {
            return serviceScope.ServiceProvider.GetService<IMapper>()!;
        }
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<TestPluginDbContext, TestPluginDbContext>();

            services.AddScoped<IEmailService, TestEmailService>();
            services.AddScoped<IEmailValidationExternalService, TestEmailValidationExternalService>();
            services.AddScoped<IAccountExternalService, TestAccountExternalService>();
        });

        return base.CreateHost(builder);
    }

    private void RenewDatabase(PgDbContext context)
    {
        try
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }
        catch
        {
            Thread.Sleep(1000);
            RenewDatabase(context);
        }
    }
}