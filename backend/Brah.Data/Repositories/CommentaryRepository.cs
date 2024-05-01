using System.Linq.Expressions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Articles;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Repositories;

public class CommentaryRepository(AppDbContext context) : IRepository<Commentary>
{
    public async Task<Commentary?> GetSingleOrDefault(Expression<Func<Commentary, bool>> expression) 
        => await context.Commentaries
            .AsNoTracking()
            .Include(e => e.Author)
            .Include(e => e.Children.OrderBy(c => c.TimePosted))
            .SingleOrDefaultAsync(expression);

    public IQueryable<Commentary> GetRange()
    {
        return context.Commentaries
            .AsNoTracking()
            .Include(e => e.Author)
            .Include(e => e.Children.OrderBy(c => c.TimePosted))
            .AsQueryable()
            .OrderByDescending(c => c.TimePosted);
    }
    
    public async Task<Commentary> AddAsync(Commentary entity)
    {
        var newEntity = await context.Commentaries.AddAsync(entity);
        await context.SaveChangesAsync();
        return newEntity.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<Commentary> entities)
    {
        await context.Commentaries.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task<Commentary> UpdateAsync(Commentary entity)
    {
        var updatedEntity = context.Commentaries.Update(entity);
        await context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task RemoveAsync(Commentary entity)
    {
        context.Commentaries.Remove(entity);
        await context.SaveChangesAsync();
    }
}