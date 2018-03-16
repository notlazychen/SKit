using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class playergungeon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "Players",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Players",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Players",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Players",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Players",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                table: "Players",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    RecvdStarReward = table.Column<int>(nullable: false),
                    Section = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDungeon",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FightTimes = table.Column<int>(nullable: false),
                    IsLast = table.Column<bool>(nullable: false),
                    IsOpen = table.Column<bool>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    Mission = table.Column<int>(nullable: false),
                    Next = table.Column<int>(maxLength: 32, nullable: false),
                    PlayerId = table.Column<string>(maxLength: 20, nullable: true),
                    PlayerSectionId = table.Column<string>(nullable: true),
                    ResetNumb = table.Column<int>(nullable: false),
                    Section = table.Column<int>(nullable: false),
                    Star = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDungeon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerDungeon_Sections_PlayerSectionId",
                        column: x => x.PlayerSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDungeon_PlayerId",
                table: "PlayerDungeon",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDungeon_PlayerSectionId",
                table: "PlayerDungeon",
                column: "PlayerSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDungeon_Tid_PlayerId",
                table: "PlayerDungeon",
                columns: new[] { "Tid", "PlayerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDungeon");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);
        }
    }
}
