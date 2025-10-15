using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositary
{
    public class BarberAplicationRepo : Repo<BarberApplications, int>
    {
        public BarberAplicationRepo(AppDbContext context) : base(context)
        {
        }

       
        public override async Task<int> AddCustomAsync(BarberApplications entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.ApplicationID : 0;
        }
        public  async Task<bool> UpdateApplicationWithStatusDraftAsync(BarberApplications entity)
        {
            var result = await _dbSet.Where(x => x.ApplicationID == entity.ApplicationID 
            && x.Status == enApplicationStatus.Draft)
                .ExecuteUpdateAsync
                    (i => i
                    .SetProperty(y => y.CopyFirstName, entity.CopyFirstName)
                    .SetProperty(y => y.CopySecondName, entity.CopySecondName)
.SetProperty(y => y.CopyLastName, entity.CopyLastName)
.SetProperty(y => y.CopyPhone, entity.CopyPhone)
.SetProperty(y => y.Shop, entity.Shop)
.SetProperty(y => y.Location, entity.Location)
.SetProperty(y => y.UpdateAt, DateOnly.FromDateTime(DateTime.Now))

);

            return result > 0;
                
                }

        public async Task<(bool,int)> UpdateApplicationWithStatusRejectedAsync(BarberApplications entity)
        {
            bool status = false;
            int? userID = await _dbSet
      .Where(x => x.ApplicationID == entity.ApplicationID)
      .Select(x => x.UserID)
      .FirstOrDefaultAsync();

            var result = await _dbSet.Where(x => x.ApplicationID == entity.ApplicationID
            && x.Status == enApplicationStatus.Rejected)
                .ExecuteUpdateAsync
                    (i => i
                    .SetProperty(y => y.CopyFirstName, entity.CopyFirstName)
                    .SetProperty(y => y.CopySecondName, entity.CopySecondName)
.SetProperty(y => y.CopyLastName, entity.CopyLastName)
.SetProperty(y => y.CopyPhone, entity.CopyPhone)
.SetProperty(y => y.Shop, entity.Shop)
.SetProperty(y => y.Location, entity.Location)
.SetProperty(y => y.Status, enApplicationStatus.Draft)

.SetProperty(y => y.UpdateAt, DateOnly.FromDateTime(DateTime.Now))

);

            status = result > 0?true:false;

            return (status, userID.Value);
        }


        private async Task<bool> _ChangeStatus(int ApplicationID,enApplicationStatus value, enApplicationStatus targetValue,string ? reason = null)
        {
            var result = await _dbSet.Where(x => x.ApplicationID == ApplicationID
                   && x.Status == targetValue)
                       .ExecuteUpdateAsync
                           (i => i
       .SetProperty(y => y.Status, value)
       .SetProperty(y => y.Reason, reason==null?null:reason)

       );

            return result > 0;

        }
        public async Task<bool> UpdateApplicationToPendingApprovalAsync(int ApplicationID)
        {
            return
            await _ChangeStatus(ApplicationID, enApplicationStatus.PendingApproval, enApplicationStatus.Draft); 
        }

        public async Task<bool> UpdateApplicationToCanceledAsync(int ApplicationID,string ?reason)
        {
            var result = await _dbSet.Where(x => x.ApplicationID == ApplicationID
                      &&
                      (x.Status == enApplicationStatus.Rejected
                      )
                      || (x.Status == enApplicationStatus.Draft))
                          .ExecuteUpdateAsync
                              (i => i
          .SetProperty(y => y.Status, enApplicationStatus.Canceled)
          .SetProperty(y => y.Reason, reason == null ? null : reason)

          );
            return result>0;

        }

        public async Task<bool> UpdateApplicationToRejecteddAsync(int ApplicationID, string ? reason)
        {
            return
   await _ChangeStatus(ApplicationID, enApplicationStatus.Rejected, enApplicationStatus.PendingApproval,reason);
        }

        public override async Task<List<BarberApplications>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .Select(x => new BarberApplications
                {
                    ApplicationID = x.ApplicationID
                 ,
                    UserID = x.UserID,
                    Shop = x.Shop,
                    Location = x.Location,
                    CopyFirstName = x.CopyFirstName,
                    CopySecondName = x.CopySecondName,
                    CopyLastName = x.CopyLastName,
                    CopyPhone = x.CopyPhone
                ,
                    Status = x.Status,
                    CreatAt = x.CreatAt,
                    Reason = x.Reason

                })
                .ToListAsync();
        }

        public  async Task<List<BarberApplications>> GetAllApplicationDraftAsync()
        {
            return await _dbSet.AsNoTracking().Where(x=>x.Status==enApplicationStatus.Draft)
                .Select(x => new BarberApplications
                {
                    ApplicationID = x.ApplicationID
                 ,
                    UserID = x.UserID,
                    Shop = x.Shop,
                    Location = x.Location,
                    CopyFirstName = x.CopyFirstName,
                    CopySecondName = x.CopySecondName,
                    CopyLastName = x.CopyLastName,
                    CopyPhone = x.CopyPhone
                ,
                    Status = x.Status,
                    CreatAt = x.CreatAt,
                    Reason = x.Reason

                })
                .ToListAsync();
        }

        public async Task<List<BarberApplications>> GetAllApplicationPendingApprovalAsync()
        {
            return await _dbSet.AsNoTracking().Where(x => x.Status == enApplicationStatus.PendingApproval)
                .Select(x => new BarberApplications
                {
                    ApplicationID = x.ApplicationID
                 ,
                    UserID = x.UserID,
                    Shop = x.Shop,
                    Location = x.Location,
                    CopyFirstName = x.CopyFirstName,
                    CopySecondName = x.CopySecondName,
                    CopyLastName = x.CopyLastName,
                    CopyPhone = x.CopyPhone
                ,
                    Status = x.Status,
                    CreatAt = x.CreatAt,
                    Reason = x.Reason

                })
                .ToListAsync();
        }

        public async Task<List<BarberApplications>> GetAllApplicationAcceptAsync()
        {
            return await _dbSet.AsNoTracking().Where(x => x.Status == enApplicationStatus.Accepted)
                .Select(x => new BarberApplications
                {
                    ApplicationID = x.ApplicationID
                 ,
                    UserID = x.UserID,
                    Shop = x.Shop,
                    Location = x.Location,
                    CopyFirstName = x.CopyFirstName,
                    CopySecondName = x.CopySecondName,
                    CopyLastName = x.CopyLastName,
                    CopyPhone = x.CopyPhone
                ,
                    Status = x.Status,
                    CreatAt = x.CreatAt,
                    Reason = x.Reason

                })

                .ToListAsync();
        
        }
        

        public async Task<List<BarberApplications>> GetAllApplicationCanceldAsync()
        {
            return await _dbSet.AsNoTracking().Where(x => x.Status == enApplicationStatus.Canceled)
                .Select(x=>new BarberApplications 
                {ApplicationID = x.ApplicationID
                 ,UserID = x.UserID,Shop = x.Shop,
                 Location = x.Location,
                 CopyFirstName = x.CopyFirstName,
                 CopySecondName = x.CopySecondName,
                 CopyLastName = x.CopyLastName,
                 CopyPhone = x.CopyPhone
                ,Status = x.Status,
                CreatAt = x.CreatAt,
                Reason = x.Reason,
                })
                .ToListAsync();
        }


        public override async Task<BarberApplications?> GetByIdAsync(int  ApplicatinoID)
        {
            return await _dbSet.AsNoTracking().Where(x => x.ApplicationID == ApplicatinoID)
                .Select(x => new BarberApplications
                {
                    ApplicationID = x.ApplicationID
                 ,
                    UserID = x.UserID,
                    Shop = x.Shop,
                    Location = x.Location,
                    CopyFirstName = x.CopyFirstName,
                    CopySecondName = x.CopySecondName,
                    CopyLastName = x.CopyLastName,
                    CopyPhone = x.CopyPhone
                ,
                    Status = x.Status,
                    CreatAt = x.CreatAt,
                    Reason = x.Reason,
                }).SingleOrDefaultAsync();
                ;
        }


        public async Task<bool> HasUserApplicationActive(int UserID)
        {
            return await _dbSet.AsNoTracking()
                .AnyAsync(x => x.UserID == UserID && x.Status != enApplicationStatus.Canceled);
        }

    }
}
