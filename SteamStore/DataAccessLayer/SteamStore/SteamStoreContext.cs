using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataAccessLayer.SteamStore
{
    public class SteamStoreContext : DbContext
    {
        public SteamStoreContext(DbContextOptions<SteamStoreContext> options) : base(options)
        {
        }



        public DbSet<Ad> Ads { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Using every mappings in this assembly for creat the database.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<User>(table =>
            {
                table.OwnsOne(
                    x => x.Login,
                    login =>
                    {
                        login.Property(x => x.Email).IsRequired(true).HasColumnName("Email");
                        login.Property(x => x.Password).IsRequired(true).HasColumnName("Password");
                    });
            });

            modelBuilder.Entity<Admin>(table =>
            {
                table.OwnsOne(
                    x => x.Login,
                    login =>
                    {
                        login.Property(x => x.Email).IsRequired(true).HasColumnName("Email");
                        login.Property(x => x.Password).IsRequired(true).HasColumnName("Password");
                    });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
