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
        
        
    }
}
