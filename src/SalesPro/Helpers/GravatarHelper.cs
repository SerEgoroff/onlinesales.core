using System.Security.Cryptography;
using System.Text;

namespace SalesPro.Helpers;

public class GravatarHelper
{
    public static string EmailToGravatarUrl(string email)
    {
        var emailBytes = Encoding.ASCII.GetBytes(email);
        var emailHashCode = MD5.Create().ComputeHash(emailBytes);

        return "https://www.gravatar.com/avatar/" + Convert.ToHexString(emailHashCode).ToLower() + "?size=48&d=mp";
    }
}