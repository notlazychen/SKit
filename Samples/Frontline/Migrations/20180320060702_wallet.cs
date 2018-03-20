using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class wallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    DIAMOND = table.Column<int>(nullable: false),
                    GOLD = table.Column<int>(nullable: false),
                    HORN = table.Column<int>(nullable: false),
                    IRON = table.Column<int>(nullable: false),
                    LEGIONCOIN = table.Column<int>(nullable: false),
                    OIL = table.Column<int>(nullable: false),
                    SMOKE = table.Column<int>(nullable: false),
                    SUPPLY = table.Column<int>(nullable: false),
                    TEC = table.Column<int>(nullable: false),
                    TOKEN = table.Column<int>(nullable: false),
                    WIPES = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Wallets_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => new { x.PlayerId, x.Type });
                    table.ForeignKey(
                        name: "FK_Currencies_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
