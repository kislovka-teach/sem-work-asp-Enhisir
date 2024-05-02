using Brah.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
public class ArticlesController(
    IDisplayArticlesService displayArticlesService
) : ControllerBase
{
    [HttpGet("/")]
    public async Task<IResult> GetArticlesCatalog(
        [FromQuery] string? title = null,
        [FromQuery] int? skip = null,
        [FromQuery] int? take = null)
    {
        return Results.Ok(
            await displayArticlesService.GetFiltered(
                title: title,
                skip: skip,
                take: take));
    }
}