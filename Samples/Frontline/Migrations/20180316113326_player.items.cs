using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class playeritems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerDungeon_Sections_PlayerSectionId",
                table: "PlayerDungeon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "PlayerSection");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "PlayerSection",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerSection",
                table: "PlayerSection",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlayerItem",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItem", x => new { x.PlayerId, x.Tid });
                    table.ForeignKey(
                        name: "FK_PlayerItem_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSection_PlayerId",
                table: "PlayerSection",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerDungeon_PlayerSection_PlayerSectionId",
                table: "PlayerDungeon",
                column: "PlayerSectionId",
                principalTable: "PlayerSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSection_Players_PlayerId",
                table: "PlayerSection",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerDungeon_PlayerSection_PlayerSectionId",
                table: "PlayerDungeon");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSection_Players_PlayerId",
                table: "PlayerSection");

            migrationBuilder.DropTable(
                name: "PlayerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerSection",
                table: "PlayerSection");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSection_PlayerId",
                table: "PlayerSection");

            migrationBuilder.RenameTable(
                name: "PlayerSection",
                newName: "Sections");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerDungeon_Sections_PlayerSectionId",
                table: "PlayerDungeon",
                column: "PlayerSectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
