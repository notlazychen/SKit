using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class dikang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDiKangQianXianBoxs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    box = table.Column<int>(nullable: false),
                    wid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDiKangQianXianBoxs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DDiKangQianXianBuildings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    defence = table.Column<int>(nullable: false),
                    hp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDiKangQianXianBuildings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DDiKangQianXians",
                columns: table => new
                {
                    wid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    command = table.Column<int>(nullable: false),
                    monsters = table.Column<JsonObject<Int32[]>>(nullable: true),
                    token = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDiKangQianXians", x => x.wid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDiKangQianXianBoxs");

            migrationBuilder.DropTable(
                name: "DDiKangQianXianBuildings");

            migrationBuilder.DropTable(
                name: "DDiKangQianXians");
        }
    }
}
