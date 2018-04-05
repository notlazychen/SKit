using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class dikang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacTasks_Factories_PlayerId",
                table: "FacTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_FacWorkers_Factories_PlayerId",
                table: "FacWorkers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factories",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Factories");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Factories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factories",
                table: "Factories",
                column: "PlayerId");

            migrationBuilder.CreateTable(
                name: "DiKangs",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Best = table.Column<int>(nullable: false),
                    Current = table.Column<int>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    RecvBox = table.Column<string>(nullable: true),
                    ResetNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiKangs", x => x.PlayerId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FacTasks_Factories_PlayerId",
                table: "FacTasks",
                column: "PlayerId",
                principalTable: "Factories",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacWorkers_Factories_PlayerId",
                table: "FacWorkers",
                column: "PlayerId",
                principalTable: "Factories",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacTasks_Factories_PlayerId",
                table: "FacTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_FacWorkers_Factories_PlayerId",
                table: "FacWorkers");

            migrationBuilder.DropTable(
                name: "DiKangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factories",
                table: "Factories");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Factories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Factories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factories",
                table: "Factories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacTasks_Factories_PlayerId",
                table: "FacTasks",
                column: "PlayerId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacWorkers_Factories_PlayerId",
                table: "FacWorkers",
                column: "PlayerId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
