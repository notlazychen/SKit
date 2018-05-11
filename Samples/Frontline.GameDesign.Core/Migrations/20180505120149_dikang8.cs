using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dikang8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "DMonsterInDungeon",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon",
                columns: new[] { "dungeon_id", "mid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "DMonsterInDungeon",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMonsterInDungeon",
                table: "DMonsterInDungeon",
                column: "Id");
        }
    }
}
