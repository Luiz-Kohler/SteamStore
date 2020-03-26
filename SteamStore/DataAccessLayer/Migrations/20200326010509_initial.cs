using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    BornDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Nick = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    BornDate = table.Column<DateTime>(nullable: false),
                    Cash = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(maxLength: 100, nullable: false),
                    DateTimeComment = table.Column<DateTime>(nullable: false),
                    WritterID = table.Column<Guid>(nullable: false),
                    ForUserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Users_ForUserID",
                        column: x => x.ForUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comments_Users_WritterID",
                        column: x => x.WritterID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RequestUserID = table.Column<Guid>(nullable: false),
                    ForUserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_ForUserID",
                        column: x => x.ForUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_RequestUserID",
                        column: x => x.RequestUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    FriendUserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Friends_Users_FriendUserID",
                        column: x => x.FriendUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateSell = table.Column<DateTime>(nullable: false),
                    BuyerId = table.Column<Guid>(nullable: false),
                    AdId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sales_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DateAd = table.Column<DateTime>(nullable: false),
                    ItemID = table.Column<Guid>(nullable: false),
                    SellerUserID = table.Column<Guid>(nullable: false),
                    SaleID = table.Column<Guid>(nullable: true),
                    IsSold = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ads_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ads_Sales_SaleID",
                        column: x => x.SaleID,
                        principalTable: "Sales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ads_Users_SellerUserID",
                        column: x => x.SellerUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_ItemID",
                table: "Ads",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_SaleID",
                table: "Ads",
                column: "SaleID",
                unique: true,
                filter: "[SaleID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_SellerUserID",
                table: "Ads",
                column: "SellerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ForUserID",
                table: "Comments",
                column: "ForUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WritterID",
                table: "Comments",
                column: "WritterID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ForUserID",
                table: "FriendRequests",
                column: "ForUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_RequestUserID",
                table: "FriendRequests",
                column: "RequestUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendUserID",
                table: "Friends",
                column: "FriendUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserID",
                table: "Friends",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserID",
                table: "Items",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerId",
                table: "Sales",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Nick",
                table: "Users",
                column: "Nick");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
