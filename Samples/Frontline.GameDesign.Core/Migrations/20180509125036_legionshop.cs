using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class legionshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DLegionShopItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    commodity_stock = table.Column<int>(nullable: false),
                    cost_res_cnt = table.Column<int>(nullable: false),
                    cost_res_type = table.Column<int>(nullable: false),
                    item_cnt = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    level_min = table.Column<int>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLegionShopItem", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DLegionShopItem");
        }
    }
}
