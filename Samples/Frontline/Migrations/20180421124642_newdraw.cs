using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class newdraw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raffles",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    BaseNumb = table.Column<int>(nullable: false),
                    FreeNextTime = table.Column<DateTime>(nullable: false),
                    FreeNumb = table.Column<int>(nullable: false),
                    LastTime = table.Column<DateTime>(nullable: false),
                    UsedNumb = table.Column<int>(nullable: false),
                    UsedNumb10 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raffles", x => new { x.PlayerId, x.Type });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raffles_PlayerId",
                table: "Raffles",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raffles");
        }
    }
}
