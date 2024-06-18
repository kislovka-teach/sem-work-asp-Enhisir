using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Brah.Data.Extensions;

public static class QueryableExtension
{
    public static IQueryable<TEntity> IncludeIf<TEntity, TProperty>(
        this IQueryable<TEntity> source,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath, bool condition)
        where TEntity : class
    {
        return condition ? source.Include(navigationPropertyPath) : source;
    }
}