﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class StatisticsController : Controller
{
    // POST api/statistics/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual ActionResult Collect()
    {
        throw new NotSupportedException();
    }
}