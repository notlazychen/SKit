using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PVPFormation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    IsSelected = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Units = table.Column<JsonObject<List<string>>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVPFormation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PVPFormation_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    IsSelected = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Units = table.Column<JsonObject<List<string>>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    RestEndTime = table.Column<DateTime>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PVPFormation_PlayerId",
                table: "PVPFormation",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PlayerId",
                table: "Team",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_PlayerId",
                table: "Unit",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PVPFormation");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
