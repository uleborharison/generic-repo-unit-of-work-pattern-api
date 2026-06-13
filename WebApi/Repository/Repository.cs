using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _myDbContext;
        protected readonly DbSet<T> _dbSet;
        public Repository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _dbSet = myDbContext.Set<T>();

        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _myDbContext.Entry(entity).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
