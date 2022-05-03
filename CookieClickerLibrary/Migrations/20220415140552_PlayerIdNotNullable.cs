using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieClickerLibrary.Migrations
{
    public partial class PlayerIdNotNullable : Migration
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
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "UserAccounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Players_PlayerId",
                table: "UserAccounts",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
