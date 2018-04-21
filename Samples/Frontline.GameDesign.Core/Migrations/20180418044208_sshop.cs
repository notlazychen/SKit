using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class sshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DSecretShop",
                columns: table => new
                {
                    vip = table.Column<int>(nullable: false),
                    group = table.Column<int>(nullable: false),
                    second = table.Column<int>(nullable: false),
                    w = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSecretShop", x => new { x.vip, x.group });
                });

            migrationBuilder.CreateTable(
                name: "DSecretShopItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cur_price = table.Column<int>(nullable: false),
                    group = table.Column<int>(nullable: false),
                    item_cnt = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    limit_cnt = table.Column<int>(nullable: false),
                    old_price = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    vip = table.Column<int>(nullable: false),
                    w = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSecretShopItem", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DSecretShop");

            migrationBuilder.DropTable(
                name: "DSecretShopItem");
        }
    }
}
