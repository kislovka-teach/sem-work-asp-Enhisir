using Brah.BL.Abstractions;
using Brah.BL.Exceptions;
using Brah.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
public class ResumesController(
    IDisplayResumesService displayResumesService,
    ISearchResumeTagsService searchResumeTagsService
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
    {
        return Results.Ok(
            await searchResumeTagsService
                .GetSimilarTags(name));
    }
}