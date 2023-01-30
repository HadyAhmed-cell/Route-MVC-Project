using Microsoft.EntityFrameworkCore;
using Route.NetBLL.Interfaces;
using Route.NetDAL.Context;

namespace Route.NetBLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RouteNetContext _context;

        public GenericRepository(RouteNetContext context)
        {
            _context = context;
        }

        public async Task<int> Create(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            return await (_context.SaveChangesAsync());
        }

        public async Task<T> Get(int? id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll()
        => await _context.Set<T>().ToListAsync();

        public async Task<int> Update(T obj)
        {
            _context.Set<T>().Update(obj);
            return await (_context.SaveChangesAsync());
        }


    }
}
