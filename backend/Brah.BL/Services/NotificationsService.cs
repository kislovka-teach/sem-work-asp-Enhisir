using System.Security.Claims;
using AutoMapper;
using Brah.BL.Abstractions;
using Brah.BL.Exceptions;
using Brah.Data.Abstractions;
using Brah.Data.Models;
using Notification = Brah.Data.Models.Notification;

namespace Brah.BL.Services;

public class NotificationsService(
    IMapper mapper,
    IUserRepository userRepository,
    IRepository<Subscription> subscriptionRepository,
    IRepository<Notification> notificationRepository
) : INotificationsService
{
    public async Task<List<Notification>> GetByUser(ClaimsIdentity identity)
    {
        var user = await userRepository
            .GetSingleOrDefault(
                u => u.UserName.Equals(identity.Name),
                includeSubscriptions: true);

        if (user == null) throw new NotFoundException();

        var subscriptions = user.Subscriptions.Select(s => s.AuthorId).ToList();

        var notifications = notificationRepository
            .GetRange()
            .Where(n => subscriptions.Contains(n.AuthorId))
            .Order().ToList();

        return mapper.Map<List<Notification>>(notifications);
    }

    public async Task AddNotification(Notification notification)
    {
        await notificationRepository.AddAsync(notification);
    }
}