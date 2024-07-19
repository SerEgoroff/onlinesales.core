namespace SalesPro.Interfaces
{
    public interface IPlugin
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }

    public interface IPluginApplication
    {
        public void ConfigureApplication(IApplicationBuilder application);
    }
}