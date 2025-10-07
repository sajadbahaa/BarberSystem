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
        public override async Task<List<People>> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().Where(x=>x.Enabled).ToListAsync();
        }

        public async Task<People?> GetByPhoneAsync(string phone)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x=>x.Phone==phone);
        }

        public async Task<People?> GetByEmaliAsync(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<People?> GetByNameAsync(string firstName,string secondName,string lastName)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.FirstName == firstName.Trim()&&x.SecondName==secondName.Trim() && x.LastName==lastName.Trim());
        }


        public override async Task<bool> UpdateAsync(People entity)
        {
            if (await _PhoneOrEmailExist(entity.PersonID,entity.Phone,entity.Email))
            {
                return false;
            }

            var res = await _dbSet.Where(x => x.PersonID == entity.PersonID).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.FirstName, entity.FirstName)
                .SetProperty(i=>i.SecondName,entity.SecondName)
                .SetProperty(i => i.LastName, entity.LastName)
.SetProperty(i => i.Phone, entity.Phone)
.SetProperty(i => i.Email,entity.Email)

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

        public async Task<bool> PhoneOrEmailExist(string Phone,string Email)
        {
             return await _dbSet.AsNoTracking()
                .AnyAsync(x =>

                (!string.IsNullOrEmpty(Email) && x.Email== Email) ||
                    (!string.IsNullOrEmpty(Phone) && x.Phone == Phone)
                );
        }


        private async Task<bool> _PhoneOrEmailExist(int ID,string Phone, string Email)
        {
            return await _dbSet.AsNoTracking()
     .AnyAsync(x =>
         x.PersonID != ID &&
         (
             (!string.IsNullOrEmpty(Email) && x.Email == Email) ||
             (!string.IsNullOrEmpty(Phone) && x.Phone == Phone)
         )
     );



        }


    }
}
