using System.Linq.Expressions;
using Data.Context;
using Domain.Entities.Common;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class BaseRepository<T>(AlirezaStepOneDbContext context) : IBaseRepository<T>
    where T : BaseEntity
{
    public IQueryable<T> GetQueryable()
    {
        return context.Set<T>().AsQueryable();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, IOrderedQueryable<T> order)
    {
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task <T?> GetByIdAsync(int id)
    {
       return await context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}