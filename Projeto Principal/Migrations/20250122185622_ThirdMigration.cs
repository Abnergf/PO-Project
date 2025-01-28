using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Principal.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Professionals",
                newName: "FieldOfOperationId");

            migrationBuilder.AddColumn<int>(
                name: "FieldOfOperationCode",
                table: "Professionals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FieldOfOperation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "FieldOfOperation",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_FieldOfOperationId",
                table: "Professionals",
                column: "FieldOfOperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationId",
                table: "Professionals",
                column: "FieldOfOperationId",
                principalTable: "FieldOfOperation",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationId",
                table: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_FieldOfOperationId",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "FieldOfOperationCode",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "FieldOfOperation");

            migrationBuilder.RenameColumn(
                name: "FieldOfOperationId",
                table: "Professionals",
                newName: "Code");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FieldOfOperation",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
