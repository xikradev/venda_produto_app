using Domain.Models.Identity_Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ConfigDbContext
{
    public class UserClaimsDbConfig : IEntityTypeConfiguration<UserClaims>
    {
        public void Configure(EntityTypeBuilder<UserClaims> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.User)
                .WithMany(o => o.UserClaims)
                .HasForeignKey(o => o.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasDiscriminator(o => o.Discriminator);

            builder.Property(o => o.ClaimType)
                .IsRequired(true);

            builder.Property(o => o.ClaimValue)
                .IsRequired(true);

            builder.ToTable("AspNetUserClaims");
        }
    }
}
