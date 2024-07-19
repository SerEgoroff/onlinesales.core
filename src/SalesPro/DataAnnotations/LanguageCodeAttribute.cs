using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

namespace SalesPro.DataAnnotations;

public class LanguageCodeAttribute : ValidationAttribute
{
    private readonly bool nullAllowed;

    public LanguageCodeAttribute(bool nullAllowed = false)
    {
        this.nullAllowed = nullAllowed;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (nullAllowed && value == null)
        {
            return ValidationResult.Success;
        }

        var languageCode = value as string;

        if (CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(culture => culture.Name == languageCode) == null)
        {
            return new ValidationResult("Culture not found");
        }

        return ValidationResult.Success;
    }
}