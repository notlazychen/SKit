using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DItems",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bag_type = table.Column<int>(nullable: false),
                    breakCount = table.Column<int>(nullable: false),
                    breakRandomId = table.Column<int>(nullable: false),
                    breakUnitId = table.Column<int>(nullable: false),
                    cd = table.Column<TimeSpan>(nullable: true),
                    diamond = table.Column<int>(nullable: false),
                    icon = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    overlap = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    quality = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    useable = table.Column<bool>(nullable: false),
                    worth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DItems", x => x.tid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DItems");
        }
    }
}
