using DataLayer.Entities;
using DataLayer.Entities.EnumClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class ApplicationsHistotyConfiguration: IEntityTypeConfiguration<ApplicationsHistory>
    {



        public void Configure(EntityTypeBuilder<ApplicationsHistory> builder)
        {
            builder.HasKey(x => x.HistoryID);
            builder.Property(x => x.Status).HasConversion
                (
                 v => (byte)v,                     // Enum → byte عند التخزين
                v => (enApplicationStatus)v              // byte → Enum عند التحميل
            )
            .HasColumnType("TINYINT");

            builder.Property(x => x.CreateAt).HasColumnType("datetime");

            builder.Property(x => x.Notes).HasColumnType("Nvarchar").HasMaxLength(100);


            builder.HasOne(x => x.user)
                .WithMany(x => x.applicationsHistories)
                .HasForeignKey(x => x.UserID);

            builder.HasOne(x => x.BarberApplication)
                .WithMany(x => x.applicationsHistories)
                .HasForeignKey(x => x.ApplicationID);




            //builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(30);

        }
    }
}