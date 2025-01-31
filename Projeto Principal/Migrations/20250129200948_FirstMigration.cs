using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Principal.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldOfOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfOperation", x => x.Id);
                    table.UniqueConstraint("AK_FieldOfOperation_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldOfOperationCode = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professionals_FieldOfOperation_FieldOfOperationCode",
                        column: x => x.FieldOfOperationCode,
                        principalTable: "FieldOfOperation",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalsInProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    FieldOfOperationId = table.Column<int>(type: "int", nullable: false),
                    AssociationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalsInProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalsInProjects_FieldOfOperation_FieldOfOperationId",
                        column: x => x.FieldOfOperationId,
                        principalTable: "FieldOfOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfessionalsInProjects_Professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfessionalsInProjects_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstimatedTime = table.Column<float>(type: "real", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TaskFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false),
                    FileTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskFiles_ProjectTasks_ProjectTaskId",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_FieldOfOperationCode",
                table: "Professionals",
                column: "FieldOfOperationCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalsInProjects_FieldOfOperationId",
                table: "ProfessionalsInProjects",
                column: "FieldOfOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalsInProjects_ProfessionalId",
                table: "ProfessionalsInProjects",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalsInProjects_ProjectId",
                table: "ProfessionalsInProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProfessionalId",
                table: "ProjectTasks",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFiles_ProjectTaskId",
                table: "TaskFiles",
                column: "ProjectTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalsInProjects");

            migrationBuilder.DropTable(
                name: "TaskFiles");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Professionals");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "FieldOfOperation");
        }
    }
}
