using DataLayer.Entities;
using DTLayer.Data;
using Dtos.SpeclisysDtos;
using Microsoft.EntityFrameworkCore;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary
{
    public class ServiceDetilasRepo : Repo<ServicesDetials, short>
    {
        public ServiceDetilasRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<bool> AddRangeCustomAsync(List<ServicesDetials> entities)
        {
            await _context.AddRangeAsync(entities);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<findServicesBySpeclityDtos>?> GetServicesBySpeciltyName(string SpeciltyName)
        {
            var result = await _dbSet.AsNoTracking()
    .Where(sd => sd.Speclitys.SpecilityName == SpeciltyName)
    .Select(sd=> new findServicesBySpeclityDtos
    {
        ServiceDetilasID = sd.ServiceDetilasID,
        ServiceName = sd.servics.ServiceName
    })
    .ToListAsync();

            return result;
        }

        ///<summary>
        ///using navigation property is more readable and cleaner than using manual join.
        ///less translate than join
        ///in maintenance is fast.
        ///</summary>
        //var res = await _dbSet.Join(
        //    _context.Speclitys
        //    , sd => sd.SpecilityID
        //    , sp => sp.SpecilityID,
        //    (sd, sp) => new { sd.ServiceDetilasID, sd.ServiceID, sp.SpecilityID, sp.SpecilityName }
        //    ).Join(_context.servics
        //    , sdp => sdp.ServiceID
        //    , s => s.ServiceID,
        //    (sd, s) => new { sd.ServiceDetilasID, sd.SpecilityName, s.ServiceName }
        //    ).Where(x => x.SpecilityName == SpeciltyName)
        //    .Select(x => new findServicesBySpeclityDtos { ServiceDetilasID = x.ServiceDetilasID, ServiceName = x.ServiceName }
        //    ).ToListAsync();

        //return res;


    }
}
