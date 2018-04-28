using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dailyquest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "res_oil",
                table: "DQuestDaily",
                newName: "reward_type");

            migrationBuilder.AddColumn<int>(
                name: "reward_ID",
                table: "DQuestDaily",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "reward_num",
                table: "DQuestDaily",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reward_ID",
                table: "DQuestDaily");

            migrationBuilder.DropColumn(
                name: "reward_num",
                table: "DQuestDaily");

            migrationBuilder.RenameColumn(
                name: "reward_type",
                table: "DQuestDaily",
                newName: "res_oil");
        }
    }
}
