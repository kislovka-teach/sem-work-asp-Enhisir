using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Dtos.Responses;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;

namespace Brah.BL.Services;

public class DisplayProfileService(
    IMapper mapper,
    ISubscriptionService subscriptionService,
    IUserRepository userRepository)
    : IDisplayProfileService
{
    public async Task<ProfileResponseDto> GetByUserName(string userName, ClaimsIdentity? identity = null)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                t => t.UserName == userName,
                includeArticles: true, includeResume: true);

        if (user is null) throw new NotFoundException();
        var result = mapper.Map<ProfileResponseDto>(user);
        result.Subscribed = identity != null
                            && await subscriptionService
                                .CheckSubscription(identity, userName);
        return result;
    }
}