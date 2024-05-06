using System.Security.Claims;
using Brah.BL.Dtos.Requests.Resume;

namespace Brah.BL.Abstractions;

public interface IResumeService
{
    public Task CreateResumeAsync(
        ClaimsIdentity identity, 
        CreateResumeRequestDto requestDto);
}