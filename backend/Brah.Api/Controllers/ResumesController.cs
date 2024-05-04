using Brah.BL.Abstractions;
using Brah.BL.Exceptions;
using Brah.Data.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
public class ResumesController(
    IDisplayResumesService displayResumesService
) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> Get(
        string? profession = null,
        int? leftSalaryBorder = null,
        int? rightSalaryBorder = null,
        int[]? tags = null,
        Grade[]? grades = null)
    {
        var list = await displayResumesService.GetRange(
            profession: profession,
            leftSalaryBorder: leftSalaryBorder,
            rightSalaryBorder: rightSalaryBorder,
            tags: tags,
            grades: grades);
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
}