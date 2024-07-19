namespace SalesPro.Helpers;

public static class TokenHelper
{
    public static string ReplaceTokensFromVariables(Dictionary<string, string> variables, string stringToReplace)
    {
        foreach (var variable in variables)
        {
            stringToReplace = stringToReplace.Replace(variable.Key, variable.Value);
        }

        return stringToReplace;
    }
}