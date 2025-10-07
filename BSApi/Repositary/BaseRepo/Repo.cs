using BsLayer.misc;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.BaseRepo
{
    public abstract class Repo<T, TKey> : IRepository<T, TKey>, ITransactionService where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        private IDbContextTransaction? _transaction;
        protected Repo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual Task<TKey> AddCustomAsync(T entity) => throw new NotImplementedException();
        public virtual  Task<List<TKey>?> AddRangeAsync(List<T> entities) => throw new NotImplementedException();
        public virtual Task<bool> AddRangeSingleAsync(List<T> entities) => throw new NotImplementedException();

        public virtual async Task<List<T>> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual  Task<bool> DeleteAsync(TKey id) => throw new NotImplementedException();

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual  Task<bool> ActivateAsync(TKey id)=> throw new NotImplementedException();

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _context.SaveChangesAsync();   // يحفظ كل التغييرات
                await _transaction.CommitAsync();
                await DisposeAsync(); // ينهي الـ transaction
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await DisposeAsync(); // ينهي الـ transaction
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }

        }

        public virtual Task<bool> IsExistAsync(string tkey)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> IsExistAsync(List<string> tkey)
        {
            throw new NotImplementedException();
        }
    }
}
