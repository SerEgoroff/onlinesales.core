// <copyright file="SearchableAttribute.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace SalesPro.DataAnnotations;

[AttributeUsage(AttributeTargets.Property)]
public class SearchableAttribute : Attribute
{
}