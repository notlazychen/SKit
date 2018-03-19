using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class cgou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerItem_Players_PlayerId",
                table: "PlayerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PVPFormation_Players_PlayerId",
                table: "PVPFormation");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Players_PlayerId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Players_PlayerId",
                table: "Unit");

            migrationBuilder.DropTable(
                name: "PlayerCurrency");

            migrationBuilder.DropTable(
                name: "PlayerDungeon");

            migrationBuilder.DropTable(
                name: "PlayerSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PVPFormation",
                table: "PVPFormation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "PVPFormation",
                newName: "Formations");

            migrationBuilder.RenameTable(
                name: "PlayerItem",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_PlayerId",
                table: "Units",
                newName: "IX_Units_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_PlayerId",
                table: "Teams",
                newName: "IX_Teams_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PVPFormation_PlayerId",
                table: "Formations",
                newName: "IX_Formations_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerItem_PlayerId",
                table: "Items",
                newName: "IX_Items_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formations",
                table: "Formations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

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

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    RecvdStarReward = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dungeon",
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
                    SectionId = table.Column<string>(nullable: true),
                    Star = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dungeon_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dungeon_PlayerId",
                table: "Dungeon",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeon_SectionId",
                table: "Dungeon",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeon_Tid_PlayerId",
                table: "Dungeon",
                columns: new[] { "Tid", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PlayerId",
                table: "Sections",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Players_PlayerId",
                table: "Formations",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Players_PlayerId",
                table: "Items",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Players_PlayerId",
                table: "Teams",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Players_PlayerId",
                table: "Units",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Players_PlayerId",
                table: "Formations");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Players_PlayerId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_PlayerId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Players_PlayerId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Dungeon");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formations",
                table: "Formations");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "PlayerItem");

            migrationBuilder.RenameTable(
                name: "Formations",
                newName: "PVPFormation");

            migrationBuilder.RenameIndex(
                name: "IX_Units_PlayerId",
                table: "Unit",
                newName: "IX_Unit_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_PlayerId",
                table: "Team",
                newName: "IX_Team_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_PlayerId",
                table: "PlayerItem",
                newName: "IX_PlayerItem_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Formations_PlayerId",
                table: "PVPFormation",
                newName: "IX_PVPFormation_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerItem",
                table: "PlayerItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PVPFormation",
                table: "PVPFormation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlayerCurrency",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCurrency", x => new { x.PlayerId, x.Type });
                    table.ForeignKey(
                        name: "FK_PlayerCurrency_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSection",
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
                    table.PrimaryKey("PK_PlayerSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSection_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_PlayerDungeon_PlayerSection_PlayerSectionId",
                        column: x => x.PlayerSectionId,
                        principalTable: "PlayerSection",
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

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSection_PlayerId",
                table: "PlayerSection",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerItem_Players_PlayerId",
                table: "PlayerItem",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PVPFormation_Players_PlayerId",
                table: "PVPFormation",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Players_PlayerId",
                table: "Team",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Players_PlayerId",
                table: "Unit",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
