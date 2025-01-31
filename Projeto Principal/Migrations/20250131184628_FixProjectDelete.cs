using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Principal.Migrations
{
    /// <inheritdoc />
    public partial class FixProjectDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                IF EXISTS (SELECT * 
                           FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
                           WHERE CONSTRAINT_NAME = 'FK_ProfessionalsInProjects_Project_ProjectId')
                BEGIN
                    ALTER TABLE [ProfessionalsInProjects] DROP CONSTRAINT [FK_ProfessionalsInProjects_Project_ProjectId];
                END
                ");

            migrationBuilder.Sql(
                @"
                IF EXISTS (SELECT * 
                           FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
                           WHERE CONSTRAINT_NAME = 'FK_TaskFiles_Tasks_ProjectTaskId')
                BEGIN
                    ALTER TABLE [TaskFiles] DROP CONSTRAINT [FK_TaskFiles_Tasks_ProjectTaskId];
                END
                ");

            migrationBuilder.Sql(
                @"
                IF OBJECT_ID('Tasks', 'U') IS NOT NULL
                BEGIN
                    DROP TABLE [Tasks];
                END
                ");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProfessionalsInProjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TaskFiles",
                type: "int",
                nullable: true);

            migrationBuilder.Sql(
                @"
                IF OBJECT_ID('ProjectTasks', 'U') IS NULL
                BEGIN
                    CREATE TABLE [ProjectTasks] (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Title NVARCHAR(100) NOT NULL,
                        Description NVARCHAR(200) NOT NULL,
                        EstimatedTime REAL NOT NULL,
                        CreationDate DATETIME2 NOT NULL,
                        StartDate DATETIME2 NOT NULL,
                        CompletedDate DATETIME2 NOT NULL,
                        ProfessionalId INT NOT NULL,
                        ProjectId INT NOT NULL,
                        Status INT NOT NULL
                    );
                    ALTER TABLE [ProjectTasks] 
                    ADD CONSTRAINT FK_ProjectTasks_Professionals_ProfessionalId FOREIGN KEY (ProfessionalId) 
                    REFERENCES Professionals (Id) ON DELETE CASCADE;
                    ALTER TABLE [ProjectTasks] 
                    ADD CONSTRAINT FK_ProjectTasks_Project_ProjectId FOREIGN KEY (ProjectId) 
                    REFERENCES Project (Id) ON DELETE CASCADE;
                END
                ");

            migrationBuilder.Sql(
                @"
                IF NOT EXISTS (SELECT * 
                               FROM sys.indexes 
                               WHERE name = 'IX_ProjectTasks_ProfessionalId' 
                               AND object_id = OBJECT_ID('ProjectTasks'))
                BEGIN
                    CREATE INDEX IX_ProjectTasks_ProfessionalId 
                    ON ProjectTasks(ProfessionalId);
                END
                ");

            migrationBuilder.Sql(
                @"
                IF NOT EXISTS (SELECT * 
                               FROM sys.indexes 
                               WHERE name = 'IX_ProjectTasks_ProjectId' 
                               AND object_id = OBJECT_ID('ProjectTasks'))
                BEGIN
                    CREATE INDEX IX_ProjectTasks_ProjectId 
                    ON ProjectTasks(ProjectId);
                END
                ");

            migrationBuilder.Sql(
                @"
                IF NOT EXISTS (SELECT * 
                               FROM sys.foreign_keys 
                               WHERE name = 'FK_TaskFiles_ProjectTasks_ProjectTaskId')
                BEGIN
                    ALTER TABLE [TaskFiles] 
                    ADD CONSTRAINT FK_TaskFiles_ProjectTasks_ProjectTaskId FOREIGN KEY (ProjectTaskId) 
                    REFERENCES ProjectTasks (Id) ON DELETE CASCADE;
                END
                ");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFiles_ProjectId",
                table: "TaskFiles",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalsInProjects_Project_ProjectId",
                table: "ProfessionalsInProjects",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskFiles_Project_ProjectId",
                table: "TaskFiles",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalsInProjects_Project_ProjectId",
                table: "ProfessionalsInProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskFiles_ProjectTasks_ProjectTaskId",
                table: "TaskFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskFiles_Project_ProjectId",
                table: "TaskFiles");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskFiles_ProjectId",
                table: "TaskFiles");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TaskFiles");

            migrationBuilder.Sql(
                @"
                IF OBJECT_ID('Tasks', 'U') IS NOT NULL
                BEGIN
                    CREATE TABLE [Tasks] (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ProfessionalId INT NOT NULL,
                        ProjectId INT NOT NULL,
                        CompletedDate DATETIME2 NOT NULL,
                        CreationDate DATETIME2 NOT NULL,
                        Description NVARCHAR(200) NOT NULL,
                        EstimatedTime REAL NOT NULL,
                        StartDate DATETIME2 NOT NULL,
                        Status INT NOT NULL,
                        Title NVARCHAR(100) NOT NULL
                    );
                    ALTER TABLE [Tasks] 
                    ADD CONSTRAINT FK_Tasks_Professionals_ProfessionalId FOREIGN KEY (ProfessionalId) 
                    REFERENCES Professionals (Id) ON DELETE CASCADE;
                    ALTER TABLE [Tasks] 
                    ADD CONSTRAINT FK_Tasks_Project_ProjectId FOREIGN KEY (ProjectId) 
                    REFERENCES Project (Id) ON DELETE CASCADE;
                END
                ");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "ProfessionalsInProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProfessionalId",
                table: "Tasks",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalsInProjects_Project_ProjectId",
                table: "ProfessionalsInProjects",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskFiles_Tasks_ProjectTaskId",
                table: "TaskFiles",
                column: "ProjectTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
