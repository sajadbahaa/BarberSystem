using BsLayer.maaper;
using BussinesLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using RepLayer;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    static  public class BussinesServices
    {
        public static IServiceCollection addBussinesServices(this IServiceCollection services) 
        {
            //services.AddScoped<TransactionService>();
            services.AddScoped<PeopleService>();
            services.AddScoped<ServicesDetilasService>();
            services.AddScoped<SpeclistServices>();
            services.AddScoped<AppUserService>();
            services.AddScoped<BarberApplicationService>();




            return services;
        }
    }
}
