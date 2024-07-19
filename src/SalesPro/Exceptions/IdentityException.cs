using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SalesPro.Exceptions;
public class IdentityException : Exception
{
    public IdentityException(IEnumerable<IdentityError> errors)
    {
        var builder = new StringBuilder();

        foreach (var error in errors)
        {
            builder.AppendLine($"Code: {error.Code} Description: {error.Description}");
        }

        ErrorMessage = builder.ToString();
    }

    public IdentityException(IdentityError error)
    {
        ErrorMessage = $"Code: {error.Code} Description: {error.Description}";
    }

    public IdentityException(string error)
    {
        ErrorMessage = error;
    }

    public string ErrorMessage { get; set; }
}