namespace SalesPro.Interfaces;

public interface IVariablesProvider
{
    public Dictionary<string, string> GetVariables(string language);
}