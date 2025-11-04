using DataLayer.Entities;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary
{
    public class CustomerRepo : Repo<Customers, int>
    {
        public CustomerRepo(AppDbContext context) : base(context)
        {
        }
        public override async Task<int> AddCustomAsync(Customers entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.CustomerID: 0;
        }
        public override async Task<Customers?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.AsNoTracking().Include(x=>x.person)
                .SingleOrDefaultAsync(x => x.CustomerID == id);
            return entity;
        }

        public override async Task<List<Customers>?> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().Include(x=>x.person).ToListAsync();
        }

        public async Task<Customers?> GetByUserIdAsync(int userID)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.person).SingleOrDefaultAsync(x => x.UserID == userID);
            return entity;
        }

        public async Task<int> GetPersonIdByUserIDAsync(int userID)
        {
            var entity = await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.UserID == userID);
            return  entity.PersonID;
        }
        public async Task<bool> IsCustomerSameUserIDAsync(int userID,int customerID)
        {
            var res = 
            await _dbSet.AnyAsync(x=>x.CustomerID==customerID&&x.UserID==userID);
            return res;
        }

    }
}
