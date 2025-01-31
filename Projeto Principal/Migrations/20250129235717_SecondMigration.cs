using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Principal.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                table: "Professionals");

            migrationBuilder.AlterColumn<int?>(
                name: "FieldOfOperationCode",
                table: "Professionals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                table: "Professionals",
                column: "FieldOfOperationCode",
                principalTable: "FieldOfOperation",
                principalColumn: "Code");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                table: "Professionals");

            migrationBuilder.AlterColumn<int>(
                name: "FieldOfOperationCode",
                table: "Professionals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                table: "Professionals",
                column: "FieldOfOperationCode",
                principalTable: "FieldOfOperation",
                principalColumn: "Code",
                onDelete: ReferentialAction.SetDefault);
        }
    }
}
