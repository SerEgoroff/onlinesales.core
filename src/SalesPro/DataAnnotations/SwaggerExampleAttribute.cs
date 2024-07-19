namespace SalesPro.DataAnnotations;

public class SwaggerExampleAttribute<T> : Attribute
{
    public SwaggerExampleAttribute(T value)
    {
        Value = value;
    }

    public T Value { get; }
}