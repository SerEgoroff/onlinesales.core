using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Infrastructure;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class ActivityLogController : ControllerBase
{    
    private readonly IMapper mapper;
    private readonly ESOnlyQueryProviderFactory<ActivityLog> queryProviderFactory;

    public ActivityLogController(IMapper mapper, ESOnlyQueryProviderFactory<ActivityLog> queryProviderFactory)
    {        
        this.mapper = mapper;
        this.queryProviderFactory = queryProviderFactory;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public virtual async Task<ActionResult<List<ActivityLogDetailsDto>>> Get([FromQuery] string? query)
    {
        var qp = queryProviderFactory.BuildQueryProvider();

        var result = await qp.GetResult();
        Response.Headers.Add(ResponseHeaderNames.TotalCount, result.TotalCount.ToString());
        Response.Headers.Add(ResponseHeaderNames.AccessControlExposeHeader, ResponseHeaderNames.TotalCount);
        return Ok(mapper.Map<List<ActivityLogDetailsDto>>(result.Records));
    }
}
