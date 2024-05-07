using System.Security.Claims;
using Brah.Data.Models;

namespace Brah.BL.Abstractions;

public interface INotificationsService
{
    public Task<List<Notification>> GetByUser(ClaimsIdentity identity);
    public Task AddNotification(Notification notification);
}