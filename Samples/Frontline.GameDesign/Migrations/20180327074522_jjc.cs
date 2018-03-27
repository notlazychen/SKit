using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class jjc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DArenaChallengeRewards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    random_id = table.Column<int>(nullable: false),
                    times = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DArenaChallengeRewards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DArenaRankRewards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    items_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    items_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    random_id = table.Column<int>(nullable: false),
                    rank_area = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DArenaRankRewards", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DArenaChallengeRewards");

            migrationBuilder.DropTable(
                name: "DArenaRankRewards");
        }
    }
}
