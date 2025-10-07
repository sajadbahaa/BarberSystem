using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class ServicesDetialsConfiguration: IEntityTypeConfiguration<ServicesDetials>
    {

        public void Configure(EntityTypeBuilder<ServicesDetials> builder)
        {
            builder.HasKey(x => x.ServiceDetilasID);
            builder.HasOne(x => x.Speclitys)
                .WithMany(x => x.ServicesDetials).HasForeignKey(x => x.SpecilityID);
            builder.HasOne(x => x.servics).WithOne(x => x.servicesDetials)
                .HasForeignKey<ServicesDetials>(x => x.ServiceID);
        }
    }
}