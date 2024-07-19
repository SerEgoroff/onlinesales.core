﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesPro.Configuration;
using SalesPro.Data;
using SalesPro.Entities;
using SalesPro.Interfaces;

namespace SalesPro.Services;

public class EmailSchedulingService : IEmailSchedulingService
{
    private readonly IOptions<ApiSettingsConfig> apiSettingsConfig;

    private PgDbContext dbContext;

    public EmailSchedulingService(PgDbContext dbContext, IOptions<ApiSettingsConfig> apiSettingsConfig)
    {
        this.dbContext = dbContext;
        this.apiSettingsConfig = apiSettingsConfig;
    }

    public async Task<EmailSchedule?> FindByGroupAndLanguage(string groupName, string languageCode)
    {
        EmailSchedule? result;

        // Check if contact.Language is in two-letter format and adjust query accordingly
        var emailSchedulesQuery = dbContext.EmailSchedules!
            .Include(c => c.Group)
            .Where(e => e.Group!.Name == groupName);

        if (languageCode.Length == 2)
        {
            result = await emailSchedulesQuery.Where(
                            e => e.Group!.Language.StartsWith(languageCode)).FirstOrDefaultAsync();
        }
        else
        {
            result = await emailSchedulesQuery.Where(
                            e => e.Group!.Language == languageCode).FirstOrDefaultAsync();

            if (result == null)
            {
                var lang = languageCode.Split('-')[0];

                result = await emailSchedulesQuery.Where(
                                e => e.Group!.Language.StartsWith(lang)).FirstOrDefaultAsync();
            }
        }

        if (result == null)
        {
            result = await emailSchedulesQuery.Where(
                            e => e.Group!.Language == apiSettingsConfig.Value.DefaultLanguage).FirstOrDefaultAsync();
        }

        return result;
    }

    public void SetDBContext(PgDbContext pgDbContext)
    {
        dbContext = pgDbContext;
    }
}

