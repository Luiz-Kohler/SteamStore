using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessObject.SteamCommunityStore.Mappings
{
    public class AdminMapConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(a => a.BornDate).IsRequired(true);

            builder.Property(a => a.Login.Email).IsRequired(true).IsUnicode(false).HasMaxLength(100);
            builder.HasIndex(a => a.Login.Email).IsUnique(true);

            builder.Property(a => a.Name).IsRequired(true).IsUnicode(false).HasMaxLength(60);

            builder.Property(a => a.Login.Password).IsRequired(true).IsUnicode(false).HasMaxLength(16);
            builder.HasIndex(a => a.Login.Password).IsUnique(true);
        }
    }
}
