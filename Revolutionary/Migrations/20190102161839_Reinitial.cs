using Microsoft.EntityFrameworkCore.Migrations;

namespace Revolutionary.Migrations
{
    public partial class Reinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AccountInfomation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AccountInfomation");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accounts",
                nullable: true);
        }
    }
}
