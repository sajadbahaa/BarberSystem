using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositary
{
    public class TempBarberServicesRepo : Repo<TempBarberServices, int>
    {
        public TempBarberServicesRepo(AppDbContext context) : base(context)
        {

        }


        //public override async Task<bool> UpdateRangeAsync(List<TempBarberServices> entities)
        //{

        //    /// update on method by using GroupBy (ApplicationID) then update Spesfic records.
        //    if (entities == null || !entities.Any())
        //        return false;

        //    var res = await _dbSet
        //        .Where(x => entities.Any(y => y.TempServiceID == x.TempServiceID))
        //        .ExecuteUpdateAsync(x => x
        //            .SetProperty(
        //                p => p.Price,
        //                p => entities.First(y => y.TempServiceID == p.TempServiceID).Price
        //            )
        //            .SetProperty(
        //                p => p.Duration,
        //                p => entities.First(y => y.TempServiceID == p.TempServiceID).Duration
        //            )
        //        );

        //    return res > 0;
        //}
/// <summary>
///  Group Vs Where 
///  Group : if you have multi Applications different TempIDs you can use it ,
///  Where : if you have single application .
/// </summary>
/// <param name="entities"></param>
/// <returns></returns>
        
        public async Task<bool> UpdateTempBarberServicesAsync(List<TempBarberServices> entities)
        {
            _context.TempBarberServices.UpdateRange(entities);
            foreach (var entity in entities)
            {
                _context.Entry(entity).Property(x => x.ApplicationID).IsModified = false;
                _context.Entry(entity).Property(x => x.ServiceDetilasID).IsModified = false;

            }
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }




        public override async Task<bool> DeleteRangeAsync(List<int> TempIDs)
        {
            int total = await _dbSet.Where(x => TempIDs.Contains(x.TempServiceID)).ExecuteDeleteAsync();
            return total > 0;
        }


        public override async Task<List<TempBarberServices>?> GetAllFilterAsync()
        {
            return await _dbSet.AsNoTracking()
                .Select(x => new TempBarberServices
                {
                    ApplicationID = x.ApplicationID
                 ,
                    TempServiceID = x.TempServiceID
                    , Duration = x.Duration
                    , Price = x.Price
                    , ServiceDetilasID = x.ServiceDetilasID
                })
                .ToListAsync();
        }


        public override async Task<TempBarberServices?> GetByIdAsync(int TempBarberServiceID)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.TempServiceID == TempBarberServiceID)
                .Select(x => new TempBarberServices
                {
                    ApplicationID = x.ApplicationID
                 ,
                    TempServiceID = x.TempServiceID
                    ,
                    Duration = x.Duration
                    ,
                    Price = x.Price
                    ,
                    ServiceDetilasID = x.ServiceDetilasID
                }).SingleOrDefaultAsync();
            ;
        }






        //public virtual Task<bool> DeleteRangeAsync(List<T> TempIDs)
        //{
        //    throw new NotImplementedException();

        //}

        // method add Range.
        // method update Range.
        // method Delete Range.
        // Get By ID 
        // Get All ();

        //public async Task<List<>>

    }
}
