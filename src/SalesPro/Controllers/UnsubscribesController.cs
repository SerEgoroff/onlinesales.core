// <copyright file="UnsubscribesController.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Data;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Infrastructure;
using SalesPro.Interfaces;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class UnsubscribesController : BaseControllerWithImport<Unsubscribe, UnsubscribeDto, UnsubscribeDto, UnsubscribeDetailsDto, UnsubscribeImportDto>
{
    public UnsubscribesController(PgDbContext dbContext, IMapper mapper, IDomainService domainService, EsDbContext esDbContext, QueryProviderFactory<Unsubscribe> queryProviderFactory)
        : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
    }
}