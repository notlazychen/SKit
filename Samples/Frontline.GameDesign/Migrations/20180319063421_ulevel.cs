using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class ulevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DUnitGradeUps",
                columns: table => new
                {
                    star = table.Column<int>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    atk = table.Column<int>(nullable: false),
                    defence = table.Column<int>(nullable: false),
                    gold = table.Column<int>(nullable: false),
                    hp = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    max_level = table.Column<int>(nullable: false),
                    min_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnitGradeUps", x => new { x.star, x.grade });
                });

            migrationBuilder.CreateTable(
                name: "DUnitLevelUps",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    star1 = table.Column<int>(nullable: false),
                    star2 = table.Column<int>(nullable: false),
                    star3 = table.Column<int>(nullable: false),
                    star4 = table.Column<int>(nullable: false),
                    star5 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnitLevelUps", x => x.level);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DUnitGradeUps");

            migrationBuilder.DropTable(
                name: "DUnitLevelUps");
        }
    }
}
