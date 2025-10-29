using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customers>
    {

        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.CustomerID);

            builder.HasOne(x => x.person).WithOne(x => x.Customer).HasForeignKey<Customers>(x => x.PersonID);
            builder.HasOne(x => x.user).WithOne(x => x.Customers).HasForeignKey<Customers>(x => x.UserID);
        }
    }
}