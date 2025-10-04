using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.BaseRepo
{
    public abstract  class Repo<T,TKey>:IRepository<T,TKey> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected Repo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual async Task<TKey> AddCustomAsync(T entity)=> throw new NotImplementedException();
        public virtual async Task AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual  async Task<List<T>> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            
            return await _context.SaveChangesAsync()>0;
        }


        public  async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public  virtual async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> DeleteAsync(TKey id) => throw new NotImplementedException();

        public virtual async   Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
