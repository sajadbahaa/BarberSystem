using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
               .HasMaxLength(30)      // ← هنا تحدد الطول الجديد
               .IsRequired()
               .HasColumnType("varchar");


            builder.Property(x => x.Email)
               .HasMaxLength(30)      // ← هنا تحدد الطول الجديد
               .IsRequired()
               .HasColumnType("varchar");


            builder.Property(x => x.NormalizedEmail)
               .HasMaxLength(30)      // ← هنا تحدد الطول الجديد
               .HasColumnType("varchar");


            builder.Property(x => x.ConcurrencyStamp)
               .HasMaxLength(256)      // ← هنا تحدد الطول الجديد
               .HasColumnType("varchar");

            builder.Property(x => x.NormalizedUserName)
               .HasMaxLength(30)      // ← هنا تحدد الطول الجديد
               .HasColumnType("varchar");

            // تغيير طول Password (اختياري)
            builder.Property(x => x.PasswordHash)
                   .HasMaxLength(256)    
                   .HasColumnName("PasswordHash")
                   // الافتراضي طويل جداً، إذا تقصره تأكد أنه كافي للـ Hash
                   

                   .IsRequired(); builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            
                
                }
    }
}
