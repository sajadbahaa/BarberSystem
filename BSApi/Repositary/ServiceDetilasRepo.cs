using DataLayer.Entities;
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
    public class ServiceDetilasRepo : Repo<ServicesDetials, short>
    {
        public ServiceDetilasRepo(AppDbContext context) : base(context)
        {
        }

        public override async Task<bool> AddRangeCustomAsync(List<ServicesDetials> entities)
        {
            await _context.AddRangeAsync(entities);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }


        

    }
}
