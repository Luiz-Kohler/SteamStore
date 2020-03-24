using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Items_ItemID1",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_ItemID1",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ItemID1",
                table: "Ads");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemID",
                table: "Ads",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");                                                

            migrationBuilder.CreateIndex(
                name: "IX_Ads_ItemID",
                table: "Ads",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Items_ItemID",
                table: "Ads",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Items_ItemID",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_ItemID",
                table: "Ads");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Ads",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemID1",
                table: "Ads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_ItemID1",
                table: "Ads",
                column: "ItemID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Items_ItemID1",
                table: "Ads",
                column: "ItemID1",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
