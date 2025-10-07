using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class SpeclictyConfiguration: IEntityTypeConfiguration<Speclitys>
    {
        public void Configure(EntityTypeBuilder<Speclitys> builder)
        {
            builder.HasKey(x => x.SpecilityID);
            builder.Property(x => x.SpecilityName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.Description).HasColumnType("Nvarchar").HasMaxLength(100);
            builder.Property(x => x.Enabled).HasDefaultValue(true);
        }
    }
}