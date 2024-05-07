using System.Security.Claims;
using Brah.BL.Dtos.Requests.Resume;

namespace Brah.BL.Abstractions;

public interface IResumeService
{
    public Task CreateResumeAsync(
        ClaimsIdentity identity, 
        CreateResumeRequestDto requestDto);
    
    public Task UpdateResumeAsync(
        ClaimsIdentity identity, 
        UpdateResumeRequestDto requestDto);
    
    public Task AddWorkPlaceAsync(
        ClaimsIdentity identity, 
        CreateWorkPlaceDto requestDto);

    public Task UpdateWorkPlaceAsync(
        ClaimsIdentity identity,
        UpdateWorkPlaceDto requestDto);
    
    public Task RemoveWorkplaceAsync(
        ClaimsIdentity identity, 
        int workplaceId);
}