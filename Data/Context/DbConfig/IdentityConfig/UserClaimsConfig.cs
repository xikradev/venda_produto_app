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
    public class UserClaimsConfig : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.HasOne(o => o.User)
            .WithMany(o => o.UserClaims)
            .HasForeignKey(o => o.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.ClaimType)
                .IsRequired(true);

            builder.Property(o => o.ClaimValue)
                .IsRequired(true);

            builder.ToTable("AspNetUserClaims");
        }
    }
}
