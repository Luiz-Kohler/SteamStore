using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.Mappings
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            //(One To One) for User and Inventory


            //(One To Many) for User and Ads
            builder.HasMany(u => u.Ads)
                    .WithOne(a => a.SellerUser)
                    .HasForeignKey(a => a.SellerUserID);

            //(One To Many) for User and Sale
            builder.HasMany(u => u.Sales)
                    .WithOne(s => s.Buyer)
                    .HasForeignKey(s => s.BuyerId);


            //(Many to one) for user comments
            builder.HasMany(u => u.ForMeComments)
                   .WithOne(c => c.Writter)
                   .HasForeignKey(c => c.WritterID);

            //(Many to one) for user comments
            builder.HasMany(u => u.MyComments)
                   .WithOne(c => c.ForUser)
                   .HasForeignKey(c => c.ForUserID);


            //(Many to one) for user request's
            builder.HasMany(u => u.ForMeFriendRequest)
                   .WithOne(f => f.RequestUser)
                   .HasForeignKey(f => f.RequestUserID);

            //(Many to one) for user request's
            builder.HasMany(u => u.MyFriendRequest)
                   .WithOne(f => f.ForUser)
                   .HasForeignKey(f => f.ForUserID);

            //(Many to one) for user friend's
            builder.HasMany(u => u.Friends)
                   .WithOne(f => f.User)
                   .HasForeignKey(f => f.UserID);

            builder.Property(u => u.Nick).IsRequired(true).IsUnicode(false).HasMaxLength(20);
            builder.HasIndex(u => u.Nick).IsUnique(false);
        }
    }
}
