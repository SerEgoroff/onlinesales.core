namespace SalesPro.DataAnnotations;

[AttributeUsage(AttributeTargets.Class)]
public class SurrogateIdentityAttribute : Attribute
{
    public SurrogateIdentityAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; set; }
}