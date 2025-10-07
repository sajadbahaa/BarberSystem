//using DTLayer.Entities;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DTLayer.Data
{
    public class AppDbContext:DbContext
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
        }
        public DbSet<People> People { get; set; }   
        public DbSet<Speclitys> Speclitys { get; set; }
        public DbSet<ServicesDetials> ServicesDetials { get; set; }
        public DbSet<Servics> servics { get; set; }

    

    }
}
