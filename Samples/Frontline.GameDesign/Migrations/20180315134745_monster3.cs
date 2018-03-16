using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class monster3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMonsterInDungeons",
                table: "DMonsterInDungeons");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DMonsterInDungeons");

            migrationBuilder.AddColumn<int>(
                name: "dungeon_id",
                table: "DMonsterInDungeons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMonsterInDungeons",
                table: "DMonsterInDungeons",
                columns: new[] { "dungeon_id", "mid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DMonsterInDungeons",
                table: "DMonsterInDungeons");

            migrationBuilder.DropColumn(
                name: "dungeon_id",
                table: "DMonsterInDungeons");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "DMonsterInDungeons",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DMonsterInDungeons",
                table: "DMonsterInDungeons",
                column: "id");
        }
    }
}
