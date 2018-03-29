using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class fac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DFacTaskGroup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gourp_supply = table.Column<int>(nullable: false),
                    group_iron = table.Column<int>(nullable: false),
                    max_level = table.Column<int>(nullable: false),
                    min_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFacTaskGroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DFacTasks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cost_oil = table.Column<int>(nullable: false),
                    cost_time = table.Column<TimeSpan>(nullable: false),
                    done_item_cnt = table.Column<int>(nullable: false),
                    done_item_id = table.Column<int>(nullable: false),
                    group = table.Column<int>(nullable: false),
                    item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_cnt_ex = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_id_ex = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    reward_ex_prob = table.Column<float>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    w = table.Column<int>(nullable: false),
                    worker_q = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFacTasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DFacWorkers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    itemes_p = table.Column<int>(nullable: false),
                    output_p = table.Column<int>(nullable: false),
                    res_cnt = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFacWorkers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DFacTaskGroup");

            migrationBuilder.DropTable(
                name: "DFacTasks");

            migrationBuilder.DropTable(
                name: "DFacWorkers");
        }
    }
}
