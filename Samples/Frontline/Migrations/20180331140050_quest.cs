using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class quest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerQuestDatas",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    DailyPoint = table.Column<int>(nullable: false),
                    DailyPointReward = table.Column<string>(nullable: true),
                    LastRefreshDay = table.Column<DateTime>(nullable: false),
                    RecvedDailyPointReward = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuestDatas", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "QuestDailys",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestDailys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestDailys_PlayerQuestDatas_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerQuestDatas",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_PlayerQuestDatas_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerQuestDatas",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestDailys_PlayerId",
                table: "QuestDailys",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_PlayerId",
                table: "Quests",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestDailys");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "PlayerQuestDatas");
        }
    }
}
