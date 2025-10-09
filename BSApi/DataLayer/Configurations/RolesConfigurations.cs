using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class RolesConfigurations :  IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.NormalizedName).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.ConcurrencyStamp).HasColumnType("varchar").HasMaxLength(256);

        }
    }
}
