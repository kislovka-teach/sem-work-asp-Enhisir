using System.Linq.Expressions;
using Brah.Data.Abstractions;
using Brah.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Repositories;

public class NotificationRepository(
    AppDbContext context) : IRepository<Notification>
{
    public async Task<Notification?> GetSingleOrDefault(Expression<Func<Notification, bool>> expression)
        => await context.Notifications
            .AsNoTracking()
            .Include(e => e.Author)
            .SingleOrDefaultAsync(expression);

    public IQueryable<Notification> GetRange()
    {
        return context.Notifications
            .AsNoTracking()
            .Include(e => e.Author)
            .AsQueryable();
    }

    public async Task<Notification> AddAsync(Notification entity)
    {
        var newEntity = await context.Notifications.AddAsync(entity);
        await context.SaveChangesAsync();
        return newEntity.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<Notification> entities)
    {
        await context.Notifications.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task<Notification> UpdateAsync(Notification entity)
    {
        var updatedEntity = context.Notifications.Update(entity);
        await context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task RemoveAsync(Notification entity)
    {
        context.Notifications.Remove(entity);
        await context.SaveChangesAsync();
    }
}