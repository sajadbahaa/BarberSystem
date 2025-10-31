using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class AppointmentsConfiguration : IEntityTypeConfiguration<Appointments>
    {
        public void Configure(EntityTypeBuilder<Appointments> builder)
        {
            builder.HasKey(x => x.AppointmentID);

            builder.HasOne(x=>x.customer).WithMany(x=>x.appointments).
                HasForeignKey(x=>x.CustomerID);
            builder.HasOne(x => x.barberServices).WithMany(x => x.appointments).
                HasForeignKey(x => x.BarberServiceID);
            builder.Property(x => x.status).HasConversion
               (
                v => (byte)v,                     // Enum → byte عند التخزين
               v => (enApplicationStatus)v              // byte → Enum عند التحميل
           )
           .HasColumnType("TINYINT");

            builder.HasIndex(x => new { x.BarberServiceID, x.StartDate, x.EndDate,x.status});

        }
    }
}
