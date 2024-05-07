using System.Linq.Expressions;
using Brah.Data.Abstractions;
using Brah.Data.Extensions;
using Brah.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetSingleOrDefault(
        Expression<Func<User, bool>> expression,
        bool includeArticles = false,
        bool includeResume = false,
        bool includeSubscriptions = false)
    {
        var query = context.Users.AsNoTracking();

        if (includeArticles)
            query = context.Users
                .AsNoTracking()
                .Include(u => u.Articles.OrderByDescending(a => a.Id).ThenBy(a => a.TimePosted))
                .ThenInclude(a => a.Topic)
                .Include(u => u.Articles.OrderByDescending(a => a.Id).ThenBy(a => a.TimePosted))
                .ThenInclude(a => a.Tags);

        if (includeResume)
            query = query
                .Include(u => u.Resume)
                .ThenInclude(r => r.Tags)
                .Include(u => u.Resume)
                .ThenInclude(r => r.WorkPlaces)
                .Include(u => u.Resume);

        if (includeSubscriptions) query = query.Include(u => u.Subscriptions);

        return await query.SingleOrDefaultAsync(expression);
    }


    public IEnumerable<User> GetRangeAsync(
        Expression<Func<User, bool>>? expression = null,
        bool includeArticles = false,
        bool includeResume = false)
    {
        var query = context.Users.AsNoTracking()
            .IncludeIf(u => u.Articles, includeArticles)
            .IncludeIf(u => u.Resume, includeResume);

        return expression is null ? query : query.Where(expression);
    }

    public async Task<User> AddAsync(User entity)
    {
        var newEntity = await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();
        return newEntity.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<User> entities)
    {
        await context.Users.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var updatedEntity = context.Users.Update(entity);
        await context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task RemoveAsync(User entity)
    {
        context.Users.Remove(entity);
        await context.SaveChangesAsync();
    }
}