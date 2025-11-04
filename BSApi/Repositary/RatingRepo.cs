using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositary
{
    public class RatingRepo : Repo<Ratings, int>

    {
        public RatingRepo(AppDbContext context) : base(context)
        {
        }


        public async Task<bool> IsAppointmentCompleteAsync(int appointmentID)
        {
            // تحقق أن الموعد مكتمل
            return await _context.Appointments
                .AnyAsync(x => x.AppointmentID == appointmentID && x.status == enApplicationStatus.Completed);

        }

        public async Task<bool> IsAppointmentExist(int AppointmentID)
        {
            return await _dbSet.AnyAsync(x => x.AppointmentID == AppointmentID);
        }
        public async Task<bool> IsAppointmentValidAsync(int appointmentID)
        {
            return await _context.Appointments
          .AnyAsync(a =>
              a.AppointmentID == appointmentID &&
              a.status == enApplicationStatus.Completed &&
              a.ratings==null   // ⬅️ يعني ما عنده تقييم
          ); ;
        }

        public override async Task<int> AddCustomAsync(Ratings entities)
        {
            await _context.AddAsync(entities);
            return await _context.SaveChangesAsync() > 0 ? entities.RatingID: default;
        }

        public async Task<double?> GetBarberRatingsBarberIDAsync(int BarberID, int? ratingID = null)
        {
            return await _dbSet
                .Where(x => x.BarberID == BarberID && !x.IsDelted)
                .Select(x => (double?)x.Score)  // nullable
                .AverageAsync() ?? 0;           // إذا null نرجع 0
        }
        //public async Task<decimal> GetBarberRatingsRatingIDAsync(int RatingID)
        //{
        //    var res = await _dbSet.SingleOrDefaultAsync(x => x.RatingID == RatingID);

        //    return res == null ? 0 : res.Score;

        //}

        public override async Task<bool> UpdateAsync(Ratings entity)
        {
            IQueryable<Ratings>  query = _dbSet.Where(x => x.RatingID == entity.RatingID);

            int res;

            if (string.IsNullOrEmpty(entity.Comment))
            {
                // بدون تحديث التعليق
                res = await query.ExecuteUpdateAsync(x => x
                    .SetProperty(y => y.Score, entity.Score)
                    .SetProperty(y => y.UpdateAt,y=> DateTime.Now)
                );
            }
            else
            {
                // تحديث التعليق
                res = await query.ExecuteUpdateAsync(x => x
                    .SetProperty(y => y.Score, entity.Score)
                    .SetProperty(y => y.UpdateAt, DateTime.Now)
                    .SetProperty(y => y.Comment, entity.Comment)
                );
            }

            return res > 0;
        }



        public override async Task<bool> DeleteAsync(int id)
        {

            var res = await _dbSet.Where(x => x.RatingID == id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.IsDelted, true));
            return res > 0;
        }
        //public async Task<(bool, decimal)> GetRatingAfterDelete(int ratingID)
        //{
        //    decimal score = await GetBarberRatingsRatingIDAsync(ratingID);
        //    bool res = await DeleteAsync(ratingID);
        //    return (res, score);
        //}




        public override async Task<List<Ratings>> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        //public override async  Task<bool> IsExistAsync(List<string> servicesNames)
        //{
        //    return await _dbSet.AsNoTracking().AnyAsync(c => servicesNames.Any(y => y.Equals(c.ServiceName)));
        //}

        //public async Task<bool> DeleteAllAsync(short speclistID)
        //{
        //   var list =   await _context.ServicesDetials.Where(x => x.SpecilityID == speclistID).Select(x=>x.ServiceID).ToListAsync();
        //    if(list.Count==0) return false;
        //    var res =  await _dbSet.Where(x=>list.Contains(x.ServiceID))
        //        .ExecuteUpdateAsync(x => x.SetProperty(i => i.Enabled, false));

        //    return res>0;
        //}
        //public async Task<bool> ActivateAllAsync(short speclistID)
        //{
        //    var list = await _context.ServicesDetials.Where(x => x.SpecilityID == speclistID).Select(x => x.ServiceID).ToListAsync();
        //    if (list.Count == 0) return false;
        //    var res = await _dbSet.Where(x => list.Contains(x.ServiceID))
        //        .ExecuteUpdateAsync(x => x.SetProperty(i => i.Enabled, true));

        //    return res > 0;
        //}


    }
}
