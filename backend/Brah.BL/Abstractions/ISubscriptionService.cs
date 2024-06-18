using System.Security.Claims;

namespace Brah.BL.Abstractions;

public interface ISubscriptionService
{
    public Task Subscribe(ClaimsIdentity identity, string authorUserName);
    public Task Unsubscribe(ClaimsIdentity identity, string authorUserName);
    public Task<bool> CheckSubscription(ClaimsIdentity identity, string authorUserName);
}