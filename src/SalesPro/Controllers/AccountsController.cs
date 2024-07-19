using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPro.Data;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Infrastructure;
using SalesPro.Interfaces;

namespace SalesPro.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
public class AccountsController : BaseControllerWithImport<Account, AccountCreateDto, AccountUpdateDto, AccountDetailsDto, AccountImportDto>
{
    private readonly CommentableControllerExtension commentableControllerExtension;

    public AccountsController(PgDbContext dbContext, IMapper mapper, IDomainService domainService, EsDbContext esDbContext, QueryProviderFactory<Account> queryProviderFactory, CommentableControllerExtension commentableControllerExtension)
        : base(dbContext, mapper, esDbContext, queryProviderFactory)
    {
        this.commentableControllerExtension = commentableControllerExtension;
    }

    [HttpGet("{id}/comments")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<CommentDetailsDto>>> GetComments(int id)
    {
        return commentableControllerExtension.ReturnComments(await commentableControllerExtension.GetCommentsForICommentable<Account>(id), this);
    }

    [HttpPost("{id}/comments")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CommentDetailsDto>> PostComment(int id, [FromBody] CommentCreateBaseDto value)
    {
        return await commentableControllerExtension.PostComment(commentableControllerExtension.CreateCommentForICommentable<Account>(value, id), this);
    }
}