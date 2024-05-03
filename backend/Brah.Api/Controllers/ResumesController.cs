using Brah.BL.Abstractions;
using Brah.BL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Brah.Api.Controllers;

[Route("[controller]")]
public class ResumesController(
    IDisplayResumesService displayResumesService
) : ControllerBase
{
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
        catch (NotFoundException e)
        {
            return Results.NotFound();
        }
    }
}