using System.Text;

namespace SalesPro.Helpers;

public static class UidHelper
{
    private static Random random = new Random();

    private static char[] base62chars =
        "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        .ToCharArray();

    public static string Generate(int length = 6)
    {
        var sb = new StringBuilder(length);

        for (var i = 0; i < length; i++)
        {
            sb.Append(base62chars[random.Next(62)]);
        }

        return sb.ToString();
    }
}