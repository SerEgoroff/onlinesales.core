﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Data;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Infrastructure;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class EmailGroupsController : BaseController<EmailGroup, EmailGroupCreateDto, EmailGroupUpdateDto, EmailGroupDetailsDto>
{
    public EmailGroupsController(PgDbContext dbContext, IMapper mapper, EsDbContext esDbContext, QueryProviderFactory<EmailGroup> queryProviderFactory)
    : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
    }
}