using System.Linq.Expressions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Repositories;

public class ArticleRepository(AppDbContext context) : IRepository<Article>
{
    public async Task<Article?> GetSingleOrDefault(Expression<Func<Article, bool>> expression) 
        => await context.Articles
            .AsNoTracking()
            .Include(e => e.Author)
            .Include(e => e.Topic)
            .Include(e => e.Tags)
            .Include(e => e.Commentaries)
            .SingleOrDefaultAsync(expression);

    public IEnumerable<Article> GetRangeAsync(Expression<Func<Article, bool>>? expression = null)
    {
        var query = context.Articles
            .AsNoTracking()
            .Include(e => e.Author)
            .Include(e => e.Topic)
            .Include(e => e.Tags)
            .AsQueryable();

        if (expression is not null) query = query.Where(expression);
        
        return  query.OrderByDescending(a => a.TimePosted);
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