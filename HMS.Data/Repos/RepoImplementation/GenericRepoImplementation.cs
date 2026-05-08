using HMS.Data.Database;
using HMS.Data.Repos.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HMS.Data.Repos.RepoImplementation
{
    public class GenericRepoImplementation<T> : IGenericRepo<T> where T : class
    {
        protected readonly HmsContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepoImplementation(HmsContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToListAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
