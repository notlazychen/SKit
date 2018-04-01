using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class buyres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OilBuyTimes",
                table: "Wallets",
                newName: "TodayBuySupply");

            migrationBuilder.RenameColumn(
                name: "GoldBuyTimes",
                table: "Wallets",
                newName: "TodayBuyOil");

            migrationBuilder.AddColumn<int>(
                name: "TodayBuyGold",
                table: "Wallets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TodayBuyIron",
                table: "Wallets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TodayBuyGold",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "TodayBuyIron",
                table: "Wallets");

            migrationBuilder.RenameColumn(
                name: "TodayBuySupply",
                table: "Wallets",
                newName: "OilBuyTimes");

            migrationBuilder.RenameColumn(
                name: "TodayBuyOil",
                table: "Wallets",
                newName: "GoldBuyTimes");
        }
    }
}
