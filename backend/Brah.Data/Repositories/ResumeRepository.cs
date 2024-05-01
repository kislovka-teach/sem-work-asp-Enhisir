using System.Linq.Expressions;
using Brah.Data.Abstractions;
using Brah.Data.Models.Resumes;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Repositories;

public class ResumeRepository(AppDbContext context) : IRepository<Resume>
{
    public async Task<Resume?> GetSingleOrDefault(Expression<Func<Resume, bool>> expression) 
        => await context.Resumes
            .AsNoTracking()
            .Include(r => r.Tags)
            .Include(r => r.WorkPlaces)
            .SingleOrDefaultAsync(expression);

    public IEnumerable<Resume> GetRangeAsync(Expression<Func<Resume, bool>>? expression = null)
    {
        var query = context.Resumes
            .AsNoTracking()
            .Include(r => r.Tags)
            .AsQueryable();

        if (expression is not null) query = query.Where(expression);
        
        return query;
    }
    
    public async Task<Resume> AddAsync(Resume entity)
    {
        var newEntity = await context.Resumes.AddAsync(entity);
        await context.SaveChangesAsync();
        return newEntity.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<Resume> entities)
    {
        await context.Resumes.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    public async Task<Resume> UpdateAsync(Resume entity)
    {
        var updatedEntity = context.Resumes.Update(entity);
        await context.SaveChangesAsync();
        return updatedEntity.Entity;
    }

    public async Task RemoveAsync(Resume entity)
    {
        context.Resumes.Remove(entity);
        await context.SaveChangesAsync();
    }
}