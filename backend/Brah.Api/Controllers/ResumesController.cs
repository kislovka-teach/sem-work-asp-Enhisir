using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Exceptions;
using Brah.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
public class ResumesController(
    IDisplayResumesService displayResumesService,
    IResumeService resumeService,
    ITagsService tagsService
) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get(
        string? search = null,
        int? leftSalaryBorder = null,
        int? rightSalaryBorder = null,
        int[]? tags = null,
        Grade? grade = null)
    {
        var list = await displayResumesService.GetRange(
            profession: search,
            leftSalaryBorder: leftSalaryBorder,
            rightSalaryBorder: rightSalaryBorder,
            tags: tags,
            grade: grade);
        return Results.Ok(list);
    }

    [HttpGet("{userName}")]
    public async Task<IResult> GetByUserName(string userName)
    {
        try
        {
            var profileResponseDto =
                await displayResumesService
                    .GetByUserName(userName);
            return Results.Ok(profileResponseDto);
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }

    [HttpGet("tags")]
    public async Task<IResult> SearchArticleTags([FromQuery] string name)
        => Results.Ok(await tagsService.GetSimilarResumeTags(name));

    [HttpPost("tags/new")]
    [Authorize]
    public async Task<IResult> AddTag([FromBody] CreateTagDto tagDto)
    {
        try
        {
            await tagsService.AddResumeTag(tagDto);
            return Results.Ok();
        }
        catch (AlreadyExistsException)
        {
            return Results.Forbid();
        }
    }
    
    [HttpPost("new")]
    [Authorize]
    public async Task<IResult> Create([FromBody] CreateResumeRequestDto requestDto)
    {
        try
        {
            await resumeService.CreateResumeAsync(User.Identities.Single(), requestDto);
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
}