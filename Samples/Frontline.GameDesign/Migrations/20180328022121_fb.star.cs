using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class fbstar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDungeonStars",
                columns: table => new
                {
                    type = table.Column<int>(nullable: false),
                    section = table.Column<int>(nullable: false),
                    index = table.Column<int>(nullable: false),
                    res_count = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    star = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDungeonStars", x => new { x.type, x.section, x.index });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDungeonStars");
        }
    }
}
