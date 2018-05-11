using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class viped2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LegionId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "VIPCard",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BuyTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    VIPLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VIPCard_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VIPCard_PlayerId",
                table: "VIPCard",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIPCard");

            migrationBuilder.AddColumn<string>(
                name: "LegionId",
                table: "Players",
                maxLength: 64,
                nullable: true);
        }
    }
}
