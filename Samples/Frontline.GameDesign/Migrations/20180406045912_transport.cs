using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class transport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DTransports",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    diff = table.Column<int>(nullable: false),
                    gold = table.Column<int>(nullable: false),
                    robbers1 = table.Column<JsonObject<Int32[]>>(nullable: true),
                    robbers2 = table.Column<JsonObject<Int32[]>>(nullable: true),
                    robbers3 = table.Column<JsonObject<Int32[]>>(nullable: true),
                    truck_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTransports", x => x.tid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTransports");
        }
    }
}
