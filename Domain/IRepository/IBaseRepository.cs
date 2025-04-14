using System.Linq.Expressions;
using Domain.Entities.Common;
using Domain.ViewModel.Transaction;

namespace Domain.IRepository;

public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetQueryable();
    Task<List<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, IOrderedQueryable<T> order);
    Task<T?> GetByIdAsync(string id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}