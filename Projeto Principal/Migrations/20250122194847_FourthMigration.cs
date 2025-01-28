using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Principal.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationId",
                table: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_FieldOfOperationId",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "FieldOfOperationId",
                table: "Professionals");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_FieldOfOperation_Code",
                table: "FieldOfOperation",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_FieldOfOperationCode",
                table: "Professionals",
                column: "FieldOfOperationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                table: "Professionals",
                column: "FieldOfOperationCode",
                principalTable: "FieldOfOperation",
                principalColumn: "Code",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                table: "Professionals");

            migrationBuilder.DropIndex(
                name: "IX_Professionals_FieldOfOperationCode",
                table: "Professionals");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_FieldOfOperation_Code",
                table: "FieldOfOperation");

            migrationBuilder.AddColumn<int>(
                name: "FieldOfOperationId",
                table: "Professionals",
                type: "int",
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
