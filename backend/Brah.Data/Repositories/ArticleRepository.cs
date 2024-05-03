using System.Linq.Expressions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Repositories;

public class ArticleRepository(AppDbContext context) : IRepository<Article>
{
    public async Task<Article?> GetSingleOrDefault(Expression<Func<Article, bool>> expression)
        => await context.Articles
            .Include(e => e.Author) // tracking query because of making commentary tree
            .Include(e => e.Topic)
            .Include(e => e.Tags)
            .Include(e => e.Commentaries
                .Where(c => c.ParentId == null)
                .OrderByDescending(c => c.TimePosted))
                .ThenInclude(c => c.Children.OrderByDescending(x => x.TimePosted))
            .SingleOrDefaultAsync(expression);

    public IQueryable<Article> GetRange()
    {
        return context.Articles
            .AsNoTracking()
            .Include(e => e.Author)
            .Include(e => e.Topic)
            .Include(e => e.Tags)
            .AsQueryable()
            .OrderByDescending(a => a.TimePosted);
    }

    public async Task<Article> AddAsync(Article entity)
    {
        var newEntity = await context.Articles.AddAsync(entity);
        await context.SaveChangesAsync();
        return newEntity.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<Article> entities)
    {
        await context.Articles.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task<Article> UpdateAsync(Article entity)
    {
        var updatedEntity = context.Articles.Update(entity);
        await context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task RemoveAsync(Article entity)
    {
        context.Articles.Remove(entity);
        await context.SaveChangesAsync();
    }
}