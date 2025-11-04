using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class RaingsConfigurations : IEntityTypeConfiguration<Ratings>
    {
        public void Configure(EntityTypeBuilder<Ratings> builder)
        {
            builder.HasKey(x => x.RatingID);
            builder.Property(x => x.Score).HasColumnType("Tinyint");
            builder.HasOne(x => x.Customer).WithMany(x => x.ratings).
                HasForeignKey(x => x.CustomerID);
            builder.HasOne(x => x.Barber).WithMany(x => x.ratings).
                HasForeignKey(x => x.BarberID);
            builder.HasOne(x => x.appointments).WithOne(x => x.ratings)
                .HasForeignKey<Ratings>(x => x.AppointmentID);
            builder.HasIndex(x => x.BarberID);
        }
    }
}
