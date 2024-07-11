// <copyright file="LinksController.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Data;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Helpers;
using SalesPro.Infrastructure;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class LinksController : BaseControllerWithImport<Link, LinkCreateDto, LinkUpdateDto, LinkDetailsDto, LinkImportDto>
{
    public LinksController(PgDbContext dbContext, IMapper mapper, EsDbContext esDbContext, QueryProviderFactory<Link> queryProviderFactory)
        : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
    }

    // POST api/links
    [HttpPost]
    public override Task<ActionResult<LinkDetailsDto>> Post([FromBody] LinkCreateDto link)
    {
        if (string.IsNullOrEmpty(link.Uid))
        {
            link.Uid = UidHelper.Generate();
        }

        return base.Post(link);
    }
}