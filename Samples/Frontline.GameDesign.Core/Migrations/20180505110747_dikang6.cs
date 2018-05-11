using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dikang6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "monsters",
                table: "DDiKangQianXian");

            migrationBuilder.AddColumn<int>(
                name: "dungeon_id",
                table: "DDiKangQianXian",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dungeon_id",
                table: "DDiKangQianXian");

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "monsters",
                table: "DDiKangQianXian",
                nullable: true);
        }
    }
}
