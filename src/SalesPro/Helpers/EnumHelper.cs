using System.ComponentModel;
using System.Reflection;

namespace SalesPro.Helpers;

public static class EnumHelper
{
    public static Dictionary<string, string> GetEnumDescriptions<TEnum>()
        where TEnum : Enum
    {
        var descriptions = new Dictionary<string, string>();
        foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
        {
            var descriptionAttribute = value.GetType().GetField(value.ToString())!
                .GetCustomAttribute<DescriptionAttribute>();

            var description = descriptionAttribute?.Description ?? value.ToString();
            descriptions[value.ToString()] = description;
        }

        return descriptions;
    }
}