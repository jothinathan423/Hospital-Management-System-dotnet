using HMS.Data.Database;
using HMS.Data.Repo.IRepo;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data.Repo.RepoImplementation
{
    public class GenericRepoImplementation<T> : IGenericRepo<T> where T : class
    {
        private readonly HmsContext _context;
        private readonly DbSet<T> _dbSet;

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

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is null)
            {
                throw new KeyNotFoundException($"{typeof(T).Name} with id {id} was not found.");
            }       

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
