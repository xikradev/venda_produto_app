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
    public class UserLoginConfig : IEntityTypeConfiguration<UserLogins>
    {
        public void Configure(EntityTypeBuilder<UserLogins> builder)
        {
            builder.HasNoKey();

            builder.Property(x => x.LoginProvider)
                .HasMaxLength(450)
                .IsRequired(false);

            builder.Property(x => x.ProviderKey)
                .HasMaxLength(450)
                .IsRequired(false);

            builder.Property(x => x.ProviderDisplayName)
                .HasMaxLength(int.MaxValue)
                .IsRequired(false);

            builder.ToTable("AspNetUserLogins");
        }
    }
}
