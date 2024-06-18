using System.Linq.Expressions;

namespace Brah.Data.Abstractions;

public interface IRepository<TEntity>
{
    public Task<TEntity?> GetSingleOrDefault(Expression<Func<TEntity, bool>> expression);
    public IQueryable<TEntity> GetRange();

    public Task<TEntity> AddAsync(TEntity entity);
    public Task AddRangeAsync(IEnumerable<TEntity> entities);
    public Task<TEntity> UpdateAsync(TEntity entity);

    public Task RemoveAsync(TEntity entity);
}