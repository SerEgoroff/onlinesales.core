// <copyright file="IDomainService.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IDomainService : IEntityService<Domain>
    {
        public Task Verify(Domain domain);

        public string GetDomainNameByEmail(string email);
    }
}