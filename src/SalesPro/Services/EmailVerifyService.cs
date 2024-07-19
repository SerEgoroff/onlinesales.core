﻿using Microsoft.EntityFrameworkCore;
using SalesPro.Data;
using SalesPro.Entities;
using SalesPro.Interfaces;

namespace SalesPro.Services
{
    public class EmailVerifyService : IEmailVerifyService
    {
        private readonly PgDbContext pgContext;
        private readonly IDomainService domainService;
        private readonly IEmailValidationExternalService emailValidationExternalService;

        public EmailVerifyService(PgDbContext pgDbContext, IDomainService domainService, IEmailValidationExternalService emailValidationExternalService)
        {
            pgContext = pgDbContext;
            this.domainService = domainService;
            this.emailValidationExternalService = emailValidationExternalService;
        }

        public async Task<Domain> Verify(string email)
        {
            var domainName = domainService.GetDomainNameByEmail(email);

            var domain = await (from d in pgContext.Domains
                                where d.Name == domainName
                                select d).FirstOrDefaultAsync();

            if (domain != null && domain.DnsCheck is true)
            {
                return domain;
            }
            else
            {
                if (domain is null)
                {
                    domain = new Domain() { Name = domainName, Source = email };
                    await domainService.SaveAsync(domain);
                }

                await domainService.Verify(domain!);
                await VerifyDomain(email, domain);
                await pgContext.SaveChangesAsync();

                return domain;
            }
        }

        public async Task VerifyDomain(string email, Domain domain)
        {
            var emailVerify = await emailValidationExternalService.Validate(email);
            domain.CatchAll = emailVerify.CatchAllCheck;
        }
    }
}