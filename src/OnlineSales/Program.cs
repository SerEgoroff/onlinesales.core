﻿// <copyright file="Program.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Nest;
using NSwag.Generation.AspNetCore;
using OnlineSales.Configuration;
using OnlineSales.Data;
using OnlineSales.Infrastructure;
using OnlineSales.Interfaces;
using Quartz;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace OnlineSales;

public class Program
{
    private static readonly List<string> AppSettingsFiles = new List<string>();

    private static WebApplication? app;

    public static WebApplication? GetApp()
    {
        return app;
    }

    public static void AddAppSettingsJsonFile(string path)
    {
        AppSettingsFiles.Add(path);
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        AppSettingsFiles.ForEach(path =>
        {
            builder.Configuration.AddJsonFile(path, false, true);
        });

        ConfigureLogs(builder);
        ConfigurePlugins(builder);

        builder.Configuration.AddUserSecrets(typeof(Program).Assembly);
        builder.Configuration.AddEnvironmentVariables();

        ConfigureConventions(builder);
        ConfigureControllers(builder);
        ConfigurePostgres(builder);
        ConfigureElasticsearch(builder);
        ConfigureQuartz(builder);

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDocument(ConfigureSwagger);

        app = builder.Build();

        MigrateOnStartIfRequired(app, builder);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseODataRouteDebug();
        }

        app.UseOpenApi();
        app.UseSwaggerUi3();

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    private static void ConfigureLogs(WebApplicationBuilder builder)
    {
        var elasticConfig = builder.Configuration.GetSection("ElasticSearch").Get<ElasticsearchConfig>();

        if (elasticConfig == null)
        {
            throw new MissingConfigurationException("Elasticsearch configuraiton is mandatory.");
        }

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ConfigureELK(elasticConfig))
            .CreateLogger();

        builder.Host.UseSerilog();
    }

    private static ElasticsearchSinkOptions ConfigureELK(ElasticsearchConfig elasticConfig)
    {
        var uri = new Uri(elasticConfig.Url);

        return new ElasticsearchSinkOptions(uri)
        {
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
            IndexFormat = $"{elasticConfig.IndexPrefix}-logs",
        };
    }

    private static void ConfigurePlugins(WebApplicationBuilder builder)
    {
        PluginManager.Init(builder.Configuration);
    }

    private static void MigrateOnStartIfRequired(WebApplication app, WebApplicationBuilder builder)
    {
        var migrateOnStart = builder.Configuration.GetValue<bool>("MigrateOnStart");

        if (migrateOnStart)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
                context.Database.Migrate();
            }
        }
    }

    private static void ConfigureConventions(WebApplicationBuilder builder)
    {
        builder.Services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });
    }

    private static void ConfigureControllers(WebApplicationBuilder builder)
    {
        var controllersBuilder = builder.Services.AddControllers()
            .AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
                opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            })
            .AddOData(options => options
                .Select().Filter().OrderBy()
                .SetMaxTop(10).Expand().Count()
                .SkipToken());

        foreach (var plugin in PluginManager.GetPluginList())
        {
            controllersBuilder = controllersBuilder.AddApplicationPart(plugin.GetType().Assembly).AddControllersAsServices();
            plugin.Configure(builder.Services, builder.Configuration);
        }
    }

    private static void ConfigurePostgres(WebApplicationBuilder builder)
    {
        builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApiDbContext>(
                opt =>
                {
                    var postgresConfig = builder.Configuration.GetSection("Postgres").Get<PostgresConfig>();

                    if (postgresConfig == null)
                    {
                        throw new MissingConfigurationException("Postgres configuraiton is mandatory.");
                    }

                    opt.UseNpgsql(
                        postgresConfig.ConnectionString,
                        b => b.MigrationsHistoryTable("_migrations"))
                    .UseSnakeCaseNamingConvention();
                });
    }

    private static void ConfigureElasticsearch(WebApplicationBuilder builder)
    {
        var elasticConfig = builder.Configuration.GetSection("ElasticSearch").Get<ElasticsearchConfig>();

        if (elasticConfig == null)
        {
            throw new MissingConfigurationException("Elasticsearch configuraiton is mandatory.");
        }

        builder.Services.AddElasticsearch(elasticConfig);
    }

    private static void ConfigureSwagger(AspNetCoreOpenApiDocumentGeneratorSettings settings)
    {
        settings.Title = "OnlineSales API";
        settings.Version = typeof(Program).Assembly.GetName().Version!.ToString() ?? "1.0.0";

        var swaggerConfigurators = from p in PluginManager.GetPluginList()
                                   where p is ISwaggerConfigurator
                                   select p as ISwaggerConfigurator;

        foreach (var swaggerConfigurator in swaggerConfigurators)
        {
            swaggerConfigurator.ConfigureSwagger(settings);
        }
    }

    private static void ConfigureQuartz(WebApplicationBuilder builder)
    {
        builder.Services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            q.AddJob<TaskRunner>(opts => opts.WithIdentity("TaskRunner"));

            q.AddTrigger(opts =>
                opts.ForJob("TaskRunner").WithIdentity("TaskRunner").WithCronSchedule(builder.Configuration.GetValue<string>("TaskRunner:CronSchedule") !));
        });

        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }
}