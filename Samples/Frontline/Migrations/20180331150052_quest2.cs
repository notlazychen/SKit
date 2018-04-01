using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class quest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tid",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "QuestDailys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "QuestDailys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tid",
                table: "QuestDailys",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Tid",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "QuestDailys");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "QuestDailys");

            migrationBuilder.DropColumn(
                name: "Tid",
                table: "QuestDailys");
        }
    }
}
