using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public class UserTokensConfigurations:IEntityTypeConfiguration<IdentityUserToken<int>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }); // composite key
            builder.Property(x => x.UserId);
            builder.Property(x => x.LoginProvider)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
            builder.Property(x => x.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
            /// value token
            builder.Property(x => x.Value)
                   .HasColumnType("varchar")
                   .HasMaxLength(500);
        }
    }
}