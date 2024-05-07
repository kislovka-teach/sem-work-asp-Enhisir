using System.Linq.Expressions;
using Brah.Data.Models;

namespace Brah.Data.Abstractions;

public interface IUserRepository
{
    public Task<User?> GetSingleOrDefault(
        Expression<Func<User, bool>> expression,
        bool includeArticles = false,
        bool includeResume = false,
        bool includeSubscriptions = false);

    public IEnumerable<User> GetRangeAsync(
        Expression<Func<User, bool>> expression,
        bool includeArticles = false,
        bool includeResume = false);

    public Task<User> AddAsync(User entity);
    public Task AddRangeAsync(IEnumerable<User> entities);
    public Task<User> UpdateAsync(User entity);

    public Task RemoveAsync(User entity);
}