using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class equip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "DUnitGradeUps",
                newName: "item_cnt");

            migrationBuilder.CreateTable(
                name: "DEquipLevelCosts",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    soldier_gold = table.Column<int>(nullable: false),
                    tank_gold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEquipLevelCosts", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DEquips",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    base_attr_type = table.Column<int>(nullable: false),
                    base_attr_value = table.Column<int>(nullable: false),
                    desc = table.Column<string>(maxLength: 64, nullable: true),
                    grade = table.Column<int>(nullable: false),
                    grade_grow = table.Column<int>(nullable: false),
                    grade_item_cnt = table.Column<int>(nullable: false),
                    grade_item_id = table.Column<int>(nullable: false),
                    icon = table.Column<string>(maxLength: 64, nullable: true),
                    level_grow = table.Column<int>(nullable: false),
                    level_k = table.Column<int>(nullable: false),
                    max_level = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    next_id = table.Column<int>(nullable: false),
                    player_lv = table.Column<int>(nullable: false),
                    pos = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEquips", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEquipLevelCosts");

            migrationBuilder.DropTable(
                name: "DEquips");

            migrationBuilder.RenameColumn(
                name: "item_cnt",
                table: "DUnitGradeUps",
                newName: "item_id");
        }
    }
}
