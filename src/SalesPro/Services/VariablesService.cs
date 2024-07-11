// <copyright file="VariablesService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using SalesPro.Infrastructure;
using SalesPro.Interfaces;

namespace SalesPro.Services;

public class VariablesService : IVariablesService
{
    private readonly IEnumerable<IVariablesProvider> variableProviders;

    public VariablesService(IEnumerable<IVariablesProvider> variableProviders)
    {
        this.variableProviders = variableProviders;
    }

    public Dictionary<string, string> GetVariables(string language)
    {
        var variables = new Dictionary<string, string>();

        foreach (var variableProvider in variableProviders)
        {
            variables.AddRangeIfNotExists(variableProvider.GetVariables(language));
        }

        return variables;
    }
}