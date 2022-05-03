using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieClickerLibrary.Migrations
{
    public partial class AddedPlayerCps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "UserAccounts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Cps",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "Cps",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
