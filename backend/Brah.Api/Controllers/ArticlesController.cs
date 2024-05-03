using Brah.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
public class ArticlesController(
    IDisplayArticlesService displayArticlesService,
    ISearchArticleTagsService searchArticleTagsService
) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get(
        [FromQuery] string? title = null,
        [FromQuery] int? skip = null,
        [FromQuery] int? take = null,
        [FromQuery] int[]? tags = null)
    {
        return Results.Ok(
            await displayArticlesService.GetRange(
                title: title,
                skip: skip,
                take: take,
                tags: tags));
    }

    [HttpGet("{articleId:int}")]
    public async Task<IResult> GetById(int articleId)
    {
        return Results.Ok(await displayArticlesService.GetById(articleId));
    }

    [HttpGet("top")]
    public async Task<IResult> GetTopTen()
    {
        return Results.Ok(await displayArticlesService.GetTop());
    }

    [HttpGet("tags")]
    public async Task<IResult> SearchArticleTags([FromQuery] string name)
    {
        return Results.Ok(
            await searchArticleTagsService
                .GetSimilarTags(name));
    }
}