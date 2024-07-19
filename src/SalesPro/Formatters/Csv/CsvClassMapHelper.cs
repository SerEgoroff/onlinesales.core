using System.Globalization;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;

namespace SalesPro.Formatters.Csv;

public static class CsvClassMapHelper
{
    public static void RegisterCamelCaseClassMap(this CsvContext csvContext, Type itemType)
    {
        var mapType = typeof(DefaultClassMap<>);
        var constructedMapType = mapType.MakeGenericType(itemType!);

        var map = (ClassMap)Activator.CreateInstance(constructedMapType)!;
        map.AutoMap(CultureInfo.InvariantCulture);

        foreach (var memberMapData in map.MemberMaps.Select(m => m.Data))
        {
            memberMapData.Names.Add(JsonNamingPolicy.CamelCase.ConvertName(memberMapData.Member!.Name));
        }

        csvContext.RegisterClassMap(map);
    }
}