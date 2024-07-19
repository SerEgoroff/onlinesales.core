using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Data;
using SalesPro.Entities;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class LogsController : Controller
{
    protected readonly EsDbContext esDbContext;

    public LogsController(EsDbContext esDbContext)
    {
        this.esDbContext = esDbContext;
    }

    // GET api/logs/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public virtual async Task<ActionResult<List<LogRecord>>> GetAll()
    {
        var logRecords = (
                await esDbContext.ElasticClient.SearchAsync<LogRecord>(
                    s => s.Size(20).Skip(10)))
            .Documents.ToList();

        return Ok(logRecords);
    }
}