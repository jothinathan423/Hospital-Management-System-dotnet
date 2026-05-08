using System.Linq.Expressions;

namespace HMS.Data.Repos.IRepo
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
