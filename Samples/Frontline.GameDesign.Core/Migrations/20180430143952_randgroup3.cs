using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class randgroup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DSecretShopProb");

            migrationBuilder.RenameColumn(
                name: "w",
                table: "DSecretShop",
                newName: "prob");

            migrationBuilder.RenameColumn(
                name: "group",
                table: "DSecretShop",
                newName: "shop_id");

            migrationBuilder.RenameColumn(
                name: "vip",
                table: "DSecretShop",
                newName: "mission_type");

            migrationBuilder.RenameColumn(
                name: "res_type",
                table: "DMallShopItem",
                newName: "item_cnt");

            migrationBuilder.RenameColumn(
                name: "res_cnt",
                table: "DMallShopItem",
                newName: "cost_res_type");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "DMallShopItem",
                newName: "cost_res_cnt");

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "trigger_lv",
                table: "DSecretShop",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "commodity_stock",
                table: "DMallShopItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trigger_lv",
                table: "DSecretShop");

            migrationBuilder.DropColumn(
                name: "commodity_stock",
                table: "DMallShopItem");

            migrationBuilder.RenameColumn(
                name: "prob",
                table: "DSecretShop",
                newName: "w");

            migrationBuilder.RenameColumn(
                name: "shop_id",
                table: "DSecretShop",
                newName: "group");

            migrationBuilder.RenameColumn(
                name: "mission_type",
                table: "DSecretShop",
                newName: "vip");

            migrationBuilder.RenameColumn(
                name: "item_cnt",
                table: "DMallShopItem",
                newName: "res_type");

            migrationBuilder.RenameColumn(
                name: "cost_res_type",
                table: "DMallShopItem",
                newName: "res_cnt");

            migrationBuilder.RenameColumn(
                name: "cost_res_cnt",
                table: "DMallShopItem",
                newName: "count");

            migrationBuilder.CreateTable(
                name: "DSecretShopProb",
                columns: table => new
                {
                    mission_type = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    desc = table.Column<string>(maxLength: 32, nullable: true),
                    prob = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSecretShopProb", x => x.mission_type);
                });
        }
    }
}
