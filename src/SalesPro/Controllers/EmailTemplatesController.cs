// <copyright file="EmailTemplatesController.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Data;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Infrastructure;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class EmailTemplatesController : BaseController<EmailTemplate, EmailTemplateCreateDto, EmailTemplateUpdateDto, EmailTemplateDetailsDto>
{
    public EmailTemplatesController(PgDbContext dbContext, IMapper mapper, EsDbContext esDbContext, QueryProviderFactory<EmailTemplate> queryProviderFactory)
    : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
    }
}