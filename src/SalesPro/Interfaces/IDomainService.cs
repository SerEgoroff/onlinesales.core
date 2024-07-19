using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface IDomainService : IEntityService<Domain>
    {
        public Task Verify(Domain domain);

        public string GetDomainNameByEmail(string email);
    }
}