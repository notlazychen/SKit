using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dshopx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "size",
                table: "DMallShop");

            migrationBuilder.RenameColumn(
                name: "rate",
                table: "DMallShopItem",
                newName: "order");

            migrationBuilder.AddColumn<int>(
                name: "level_max",
                table: "DMallShopItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "level_min",
                table: "DMallShopItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level_max",
                table: "DMallShopItem");

            migrationBuilder.DropColumn(
                name: "level_min",
                table: "DMallShopItem");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "DMallShopItem",
                newName: "rate");

            migrationBuilder.AddColumn<int>(
                name: "size",
                table: "DMallShop",
                nullable: false,
                defaultValue: 0);
        }
    }
}
