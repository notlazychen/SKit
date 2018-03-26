using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class lottery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastDayRefreshTime",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OnlineTime",
                table: "Players",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    RecvTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_FriendList_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lottery",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Dmd10UsedNumb = table.Column<int>(nullable: false),
                    DmdBaseNumb = table.Column<int>(nullable: false),
                    DmdFreeNextTime = table.Column<DateTime>(nullable: false),
                    DmdFreeNumb = table.Column<int>(nullable: false),
                    DmdLastTime = table.Column<DateTime>(nullable: false),
                    DmdUsedNumb = table.Column<int>(nullable: false),
                    Gold10UsedNumb = table.Column<int>(nullable: false),
                    GoldBaseNumb = table.Column<int>(nullable: false),
                    GoldFreeNextTime = table.Column<DateTime>(nullable: false),
                    GoldFreeNumb = table.Column<int>(nullable: false),
                    GoldLastTime = table.Column<DateTime>(nullable: false),
                    GoldUsedNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottery", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Lottery_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendApplication",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    FriendListId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendApplication_FriendList_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendList",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friendship",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FriendListId = table.Column<string>(nullable: true),
                    FromTime = table.Column<DateTime>(nullable: false),
                    IsRecvOil = table.Column<bool>(nullable: false),
                    IsSendOil = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendship_FriendList_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendList",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendApplication_FriendListId",
                table: "FriendApplication",
                column: "FriendListId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendship_FriendListId",
                table: "Friendship",
                column: "FriendListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendApplication");

            migrationBuilder.DropTable(
                name: "Friendship");

            migrationBuilder.DropTable(
                name: "Lottery");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropColumn(
                name: "LastDayRefreshTime",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "OnlineTime",
                table: "Players");
        }
    }
}
