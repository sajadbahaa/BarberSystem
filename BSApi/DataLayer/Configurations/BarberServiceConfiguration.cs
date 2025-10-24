using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class BarberServiceConfiguration:IEntityTypeConfiguration<BarberServices>
    {

        public void Configure(EntityTypeBuilder<BarberServices> builder)
        {
            builder.HasKey(x => x.BarberServiceID);

            builder.Property(x => x.Enabled).HasDefaultValue(true);

            builder.Property(x => x.Price).HasPrecision(18, 2);
            builder.Property(x => x.Duration).HasColumnType("time");

            builder.HasOne(x => x.ServicesDetials).WithMany(x => x.BarberServices).HasForeignKey(x => x.ServiceDetilasID);
            builder.HasOne(x => x.barbers).WithMany(x => x.BarberServices).HasForeignKey(x => x.BarberID);

            builder.HasIndex(x => new { x.BarberID, x.ServiceDetilasID })
       .IsUnique();

        }
    }
}