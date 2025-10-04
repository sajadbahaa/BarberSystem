using DTLayer.Data;
//using DTLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Services
{
   static  public  class ServiceExtensions
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // قراءة الـ Connection String من appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //}
            // إضافة AppDbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }


    }

}
