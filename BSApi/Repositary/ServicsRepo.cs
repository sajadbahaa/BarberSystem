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
    public class ServicsRepo : Repo<Servics, short>

    {
        public ServicsRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<short>?> AddRangeAsync(List<Servics> entities)
        {
            await _context.AddRangeAsync(entities);

            return await _context.SaveChangesAsync() > 0 ? entities.Select(x => x.ServiceID).ToList() : default;
        }


        public override async Task<bool> UpdateAsync(Servics entity)
        {
            var res = await _dbSet.Where(x => x.ServiceID== entity.ServiceID)

                .ExecuteUpdateAsync(x => x
                .SetProperty(y => y.price, entity.price)
                .SetProperty(y => y.ServiceName, entity.ServiceName)

                .SetProperty(y => y.duration, entity.duration)
                );
            return res > 0;
        }


        public override async Task<bool> ActivateAsync(short serviceID)
        {
            var res = await _dbSet.Where(x => x.ServiceID== serviceID)

                .ExecuteUpdateAsync(x => x.SetProperty(y => y.Enabled, true)
                );
            return res > 0;
        }

        public override async Task<bool> DeleteAsync(short id)
        {
            var res = await _dbSet.Where(x => x.ServiceID == id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.Enabled, false));
            return res > 0;
        }




        public override async Task<List<Servics>> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().Include(x=>x.servicesDetials).ToListAsync();
        }

        public override async  Task<bool> IsExistAsync(List<string> servicesNames)
        {
            return await _dbSet.AsNoTracking().AnyAsync(c => servicesNames.Any(y => y.Equals(c.ServiceName)));
        }

        public async Task<bool> DeleteAllAsync(short speclistID)
        {
           var list =   await _context.ServicesDetials.Where(x => x.SpecilityID == speclistID).Select(x=>x.ServiceID).ToListAsync();
            if(list.Count==0) return false;
            var res =  await _dbSet.Where(x=>list.Contains(x.ServiceID))
                .ExecuteUpdateAsync(x => x.SetProperty(i => i.Enabled, false));

            return res>0;
        }
        public async Task<bool> ActivateAllAsync(short speclistID)
        {
            var list = await _context.ServicesDetials.Where(x => x.SpecilityID == speclistID).Select(x => x.ServiceID).ToListAsync();
            if (list.Count == 0) return false;
            var res = await _dbSet.Where(x => list.Contains(x.ServiceID))
                .ExecuteUpdateAsync(x => x.SetProperty(i => i.Enabled, true));

            return res > 0;
        }


    }
}
