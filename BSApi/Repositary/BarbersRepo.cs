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
        public async Task<bool> UpdateBarberInfoAsync(Barbers entity,int UserID)
        {

            var res = await _dbSet.Where(x => x.UserID==UserID)
                .ExecuteUpdateAsync
                (x => x.SetProperty(i => i.ShopName, i=>i.ShopName==entity.ShopName || entity.ShopName.Length==0?i.ShopName:entity.ShopName)
                .SetProperty(i => i.Location, i => i.Location== entity.Location ||entity .Location.Length == 0 ? i.Location : entity.Location)                );
            return res > 0;
        }

        public async Task<List<string>> GetMyServices(int userId)
        {
            var result = await _dbSet
                .Where(b => b.UserID == userId)
                .Join(_context.barberServices, b => b.BarberID, bs => bs.BarberID, (b, bs) => new { b, bs })
                .Join(_context.ServicesDetials, temp => temp.bs.ServiceDetilasID, sd => sd.ServiceDetilasID, (temp, sd) => new { temp.b, sd })
                .Join(_context.servics, temp => temp.sd.ServiceID, s => s.ServiceID, (temp, s) => s.ServiceName)
                .ToListAsync();
            return result;
        }
        public async Task<bool> updateRatingAsync(int barberID,decimal rate,bool delete = false)
        {
            var res = await _dbSet.Where(x => x.BarberID == barberID)
    .ExecuteUpdateAsync
    (x => x.SetProperty(i => i.Rating,
  i => !delete ? rate : i.Rating - rate
    ));
            return res > 0;
}


        public async Task<bool> IsAppointmentOwnedByBarberAsync(int userId, int appointmentId)
        {
            // AsNoTracking: لأننا نتحقق فقط، ما نحتاج تتبع الكيانات
            return await _context.barbers
                .AsNoTracking()
                .Where(b => b.UserID == userId) // فلترة على المستخدم الحالي
                .AnyAsync(b => b.BarberServices
                                .Any(bs => bs.appointments
                                             .Any(a => a.AppointmentID == appointmentId)));
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
