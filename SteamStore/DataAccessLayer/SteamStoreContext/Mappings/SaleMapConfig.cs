using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessObject.SteamCommunityStore.Mappings
{
    public class SaleMapConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            //(One To One) For Sale and Ad
            builder.HasOne(s => s.Ad)
                   .WithOne(a => a.Sale)
                   .HasForeignKey<Ad>(a => a.SaleID)
                   .IsRequired(true);

            //(One To Many) For Sale and User(Buyer)
            builder.HasOne(s => s.Buyer)
                   .WithMany(b => b.Sales)
                   .HasForeignKey(b => b.BuyerId)
                   .IsRequired(true);

            builder.Property(s => s.AdId).IsRequired(true);

            builder.Property(s => s.BuyerId).IsRequired(true);

        }
    }
}
