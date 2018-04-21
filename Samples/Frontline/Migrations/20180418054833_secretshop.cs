using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class secretshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecretShops",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    CloseTime = table.Column<DateTime>(nullable: false),
                    OpenTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretShops", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "SecretShopItem",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    SoldCount = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretShopItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretShopItem_SecretShops_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "SecretShops",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecretShopItem_PlayerId",
                table: "SecretShopItem",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecretShopItem");

            migrationBuilder.DropTable(
                name: "SecretShops");
        }
    }
}
