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
    public class UserRolesDbConfig : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {

            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasDiscriminator(x => x.Discriminator);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder.HasOne(x => x.Roles)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId)
                .IsRequired()
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder.ToTable("AspNetUserRoles");
        }
    }
}
