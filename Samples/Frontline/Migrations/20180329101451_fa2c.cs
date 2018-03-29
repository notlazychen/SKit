using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class fa2c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    HireWorkerNumb = table.Column<int>(nullable: false),
                    LastRefreshDay = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    TodayMarketRefreshTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                    table.UniqueConstraint("AK_Factories_PlayerId", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "FacTasks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    FacWorkers = table.Column<string>(maxLength: 512, nullable: true),
                    IsWorkersReleased = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacTasks_Factories_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacWorkers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FacTaskId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacWorkers_Factories_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacTasks_PlayerId",
                table: "FacTasks",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FacWorkers_PlayerId",
                table: "FacWorkers",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacTasks");

            migrationBuilder.DropTable(
                name: "FacWorkers");

            migrationBuilder.DropTable(
                name: "Factories");
        }
    }
}
