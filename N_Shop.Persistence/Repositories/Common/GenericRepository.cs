using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Common;

namespace N_Shop.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly N_ShopDbContext _context;
        public GenericRepository(N_ShopDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }
        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
