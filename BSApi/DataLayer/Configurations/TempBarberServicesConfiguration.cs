using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class TempBarberServicesConfiguration:IEntityTypeConfiguration<TempBarberServices>
    {


        public void Configure(EntityTypeBuilder<TempBarberServices> builder)
        {
            builder.HasKey(x => x.TempServiceID);
            builder.HasOne(x => x.barberApplication).WithMany(x => x.TempBarberServices).HasForeignKey(x => x.ApplicationID);
            builder.HasOne(x => x.servicesDetials).WithMany(x => x.TempBarberServices).HasForeignKey(x => x.ServiceDetilasID);


            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.Property(x => x.Duration).HasColumnType("time");

            builder.HasIndex(x => new { x.ApplicationID, x.ServiceDetilasID })
       .IsUnique();




            //builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(30);
        }
    }
}