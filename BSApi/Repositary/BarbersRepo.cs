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
    public class BarbersRepo : Repo<Barbers, int>
    {
        public BarbersRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<Barbers?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.AsNoTracking().Include(x=>x.people).SingleOrDefaultAsync(x => x.BarberID == id);
            return entity;
        }


        public  async Task<Barbers?> GetByUserIdAsync(int userID)
        {
            var entity = await _dbSet.AsNoTracking().Include(x => x.people).SingleOrDefaultAsync(x => x.UserID == userID);
            return entity;
        }


        public override async Task<List<Barbers>?> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().Include(x => x.people).ToListAsync();
        }


        public async Task<BarberServices?> GetBarberServiceByID(int BarberServiceID)
        {
            return await _context.barberServices.AsNoTracking().
                FirstOrDefaultAsync(x => x.BarberServiceID == BarberServiceID);
        }

// edit update barber Info.
        public override async Task<bool> UpdateAsync(Barbers entity)
        {

            var res = await _dbSet.Where(x => x.BarberID== entity.BarberID)
                .ExecuteUpdateAsync
                (x => x.SetProperty(i => i.ShopName, i=>i.ShopName==entity.ShopName?i.ShopName:entity.ShopName)
                .SetProperty(i => i.Location, i => i.Location== entity.Location ? i.Location : entity.Location)
                .SetProperty(i => i.people.FirstName, entity.people.FirstName)
                .SetProperty(i => i.people.SecondName, entity.people.SecondName)
                .SetProperty(i => i.people.LastName, entity.people.LastName)
.SetProperty(i => i.people.Phone, entity.people.Phone)
                );
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
