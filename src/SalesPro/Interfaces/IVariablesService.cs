namespace SalesPro.Interfaces
{
    public interface IVariablesService
    {
        public Dictionary<string, string> GetVariables(string language);
    }
}