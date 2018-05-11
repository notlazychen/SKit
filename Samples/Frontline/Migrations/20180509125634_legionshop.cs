using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class legionshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegionShops",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    SoldItems = table.Column<string>(maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionShops", x => x.PlayerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegionShops_PlayerId",
                table: "LegionShops",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegionShops");
        }
    }
}
