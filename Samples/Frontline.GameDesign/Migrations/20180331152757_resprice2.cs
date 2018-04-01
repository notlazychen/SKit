using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class resprice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "buy_oil_cost_diamond",
                table: "DResPrices",
                newName: "supply_cost");

            migrationBuilder.RenameColumn(
                name: "buy_gold_cost_diamond",
                table: "DResPrices",
                newName: "supply");

            migrationBuilder.AddColumn<int>(
                name: "gold",
                table: "DResPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "gold_cost",
                table: "DResPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iron",
                table: "DResPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iron_cost",
                table: "DResPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "oil",
                table: "DResPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "oil_cost",
                table: "DResPrices",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gold",
                table: "DResPrices");

            migrationBuilder.DropColumn(
                name: "gold_cost",
                table: "DResPrices");

            migrationBuilder.DropColumn(
                name: "iron",
                table: "DResPrices");

            migrationBuilder.DropColumn(
                name: "iron_cost",
                table: "DResPrices");

            migrationBuilder.DropColumn(
                name: "oil",
                table: "DResPrices");

            migrationBuilder.DropColumn(
                name: "oil_cost",
                table: "DResPrices");

            migrationBuilder.RenameColumn(
                name: "supply_cost",
                table: "DResPrices",
                newName: "buy_oil_cost_diamond");

            migrationBuilder.RenameColumn(
                name: "supply",
                table: "DResPrices",
                newName: "buy_gold_cost_diamond");
        }
    }
}
