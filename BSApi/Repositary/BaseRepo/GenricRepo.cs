using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary.BaseRepo
{
    public interface IRepository<T,Tkey> where T : class
    {
        Task<List<T>> GetAllFilterAsync();
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Tkey id);
        Task<T?> GetByUsernameAsync(string id);

        Task<Tkey>AddCustomAsync(T entity);
        Task AddAsync(T entity);

        Task<List<Tkey>?> AddRangeAsync(List<T> entities);
        Task<bool> AddRangeCustomAsync(List<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Tkey id);
        Task<bool> SaveAsync();
        Task<bool> IsExistAsync(string tkey);
        Task<bool> IsExistAsync(List<string> tkey);
        Task<bool> ActivateAsync(Tkey id);
   
    }

}
