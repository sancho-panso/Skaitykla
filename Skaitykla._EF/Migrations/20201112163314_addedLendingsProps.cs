using Microsoft.EntityFrameworkCore.Migrations;

namespace Skaitykla._EF.Migrations
{
    public partial class addedLendingsProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lendings_Books_LendedBookID",
                table: "Lendings");

            migrationBuilder.AlterColumn<int>(
                name: "LendedBookID",
                table: "Lendings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lendings_Books_LendedBookID",
                table: "Lendings",
                column: "LendedBookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lendings_Books_LendedBookID",
                table: "Lendings");

            migrationBuilder.AlterColumn<int>(
                name: "LendedBookID",
                table: "Lendings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lendings_Books_LendedBookID",
                table: "Lendings",
                column: "LendedBookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
