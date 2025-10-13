using Microsoft.Extensions.DependencyInjection;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepLayer.Services
{
    static  public  class Services
    {
        static public IServiceCollection AddRepoServices(this IServiceCollection services) 
        {
            services.AddScoped<PeopleRepo>();
            services.AddScoped<SpeclitsRepo>();
            services.AddScoped<ServicsRepo>();
            services.AddScoped<ServiceDetilasRepo>();
            services.AddScoped<UserRepo>();
            services.AddScoped<TempBarberServicesRepo>();
            services.AddScoped<BarberAplicationRepo>();
            services.AddScoped<ApplicationsHistoryRepo>();

            //services.AddScoped<RolesRepo>();


            //services.AddScoped<SpecilizeRepo>();
            //services.AddScoped<CourseRepo>();
            //services.AddScoped<PeopleRepo>();
            //services.AddScoped<TeacherRepo>();
            //services.AddScoped<TeacherCourseRepo>();
            //services.AddScoped<StudentsRepo>();
            //services.AddScoped<EnrollmentRepo>();
            //services.AddScoped<EnrollmentDetialsRepo>();

            return services;
        }
    }
}
