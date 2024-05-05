using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Responses;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;

namespace Brah.BL.Services;

public class DisplayProfileService(
    IMapper mapper,
    IUserRepository userRepository)
    : IDisplayProfileService
{
    public async Task<ProfileResponseDto> GetByUserName(string userName)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                t => t.UserName == userName,
                includeArticles: true, includeResume: true);

        if (user is null) throw new NotFoundException();
        return mapper.Map<ProfileResponseDto>(user);
    }
}