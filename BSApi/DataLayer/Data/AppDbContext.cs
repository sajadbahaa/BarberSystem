//using DTLayer.Entities;
using DataLayer.Configurations;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DTLayer.Data
{
    public class AppDbContext: IdentityDbContext<
        AppUser,        // User
        IdentityRole<int>,
        int,            // Key Type
        IdentityUserClaim<int>,      // UserClaim
        IdentityUserRole<int>,       // UserRole
        IdentityUserLogin<int>,      // UserLogin
        IdentityRoleClaim<int>,      // RoleClaim
        IdentityUserToken<int>>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
         
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(
        //            "Server=.;Database=SchoolDB;User ID=sa;Password=sa123456;TrustServerCertificate=True"
        //        );
        //    }
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
        public DbSet<People> People { get; set; }   
        public DbSet<Speclitys> Speclitys { get; set; }
        public DbSet<ServicesDetials> ServicesDetials { get; set; }
        public DbSet<Servics> servics { get; set; }
        public DbSet<BarberApplications> BarberApplications { get; set; }
        public DbSet<TempBarberServices> TempBarberServices { get; set; }
        public DbSet<ApplicationsHistory> applicationsHistory { get; set; }
        public DbSet<Barbers> barbers { get; set; }
        public DbSet<BarberServices> barberServices { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public  DbSet<Ratings> Ratings { get; set;}
    }
}
