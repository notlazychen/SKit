using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class fb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dungeon_PlayerId",
                table: "Dungeon");

            migrationBuilder.DropColumn(
                name: "PlayerSectionId",
                table: "Dungeon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerSectionId",
                table: "Dungeon",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dungeon_PlayerId",
                table: "Dungeon",
                column: "PlayerId");
        }
    }
}
