using AppProject.Application.Repository;
using AppProject.Domain.Common.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Persistence.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;
        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async void AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async void Delete(long id)
        {
            var obj = await GetByIdAsync(id);
            _dbSet.Remove(obj);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<List<TEntity>> GetListAsyncWithIncludeParams(Expression<Func<TEntity, bool>> filter, IList<string> includes = null)
        {
            var list = filter != null ? _dbSet.AsNoTracking().Where(filter).AsQueryable() : _dbSet.AsNoTracking().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    list = list.Include(include);
                }
            }
            return await list.AsQueryable().ToListAsync();
        }
    }
}
