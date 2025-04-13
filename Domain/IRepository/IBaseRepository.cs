using System.Linq.Expressions;
using Domain.Entities.Common;

namespace Domain.IRepository;

public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetQueryable();
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, IOrderedQueryable<T> order);
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}