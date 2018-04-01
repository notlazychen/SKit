using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class quest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DQuestDailyRewards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    lv = table.Column<JsonObject<Int32[]>>(nullable: true),
                    point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DQuestDailyRewards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DQuestDailys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    condition_target = table.Column<int>(nullable: false),
                    condition_type = table.Column<int>(nullable: false),
                    level_area = table.Column<JsonObject<Int32[]>>(nullable: true),
                    max_progress = table.Column<int>(nullable: false),
                    quest_point = table.Column<int>(nullable: false),
                    res_exp = table.Column<int>(nullable: false),
                    res_oil = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DQuestDailys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DQuests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    condition_target = table.Column<int>(nullable: false),
                    condition_type = table.Column<int>(nullable: false),
                    index = table.Column<int>(nullable: false),
                    limit_level = table.Column<int>(nullable: false),
                    max_progress = table.Column<int>(nullable: false),
                    next_quest_id = table.Column<int>(nullable: false),
                    res_diamond = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DQuests", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DQuestDailyRewards");

            migrationBuilder.DropTable(
                name: "DQuestDailys");

            migrationBuilder.DropTable(
                name: "DQuests");
        }
    }
}
