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
    public class ApplicationsHistoryRepo : Repo<ApplicationsHistory, int>
    {
        public ApplicationsHistoryRepo(AppDbContext context) : base(context)
        {
        }

       
        public override async Task<int> AddCustomAsync(ApplicationsHistory entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.HistoryID: default;
        }


        public override async Task<List<ApplicationsHistory>?> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking()
                .Select(x => new ApplicationsHistory
                {
                    HistoryID = x.HistoryID
                    ,ApplicationID = x.ApplicationID
                 , UserID = x.UserID, CreateAt = x.CreateAt
                 , Notes = x.Notes, Status = x.Status
                    , 
                })
                .ToListAsync();
        }


        public override async Task<ApplicationsHistory?> GetByIdAsync(int HistotyID)
        {
            return await _dbSet.AsNoTracking().Where(x => x.HistoryID== HistotyID)
                .Select(x => new ApplicationsHistory
                {
                    HistoryID = x.HistoryID
                    ,
                    ApplicationID = x.ApplicationID
                 ,
                    UserID = x.UserID,
                    CreateAt = x.CreateAt
                 ,
                    Notes = x.Notes,
                    Status = x.Status
                }).SingleOrDefaultAsync();
            ;
        }




    }
}
