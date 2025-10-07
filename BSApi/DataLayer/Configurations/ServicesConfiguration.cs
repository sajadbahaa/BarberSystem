using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class ServicesConfiguration:IEntityTypeConfiguration<Servics>
    {

        public void Configure(EntityTypeBuilder<Servics> builder)
        {
            builder.HasKey(x => x.ServiceID);
            builder.Property(x => x.ServiceName).HasColumnType("Nvarchar").HasMaxLength(30);
            builder.Property(x => x.price).HasPrecision(18, 2);
            builder.Property(x => x.Enabled).HasDefaultValue(true);
        }
    }
}