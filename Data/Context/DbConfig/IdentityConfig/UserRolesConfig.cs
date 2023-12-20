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
    public class UserRolesConfig : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
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
