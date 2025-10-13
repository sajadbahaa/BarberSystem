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

        public async Task<bool> UpdateApplicationWithStatusRejectedAsync(BarberApplications entity)
        {
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
.SetProperty(y => y.Status, enApplicationStatus.Draft )

.SetProperty(y => y.UpdateAt, DateOnly.FromDateTime(DateTime.Now))

);

            return result > 0;

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

        public async Task<bool> UpdateApplicationToCanceledAsync(int ApplicationID,string reason)
        {
            return
   await _ChangeStatus(ApplicationID, enApplicationStatus.Canceled, enApplicationStatus.Accepted,reason); 
        }

        public async Task<bool> UpdateApplicationToRejecteddAsync(int ApplicationID, string ? reason)
        {
            return
   await _ChangeStatus(ApplicationID, enApplicationStatus.Rejected, enApplicationStatus.Accepted,reason);
        }



        


    }
}
