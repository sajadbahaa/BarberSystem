using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataLayer.Configurations
{
    public class BarberConfiguration: IEntityTypeConfiguration<Barbers>
    {

        public void Configure(EntityTypeBuilder<Barbers> builder)
        {
            builder.HasKey(x => x.BarberID);

            builder.Property(x => x.Location).HasColumnType("Nvarchar").HasMaxLength(30);

            builder.Property(x => x.ShopName).HasColumnType("Nvarchar").HasMaxLength(30);

            builder.Property(x => x.Rating).HasPrecision(3, 1)
                .HasDefaultValue((decimal)0.0);
            builder.HasOne(x => x.people).WithOne(x => x.Barbers).HasForeignKey<Barbers>(x => x.PersonID);
            builder.HasOne(x => x.user).WithOne(x => x.Barbers).HasForeignKey<Barbers>(x => x.UserID);

        }
    }
}