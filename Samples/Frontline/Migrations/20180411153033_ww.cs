using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class ww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekBattleData",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    DaysInWeek = table.Column<int>(nullable: false),
                    LastRefreshDay = table.Column<DateTime>(nullable: false),
                    LastRefreshWeek = table.Column<DateTime>(nullable: false),
                    RecvBoxes = table.Column<string>(maxLength: 1024, nullable: true),
                    Score = table.Column<int>(nullable: false),
                    UseNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekBattleData", x => x.PlayerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekBattleData_PlayerId",
                table: "WeekBattleData",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekBattleData_Score",
                table: "WeekBattleData",
                column: "Score");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekBattleData");
        }
    }
}
