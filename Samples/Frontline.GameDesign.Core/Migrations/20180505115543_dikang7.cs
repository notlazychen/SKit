using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dikang7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "DMonsterInDungeon",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DMonsterInDungeon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon",
                columns: new[] { "dungeon_id", "mid" });
        }
    }
}
