using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class UserRolesConfigurations:IEntityTypeConfiguration<IdentityUserRole<int>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.RoleId
            }); // composite key
            builder.Property(x => x.UserId);
            builder.Property(x => x.RoleId);

        }
    }
}