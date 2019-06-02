using System;
using System.Linq;
using System.Threading.Tasks;
using Intended.DAL;
using Intended.Domain;
using Microsoft.EntityFrameworkCore;

namespace Intended.Dal.EntityFrameworkCore
{
    internal class EfCoreDbContextAccessor: IDbContextAccessor
    {
        private readonly DbContext _context;

        public EfCoreDbContextAccessor(DbContext context)
        {
            _context = context;
        }

        public IDbSetAccessor<T> Set<T>() 
            where T : class, IEntity
        {
            return new EfCoreDbSetAccessor<T>(_context.Set<T>());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public class EfCoreDbSetAccessor<T> : IDbSetAccessor<T> 
            where T : class, IEntity
        {
            private readonly DbSet<T> _dbSet;

            public EfCoreDbSetAccessor(DbSet<T> dbSet)
            {
                _dbSet = dbSet;
            }
            
            public void Add(T entity)
            {
                _dbSet.Add(entity);
            }

            public void Update(T entity)
            {
                // do nothing, assume entity attached
            }

            public void Remove(T entity)
            {
                _dbSet.Remove(entity);
            }

            public IQueryable<T> Tracked()
            {
                return _dbSet.AsTracking();
            }

            public IQueryable<T> NotTracked()
            {
                return _dbSet.AsNoTracking();
            }
        }
    }
}