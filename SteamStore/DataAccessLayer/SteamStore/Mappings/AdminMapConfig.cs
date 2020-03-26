using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.Mappings
{
    public class AdminMapConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(a => a.BornDate).IsRequired(true);
            builder.Property(a => a.Name).IsRequired(true).IsUnicode(false).HasMaxLength(60);

        }
    }
}
