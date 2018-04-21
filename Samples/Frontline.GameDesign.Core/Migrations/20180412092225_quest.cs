using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class quest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DMallShop",
                columns: table => new
                {
                    type = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    diamond = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 64, nullable: true),
                    refresh = table.Column<int>(nullable: false),
                    refresh_hour = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_type = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMallShop", x => x.type);
                });

            migrationBuilder.CreateTable(
                name: "DMallShopItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    count = table.Column<int>(nullable: false),
                    desc = table.Column<string>(maxLength: 64, nullable: true),
                    item_id = table.Column<int>(nullable: false),
                    rate = table.Column<int>(nullable: false),
                    res_cnt = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMallShopItem", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMallShop");

            migrationBuilder.DropTable(
                name: "DMallShopItem");
        }
    }
}
