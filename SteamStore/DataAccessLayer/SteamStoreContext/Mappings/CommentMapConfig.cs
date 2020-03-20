using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.SteamStoreContext.Mappings
{
    public class CommentMapConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            //Relationship

            //(One to Many) for writter and comment
            builder.HasOne(c => c.Writter)
                   .WithMany(u => u.ForMeComments)
                   .HasForeignKey(c => c.WritterID)
                   .IsRequired(true);

            //(One to Many) for forUser and comment
            builder.HasOne(c => c.ForUser)
                   .WithMany(u => u.MyComments)
                   .HasForeignKey(c => c.ForUserID)
                   .IsRequired(true);

            builder.Property(c => c.Message).IsRequired(true).IsUnicode(true).HasMaxLength(100);
        }
    }
}
