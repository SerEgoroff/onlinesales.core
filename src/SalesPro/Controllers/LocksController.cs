using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Interfaces;

namespace SalesPro.Controllers;

[Authorize]
[Route("api/[controller]")]
public class LocksController : ControllerBase
{
    protected readonly ILockService lockService;

    public LocksController(ILockService lockService)
    {
        this.lockService = lockService;
    }

    [HttpGet("{key}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult Lock(string key)
    {
        return Ok();
    }

    [HttpGet("{key}/release")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult Release(string key)
    {
        return Ok();
    }
}