using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class BarberApplicationConfiguration : IEntityTypeConfiguration<BarberApplications>
    {
        public void Configure(EntityTypeBuilder<BarberApplications> builder)
        {
            builder.HasKey(x => x.ApplicationID);
            builder.Property(x=>x.Status).HasConversion
                (
                 v => (byte)v,                     // Enum → byte عند التخزين
                v => (enApplicationStatus)v              // byte → Enum عند التحميل
            )
            .HasColumnType("TINYINT");

            builder.Property(x => x.CopyFirstName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.CopySecondName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.CopyLastName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.CopyPhone).HasColumnType("varchar").HasMaxLength(12);

            builder.Property(x => x.Shop).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.CreatAt).HasColumnType("Date")
                ;


            builder.Property(x => x.UpdateAt).HasColumnType("Date");

            builder.Property(x => x.Location).HasColumnType("Nvarchar").HasMaxLength(30);

            builder.Property(x => x.Reason).HasColumnType("Nvarchar").HasMaxLength(100);

            builder.HasOne(x => x.person).WithOne(x => x.BarberApplications).IsRequired(false);

            builder.HasOne(x => x.user).WithMany(x => x.barberApplications).HasForeignKey(x => x.UserID);
            //builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(30);

        }



   


    }

}
