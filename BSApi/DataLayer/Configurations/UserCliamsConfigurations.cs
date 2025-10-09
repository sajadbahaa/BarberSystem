using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class UserCliamsConfigurations: IEntityTypeConfiguration<IdentityUserClaim<int>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.UserId);
            builder.Property(x => x.ClaimType).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.ClaimValue).HasColumnType("varchar").HasMaxLength(50);

        }
    }
}