using Microsoft.EntityFrameworkCore.Migrations;

namespace SeP.Service.DataContext.Migrations
{
    public partial class AddToUserLoginPasswordInitials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Initials",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }
    }
}
