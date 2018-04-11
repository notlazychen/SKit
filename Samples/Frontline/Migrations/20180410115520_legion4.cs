using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class legion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegionSciences",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionSciences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegionSciences_LegionMembers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "LegionMembers",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegionSciences_PlayerId",
                table: "LegionSciences",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegionSciences");
        }
    }
}
