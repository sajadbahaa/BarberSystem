using DataLayer.Entities;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using Dtos.BarbersDtos;

namespace Repositary
{
    public class BarbersServiceRepo : Repo<BarberServices, int>
    {
        public BarbersServiceRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<int> AddCustomAsync(BarberServices entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.BarberServiceID : 0;
        }
        public override async Task<BarberServices?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.BarberServiceID == id);
            return entity;
        }

        public override async Task<List<BarberServices>?> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public override async Task<bool> UpdateAsync(BarberServices  entity)
        {
            var res = await _dbSet.Where(x => x.BarberServiceID == entity.BarberServiceID)
                    .ExecuteUpdateAsync(x => x
                    .SetProperty(i=>i.Duration,
                    i=>i.Duration==entity.Duration?
                    i.Duration:entity.Duration)
                    .SetProperty(i => i.Price, i => i.Price 
                    == entity.Price ?
                    i.Price:entity.Price)
                    );
            return res > 0;
        }
        
        public override async Task<bool> DeleteAsync(int BarberServiceId)
        {
            var res = await _dbSet.Where(x => x.BarberServiceID== BarberServiceId).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.Enabled, false));
            return res > 0;
        }


        public override async Task<bool> ActivateAsync(int BarberServiceID)
        {
            var res = await _dbSet.Where(x => x.BarberServiceID== BarberServiceID).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.Enabled, true));
            return res > 0;
        }

        // un secure support Sql Injuction .
        //public async Task<int> AddBarberDetailsAsync(int applicationId)
        //{
        //    var sql = $"EXEC SP_AddBarberDetails @ApplicationID = {applicationId}";

        //    var result = await _context.Database
        //        .ExecuteSqlInterpolatedAsync()   // EF Core 7+ feature
        //        .SingleOrDefaultAsync();

        //    return result; // 1 نجاح - 0 فشل
        //}

        // EF Core يحول الـ FormattableString لباراميترات تلقائياً
        //public async Task<int> AddBarberDetailsAsync(int applicationId)
        //{
        //    // EF Core 8+: interpolated query, automatically parameterized
        //    var result = await _context.Database
        //        .SqlQueryInterpolated<int>($"EXEC SP_AddBarberDetails @ApplicationID = {applicationId}")
        //        .SingleOrDefaultAsync();

        //    return result;
        //}





    }
    }
