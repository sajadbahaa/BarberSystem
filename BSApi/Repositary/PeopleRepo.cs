using DataLayer.Entities;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Repositary.BaseRepo;
using System.Numerics;

namespace Repositary
{
    public class PeopleRepo : Repo<People,int>
    {
        public PeopleRepo (AppDbContext context):base(context) 
        {
        }
        public override async Task<List<People>?> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().Where(x=>x.Enabled).ToListAsync();
        }

        public async Task<People?> GetByPhoneAsync(string phone)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x=>x.Phone==phone);
        }

        

        public async Task<People?> GetByNameAsync(string firstName,string secondName,string lastName)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.FirstName == firstName.Trim()&&x.SecondName==secondName.Trim() && x.LastName==lastName.Trim());
        }


        public override async Task<bool> UpdateAsync(People entity)
        {
            if (await _PhoneExist(entity.PersonID,entity.Phone))
            {
                return false;
            }

            var res = await _dbSet.Where(x => x.PersonID == entity.PersonID).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.FirstName, entity.FirstName)
                .SetProperty(i=>i.SecondName,entity.SecondName)
                .SetProperty(i => i.LastName, entity.LastName)
.SetProperty(i => i.Phone, entity.Phone)

                );
            return res > 0;
        }
        public override  async Task<bool> DeleteAsync(int id)
        {
            var res = await _dbSet.Where(x => x.PersonID == id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.Enabled, false));
            return res > 0;
        }


        public override async Task<bool> ActivateAsync(int id)
        {
            var res = await _dbSet.Where(x=>x.PersonID==id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.Enabled, true));
            return res > 0;
        }
        public override async Task<int> AddCustomAsync(People entity)
        {
        await _context.AddAsync(entity);
            return await _context.SaveChangesAsync()>0?entity.PersonID:0;
        }

        public async Task<bool> PhoneExist(string Phone)
        {
             return await _dbSet.AsNoTracking()
                .AnyAsync(x =>

                
                    (!string.IsNullOrEmpty(Phone) && x.Phone == Phone)
                );
        }


        private async Task<bool> _PhoneExist(int ID,string Phone)
        {
            return await _dbSet.AsNoTracking()
     .AnyAsync(x =>
         x.PersonID != ID &&
         (
             (!string.IsNullOrEmpty(Phone) && x.Phone == Phone)
         )
     );



        }


    }
}
