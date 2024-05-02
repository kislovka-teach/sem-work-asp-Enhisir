using Brah.BL.Dtos.Responses;

namespace Brah.BL.Abstractions;

public interface IDisplayProfileService
{
    public Task<ProfileResponseDto> GetById(int id);
}