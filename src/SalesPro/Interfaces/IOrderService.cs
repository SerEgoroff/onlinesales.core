// <copyright file="IOrderService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using SalesPro.Entities;

namespace SalesPro.Interfaces;

public interface IOrderService : IEntityService<Order>
{
    public void RecalculateOrder(Order order);
}

