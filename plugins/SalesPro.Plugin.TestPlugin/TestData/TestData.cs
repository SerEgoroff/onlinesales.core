using SalesPro.Plugin.TestPlugin.Entities;

namespace SalesPro.Plugin.TestPlugin.TestData;
public class ChangeLogMigrationsTestData
{
    public const int NumberOfDeletedEntities = 3;

    public const int NumberOfRecords = 10;

    public const int AddedColumnDefaultValue = 7;

    public const string AddedColumnName = "int_field";

    static ChangeLogMigrationsTestData()
    {
        InsertionData = new List<string>();
        for (int i = 0; i < NumberOfRecords; ++i)
        {
            InsertionData.Add($"StringField{i}");
        }
    }

    public static List<string> InsertionData { get; }
}