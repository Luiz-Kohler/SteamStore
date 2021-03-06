﻿using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStore.Mappings
{
    public class FriendRequestMapConfig : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            //Relationships
            builder.HasOne(f => f.RequestUser)
                    .WithMany(u => u.ForMeFriendRequest)
                    .HasForeignKey(f => f.RequestUserID);

            builder.HasOne(f => f.ForUser)
                    .WithMany(u => u.MyFriendRequest)
                    .HasForeignKey(f => f.ForUserID);

            builder.HasKey(x => x.ID);

        }
    }
}
