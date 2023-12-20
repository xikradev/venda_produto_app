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
    public class UserTokensConfig : IEntityTypeConfiguration<UsersToken>
    {
        public void Configure(EntityTypeBuilder<UsersToken> builder)
        {
            builder.HasNoKey();

            builder.Property(o => o.LoginProvider)
                .HasMaxLength(450)
                .IsRequired(false);

            builder.Property(o => o.LoginProvider)
              .HasMaxLength(450)
              .IsRequired(false);


            builder.Property(o => o.LoginProvider)
               .HasMaxLength(int.MaxValue)
               .IsRequired(false);


            builder.ToTable("AspNetUserTokens");
        }
    }
}
