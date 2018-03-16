using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class itemid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItem_Players_PlayerId",
                table: "PlayerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "PlayerItem",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PlayerItem",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItem_PlayerId",
                table: "PlayerItem",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItem_Players_PlayerId",
                table: "PlayerItem",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItem_Players_PlayerId",
                table: "PlayerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem");

            migrationBuilder.DropIndex(
                name: "IX_PlayerItem_PlayerId",
                table: "PlayerItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayerItem");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "PlayerItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem",
                columns: new[] { "PlayerId", "Tid" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItem_Players_PlayerId",
                table: "PlayerItem",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
