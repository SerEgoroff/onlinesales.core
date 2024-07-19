using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SalesPro.Interfaces;

public interface ISwaggerConfigurator
{
    void ConfigureSwagger(SwaggerGenOptions options, OpenApiInfo settings);
}