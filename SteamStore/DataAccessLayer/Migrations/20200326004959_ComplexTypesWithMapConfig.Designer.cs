﻿// <auto-generated />
using System;
using DataAccessLayer.SteamStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(SteamStoreContext))]
    [Migration("20200326004959_ComplexTypesWithMapConfig")]
    partial class ComplexTypesWithMapConfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Entities.Ad", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAd")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<Guid>("ItemID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SaleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SellerUserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("SaleID")
                        .IsUnique()
                        .HasFilter("[SaleID] IS NOT NULL");

                    b.HasIndex("SellerUserID");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("Entities.Entities.Admin", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Entities.Entities.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeComment")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ForUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<Guid>("WritterID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ForUserID");

                    b.HasIndex("WritterID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entities.Entities.Friend", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FriendUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("FriendUserID");

                    b.HasIndex("UserID");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Entities.Entities.FriendRequest", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ForUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RequestUserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ForUserID");

                    b.HasIndex("RequestUserID");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("Entities.Entities.Item", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Entities.Entities.Sale", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSell")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BuyerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Entities.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.HasIndex("Nick");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Entities.Ad", b =>
                {
                    b.HasOne("Entities.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.Sale", "Sale")
                        .WithOne("Ad")
                        .HasForeignKey("Entities.Entities.Ad", "SaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.User", "SellerUser")
                        .WithMany("Ads")
                        .HasForeignKey("SellerUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.Admin", b =>
                {
                    b.OwnsOne("Entities.ComplexTypes.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("AdminID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(60)")
                                .HasMaxLength(60)
                                .IsUnicode(true);

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnName("Password")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100)
                                .IsUnicode(true);

                            b1.HasKey("AdminID");

                            b1.ToTable("Admins");

                            b1.WithOwner()
                                .HasForeignKey("AdminID");
                        });
                });

            modelBuilder.Entity("Entities.Entities.Comment", b =>
                {
                    b.HasOne("Entities.Entities.User", "ForUser")
                        .WithMany("MyComments")
                        .HasForeignKey("ForUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.User", "Writter")
                        .WithMany("ForMeComments")
                        .HasForeignKey("WritterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.Friend", b =>
                {
                    b.HasOne("Entities.Entities.User", "FriendUser")
                        .WithMany()
                        .HasForeignKey("FriendUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.FriendRequest", b =>
                {
                    b.HasOne("Entities.Entities.User", "ForUser")
                        .WithMany("MyFriendRequest")
                        .HasForeignKey("ForUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.User", "RequestUser")
                        .WithMany("ForMeFriendRequest")
                        .HasForeignKey("RequestUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.Item", b =>
                {
                    b.HasOne("Entities.Entities.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.Sale", b =>
                {
                    b.HasOne("Entities.Entities.User", "Buyer")
                        .WithMany("Sales")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Entities.User", b =>
                {
                    b.OwnsOne("Entities.ComplexTypes.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("UserID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(60)")
                                .HasMaxLength(60)
                                .IsUnicode(true);

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnName("Password")
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100)
                                .IsUnicode(true);

                            b1.HasKey("UserID");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserID");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
