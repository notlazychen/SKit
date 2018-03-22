using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class equipitem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desc",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "grade_grow",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "grade_item_cnt",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "grade_item_id",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "icon",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "max_level",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "name",
                table: "DEquips");

            migrationBuilder.DropColumn(
                name: "next_id",
                table: "DEquips");

            migrationBuilder.RenameColumn(
                name: "player_lv",
                table: "DEquips",
                newName: "gradeid");

            migrationBuilder.CreateTable(
                name: "DEquipGrades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    grade = table.Column<int>(nullable: false),
                    grade_grow = table.Column<int>(nullable: false),
                    grade_item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    grade_item_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    max_level = table.Column<int>(nullable: false),
                    next_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEquipGrades", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEquipGrades");

            migrationBuilder.RenameColumn(
                name: "gradeid",
                table: "DEquips",
                newName: "player_lv");

            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "DEquips",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "grade",
                table: "DEquips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "grade_grow",
                table: "DEquips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "grade_item_cnt",
                table: "DEquips",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "grade_item_id",
                table: "DEquips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "DEquips",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "max_level",
                table: "DEquips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "DEquips",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "next_id",
                table: "DEquips",
                nullable: false,
                defaultValue: 0);
        }
    }
}
