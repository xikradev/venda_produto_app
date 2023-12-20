using Domain.Models.Identity_Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.DbConfig.IdentityConfig
{
    public class RolesClaimsConfig : IEntityTypeConfiguration<RolesClaims>
    {
        public void Configure(EntityTypeBuilder<RolesClaims> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Roles)
                .WithMany(x => x.RoleClaims)
                .HasForeignKey(x => x.RoleId)
                .IsRequired(false);

            builder.Property(o => o.ClaimType)
                .HasMaxLength(int.MaxValue)
                .IsRequired(false);

            builder.Property(o => o.ClaimValue)
              .HasMaxLength(int.MaxValue)
              .IsRequired(false);


            builder.ToTable("AspNetRoleClaims");
        }
    }
}
