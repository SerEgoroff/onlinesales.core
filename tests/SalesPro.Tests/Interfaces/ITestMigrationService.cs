namespace SalesPro.Tests.Interfaces
{
    public interface ITestMigrationService 
    {
        (bool, string) MigrateUpToAndCheck(string name);
    }
}