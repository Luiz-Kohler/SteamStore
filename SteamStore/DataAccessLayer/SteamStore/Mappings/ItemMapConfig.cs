using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.Mappings
{
    public class ItemMapConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {

            //(One To Many) For Item and inventory
            builder.HasOne(item => item.User)
                   .WithMany(u => u.Items)
                   .HasForeignKey(u => u.UserID)
                   .IsRequired();

            builder.Property(i => i.Name).IsRequired(true).IsUnicode(false).HasMaxLength(60);

            builder.Property(i => i.UserID).IsRequired();
        }
    }
}
