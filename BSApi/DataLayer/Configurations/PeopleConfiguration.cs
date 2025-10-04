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
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(x => x.PersonID);
            builder.Property(x => x.FirstName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.SecondName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.LastName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(12);

            builder.Property(x => x.Enabled).HasDefaultValue(true);

        }
    }
}
