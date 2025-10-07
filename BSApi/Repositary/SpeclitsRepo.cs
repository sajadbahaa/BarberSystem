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
    public class SpeclitsRepo : Repo< Speclitys,short>
    {
        public SpeclitsRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<short> AddCustomAsync(Speclitys entity)
        {
                           await _context.AddAsync(entity);
          return   await _context.SaveChangesAsync()>0?entity.SpecilityID: (short)0;
        }

        public override async Task<bool> UpdateAsync(Speclitys entity)
        {
            var res = await _dbSet.Where(x => x.SpecilityID == entity.SpecilityID)

                .ExecuteUpdateAsync(x => x.SetProperty(y => y.SpecilityName, entity.SpecilityName)
                );
            return res > 0;
        }


        public override async Task<bool> ActivateAsync(short SpeclityID)
        {
            var res = await _dbSet.Where(x => x.SpecilityID == SpeclityID)

                .ExecuteUpdateAsync(x => x.SetProperty(y => y.Enabled, true)
                );
            return res > 0;
        }

        public override async Task<bool> DeleteAsync(short id)
        {
            var res = await _dbSet.Where(x => x.SpecilityID == id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.Enabled, false));
            return res > 0;
        }

        public override async Task<List<Speclitys>> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().Where(x => x.Enabled).ToListAsync();
        }
        public  override async Task<bool> IsExistAsync(string specilistName)
        {
            return await _dbSet.AnyAsync(x => x.SpecilityName.Equals(specilistName));
        }


    }
}
