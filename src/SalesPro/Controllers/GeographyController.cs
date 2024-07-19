using Microsoft.AspNetCore.Mvc;
using SalesPro.Geography;
using SalesPro.Helpers;

namespace SalesPro.Controllers;

[Route("api/[controller]")]
public class ContinentsController : ControllerBase
{
    // GET api/сontinents/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public virtual ActionResult<Dictionary<string, string>> GetAll()
    {
        var result = EnumHelper.GetEnumDescriptions<Continent>();

        return Ok(result);
    }
}

[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    // GET api/сontinents/
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public virtual ActionResult<Dictionary<string, string>> GetAll()
    {
        var result = EnumHelper.GetEnumDescriptions<Country>();

        return Ok(result);
    }
}