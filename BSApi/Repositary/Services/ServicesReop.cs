using Microsoft.Extensions.DependencyInjection;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepLayer.Services
{
    static  public  class ServicesReop
    {
        static public IServiceCollection AddRepoServices(this IServiceCollection services) 
        {
            services.AddScoped<PeopleRepo>();
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
