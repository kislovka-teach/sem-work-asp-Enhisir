using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Article;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ArticlesController(
    IDisplayArticlesService displayArticlesService,
    IManageArticleService manageArticleService,
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

    [HttpPost("new")]
    [Authorize]
    public async Task<IResult> Create([FromBody] CreateArticleRequestDto requestDto)
    {
        try
        {
            await manageArticleService.CreateArticleAsync(User.Identities.Single(), requestDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
        catch (AlreadyExistsException)
        {
            return Results.Forbid();
        }
    }

    [HttpPut("{articleId:int}")]
    [Authorize]
    public async Task<IResult> Update([FromBody] UpdateArticleRequestDto requestDto)
    {
        try
        {
            await manageArticleService.UpdateArticleAsync(User.Identities.Single(), requestDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
        catch (AlreadyExistsException)
        {
            return Results.Forbid();
        }
    }

    [HttpGet("top")]
    public async Task<IResult> GetTopTen()
        => Results.Ok(await displayArticlesService.GetTop());

    [HttpGet("tags")]
    public async Task<IResult> SearchArticleTags([FromQuery] string? name)
        => Results.Ok(await tagsService.GetSimilarArticleTags(name));

    [HttpPost("tags/new")]
    [Authorize]
    public async Task<IResult> AddTag([FromBody] CreateTagDto tagDto)
    {
        try
        {
            var tag = await tagsService.AddArticleTag(tagDto);
            return Results.Ok(tag);
        }
        catch (AlreadyExistsException)
        {
            return Results.Forbid();
        }
    }
}