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
public class PromotionController : BaseController<Promotion, PromotionCreateDto, PromotionUpdateDto, PromotionDetailsDto>
{
    public PromotionController(PgDbContext dbContext, IMapper mapper, EsDbContext esDbContext, QueryProviderFactory<Promotion> queryProviderFactory)
        : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
    }
}