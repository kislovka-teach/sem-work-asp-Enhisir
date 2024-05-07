using Brah.BL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ArticlesController(
    IDisplayArticlesService displayArticlesService,
    ITagsService tagsService
) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get(
        [FromQuery] string? search = null,
        [FromQuery] int? skip = null,
        [FromQuery] int? take = null,
        [FromQuery] int? topic = null,
        [FromQuery] int[]? tags = null)
    {
        return Results.Ok(
            await displayArticlesService.GetRange(
                title: search,
                skip: skip,
                take: take,
                topic: topic,
                tags: tags));
    }

    [HttpGet("{articleId:int}")]
    public async Task<IResult> GetById(int articleId)
    {
        return Results.Ok(await displayArticlesService.GetById(articleId));
    }

    [HttpGet("top")]
    public async Task<IResult> GetTopTen()
        => Results.Ok(await displayArticlesService.GetTop());

    [HttpGet("tags")]
    public async Task<IResult> SearchArticleTags([FromQuery] string? name)
        => Results.Ok(await tagsService.GetSimilarArticleTags(name));
}