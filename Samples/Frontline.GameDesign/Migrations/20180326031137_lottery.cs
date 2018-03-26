using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class lottery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DLotteries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cost_item = table.Column<int>(nullable: false),
                    cost_res_cnt = table.Column<int>(nullable: false),
                    cost_res_type = table.Column<int>(nullable: false),
                    free_cd = table.Column<int>(nullable: false),
                    free_cnt = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    rand = table.Column<int>(nullable: false),
                    rand_first10 = table.Column<int>(nullable: false),
                    rand_sp = table.Column<int>(nullable: false),
                    ten_discount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLotteries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DLotteryGroups",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group = table.Column<JsonObject<Int32[]>>(nullable: true),
                    group_w = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLotteryGroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DLotteryRands",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group = table.Column<int>(nullable: false),
                    item_cnt = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    lv_max = table.Column<int>(nullable: false),
                    lv_min = table.Column<int>(nullable: false),
                    w = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLotteryRands", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DLotteries");

            migrationBuilder.DropTable(
                name: "DLotteryGroups");

            migrationBuilder.DropTable(
                name: "DLotteryRands");
        }
    }
}
