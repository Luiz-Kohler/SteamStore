using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ChangeColumnNameEmailAndPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login_Password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Login_Email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Login_Password",
                table: "Admins",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Login_Email",
                table: "Admins",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Login_Password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Login_Email");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "Login_Password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Admins",
                newName: "Login_Email");
        }
    }
}
