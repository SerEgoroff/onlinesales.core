using SalesPro.Data;
using SalesPro.Entities;

namespace SalesPro.Interfaces;

public interface IEmailSchedulingService
{
    Task<EmailSchedule?> FindByGroupAndLanguage(string groupName, string languageCode);

    void SetDBContext(PgDbContext pgDbContext);
}

