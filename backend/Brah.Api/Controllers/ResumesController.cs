using Brah.BL.Abstractions;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Exceptions;
using Brah.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[ApiController]
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

    [HttpGet("me")]
    [Authorize]
    public async Task<IResult> GetMyResume()
    {
        try
        {
            var profileResponseDto =
                await displayResumesService
                    .GetByUserName(User.Identities.Single().Name!);
            return Results.Ok(profileResponseDto);
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }

    [HttpPost("me")]
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

    [HttpPut("me")]
    [Authorize]
    public async Task<IResult> Update([FromBody] UpdateResumeRequestDto requestDto)
    {
        try
        {
            await resumeService.UpdateResumeAsync(User.Identities.Single(), requestDto);
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

    [HttpPost("workplaces/new")]
    [Authorize]
    public async Task<IResult> AddWorkplace([FromBody] CreateWorkPlaceDto workPlaceDto)
    {
        try
        {
            await resumeService
                .AddWorkPlaceAsync(User.Identities.Single(), workPlaceDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }

    [HttpPut("workplaces/{workPlaceId:int}")]
    [Authorize]
    public async Task<IResult> UpdateWorkplace([FromBody] UpdateWorkPlaceDto workPlaceDto)
    {
        try
        {
            await resumeService
                .UpdateWorkPlaceAsync(User.Identities.Single(), workPlaceDto);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }

    [HttpDelete("workplaces/{workPlaceId:int}")]
    [Authorize]
    public async Task<IResult> DeleteWorkPlace(int workPlaceId)
    {
        try
        {
            await resumeService
                .RemoveWorkplaceAsync(User.Identities.Single(), workPlaceId);
            return Results.Ok();
        }
        catch (NotFoundException)
        {
            return Results.NotFound();
        }
    }
}