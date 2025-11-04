using DataLayer.Configurations;
using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
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
    public class AppointmentsRepo : Repo<Appointments, int>
    {
        public AppointmentsRepo(AppDbContext context) : base(context)
        {
        }

        

        

        public override async Task<int> AddCustomAsync(Appointments entity)
        {
            if (!await _CheckDateValid(entity.BarberServiceID,entity.StartDate,entity.EndDate))
            {
                return 0;
            }
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.AppointmentID : 0;
        }

        private async Task<bool> _CheckDateValid(int barberServiceID, DateTime startDate, DateTime endDate)
        {
            bool hasConflict = await _dbSet.AnyAsync(x =>
                x.BarberServiceID == barberServiceID
                &&
                // فقط المواعيد النشطة أو المعلقة تؤخذ بالحسبان
                (x.status == enApplicationStatus.Draft
                ||
                x.status == enApplicationStatus.PendingApproval
                )
                &&
                // شرط التداخل الزمني
                (startDate < x.EndDate && endDate > x.StartDate)
            );

            return !hasConflict; // true = الموعد متاح للحجز
        }
        public async Task<bool> HascustomerIDAppointmentAsync(int customerID, DateTime startDate, DateTime endDate)
        {
            bool Has = await _dbSet.AnyAsync(x =>
                x.CustomerID == customerID
                &&
                // فقط المواعيد النشطة أو المعلقة تؤخذ بالحسبان
                (x.status == enApplicationStatus.Draft
                ||
                x.status == enApplicationStatus.PendingApproval
                )
                &&
                // شرط التداخل الزمني
                (startDate < x.EndDate && endDate > x.StartDate)
            );

            return !Has; // true = الموعد متاح للحجز
        }

        private async Task<bool> _IsAppointmentAvailableAsync(
    int appointmentID,
    int barberServiceID,
    int customerID,
    DateTime startDate,
    DateTime endDate)
        {
            bool hasConflict = await _dbSet.AnyAsync(x =>
                x.AppointmentID != appointmentID && // exclude current record
                (x.status == enApplicationStatus.Draft)
                && (startDate < x.EndDate && endDate > x.StartDate)
                && (x.BarberServiceID == barberServiceID || x.CustomerID == customerID)
            );

            return !hasConflict;
        }

        public override async Task<bool> UpdateAsync(Appointments entity)
        {
       if (!await _IsAppointmentAvailableAsync(entity.AppointmentID,entity.BarberServiceID, entity.CustomerID,entity.StartDate, entity.EndDate))
            {
                return false;
            }

            var res = await _dbSet.Where(x => x.AppointmentID == entity.AppointmentID && x.status == enApplicationStatus.Draft)
                     .ExecuteUpdateAsync(i => i
                     .SetProperty(x => x.StartDate, entity.StartDate)
                     .SetProperty(x => x.EndDate, entity.EndDate)
                     .SetProperty(x => x.Note, y => string.IsNullOrEmpty(entity.Note) ? y.Note : entity.Note));


            return res > 0;
        }

        private async Task<bool> _ChangeStatus(int AppointmentID, enApplicationStatus value, enApplicationStatus targetValue, string? reason = null)
        {
            var result = await _dbSet.Where(x => x.AppointmentID == AppointmentID
                   && x.status == targetValue)
                       .ExecuteUpdateAsync
                           (i => i
       .SetProperty(y => y.status, value)
       );

            return result > 0;

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
        public async Task<bool> UpdateAppointmentToPendingApprovalAsync(int AppoointmentID)
        {
            return
            await _ChangeStatus(AppoointmentID, enApplicationStatus.PendingApproval, enApplicationStatus.Draft);
        }

        public async Task<bool> UpdateAppointmentToCompletedAsync(int AppointmentID)
        {
            var result = await _dbSet.Where(x => x.AppointmentID == AppointmentID
                      &&                      
 (x.status == enApplicationStatus.PendingApproval))
                          .ExecuteUpdateAsync
                              (i => i
          .SetProperty(y => y.status, enApplicationStatus.Completed)
          );
            return result > 0;

        }

        public async Task<bool> UpdateAppointmentToCanceledAsync(int AppointmentID)
        {
            var result = await _dbSet.Where(x => x.AppointmentID == AppointmentID
                      &&
 (x.status == enApplicationStatus.PendingApproval))
                          .ExecuteUpdateAsync
                              (i => i
          .SetProperty(y => y.status, enApplicationStatus.Canceled)
          );
            return result > 0;

        }
        public override async Task<Appointments?> GetByIdAsync(int AppointmentID)
        {
            return await _dbSet.AsNoTracking()
                .SingleOrDefaultAsync(x=>x.AppointmentID==AppointmentID);
            ;
        }

        public override async Task<List<Appointments>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }



    }
}
