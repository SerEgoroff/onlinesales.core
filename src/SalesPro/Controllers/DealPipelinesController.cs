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
public class DealPipelinesController : BaseController<DealPipeline, DealPipelineCreateDto, DealPipelineUpdateDto, DealPipelineDetailsDto>
{
    public DealPipelinesController(PgDbContext dbContext, IMapper mapper, EsDbContext esDbContext, QueryProviderFactory<DealPipeline> queryProviderFactory)
    : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
    }
}