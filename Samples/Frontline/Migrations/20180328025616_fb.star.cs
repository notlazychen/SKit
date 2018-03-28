using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class fbstar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArenaBattleHistories_ArenaCerts_PlayerId",
                table: "ArenaBattleHistories");

            migrationBuilder.AlterColumn<string>(
                name: "RecvdStarReward",
                table: "Sections",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ArenaCertId",
                table: "ArenaBattleHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArenaBattleHistories_ArenaCertId",
                table: "ArenaBattleHistories",
                column: "ArenaCertId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArenaBattleHistories_ArenaCerts_ArenaCertId",
                table: "ArenaBattleHistories",
                column: "ArenaCertId",
                principalTable: "ArenaCerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArenaBattleHistories_ArenaCerts_ArenaCertId",
                table: "ArenaBattleHistories");

            migrationBuilder.DropIndex(
                name: "IX_ArenaBattleHistories_ArenaCertId",
                table: "ArenaBattleHistories");

            migrationBuilder.DropColumn(
                name: "ArenaCertId",
                table: "ArenaBattleHistories");

            migrationBuilder.AlterColumn<int>(
                name: "RecvdStarReward",
                table: "Sections",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddForeignKey(
                name: "FK_ArenaBattleHistories_ArenaCerts_PlayerId",
                table: "ArenaBattleHistories",
                column: "PlayerId",
                principalTable: "ArenaCerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
