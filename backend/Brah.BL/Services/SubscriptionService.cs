using System.Security.Claims;
using Brah.BL.Abstractions;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models;

namespace Brah.BL.Services;

public class SubscriptionService(
    IUserRepository userRepository,
    IRepository<Subscription> subRepository
    ) : ISubscriptionService
{
    public async Task Subscribe(ClaimsIdentity identity, string authorUserName)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(identity.Name), 
                includeSubscriptions: true);
        if (user == null) throw new NotFoundException();
        if (user.UserName.Equals(authorUserName)) throw new ForbiddenException();
        
        var author = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(authorUserName), 
                includeSubscriptions: true);
        if (author == null) throw new NotFoundException();

        if (user.Subscriptions.Select(s => s.AuthorId).Contains(author.Id))
            throw new AlreadyExistsException();

        var sub = new Subscription
        {
            ReaderId = user.Id,
            AuthorId = author.Id
        };
        await subRepository.AddAsync(sub);
    }

    public async Task Unsubscribe(ClaimsIdentity identity, string authorUserName)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(identity.Name), 
                includeSubscriptions: true);
        if (user == null) throw new NotFoundException();
        if (user.UserName.Equals(authorUserName)) throw new ForbiddenException();
        
        var author = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(authorUserName), 
                includeSubscriptions: true);
        if (author == null) throw new NotFoundException();

        if (!user.Subscriptions.Select(s => s.AuthorId).Contains(author.Id))
            throw new NotFoundException();

        var sub = new Subscription
        {
            ReaderId = user.Id,
            AuthorId = author.Id
        };
        await subRepository.RemoveAsync(sub);
    }

    public async Task<bool> CheckSubscription(ClaimsIdentity identity, string authorUserName)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(identity.Name), 
                includeSubscriptions: true);
        if (user == null) throw new NotFoundException();
        
        var author = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(authorUserName), 
                includeSubscriptions: true);
        if (author == null) throw new NotFoundException();

        return user.Subscriptions.Select(s => s.AuthorId).Contains(author.Id);
    }
}