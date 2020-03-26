using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.Mappings
{
    public class AdMapConfig : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {

            //(One To Many) For Ad and Seller
            builder.HasOne(a => a.SellerUser)
                   .WithMany(s => s.Ads)
                   .HasForeignKey(s => s.SellerUserID)
                   .IsRequired(true);

            //(One To One) For Ad and Sale
            builder.HasOne(a => a.Sale)
                    .WithOne(s => s.Ad)
                    .HasForeignKey<Sale>(s => s.AdId)
                    .IsRequired(false);

            builder.HasKey(x => x.ID);

            builder.Property(a => a.ItemID).IsRequired(true);

            builder.Property(a => a.SaleID).IsRequired(false);

            builder.Property(a => a.SellerUserID).IsRequired(true);
        }
    }
}
