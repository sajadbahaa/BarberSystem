using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class RolesCliamConfigurations:IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {

        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.RoleId);
            builder.Property(x => x.ClaimType).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.ClaimValue).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}