using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class ral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DRaffle",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    drop = table.Column<int>(nullable: false),
                    item_cnt_max = table.Column<int>(nullable: false),
                    item_cnt_min = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    special = table.Column<bool>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    w_0 = table.Column<int>(nullable: false),
                    w_1 = table.Column<int>(nullable: false),
                    w_2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRaffle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DRaffleGroup",
                columns: table => new
                {
                    type = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adv_drop = table.Column<int>(nullable: false),
                    base_drop = table.Column<int>(nullable: false),
                    base_numb = table.Column<int>(nullable: false),
                    cost_item = table.Column<int>(nullable: false),
                    first_drop = table.Column<int>(nullable: false),
                    item_cnt_1 = table.Column<int>(nullable: false),
                    item_cnt_10 = table.Column<int>(nullable: false),
                    normal_drop = table.Column<int>(nullable: false),
                    second = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRaffleGroup", x => x.type);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DRaffle");

            migrationBuilder.DropTable(
                name: "DRaffleGroup");
        }
    }
}
