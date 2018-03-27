using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BuySkillNumb = table.Column<int>(nullable: false),
                    Camp = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Guide = table.Column<float>(nullable: false),
                    IP = table.Column<string>(maxLength: 32, nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IsBind = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(maxLength: 32, nullable: true),
                    LastDayRefreshTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    LastLvUpTime = table.Column<DateTime>(nullable: false),
                    LastVipUpTime = table.Column<DateTime>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    MaxPower = table.Column<int>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    OldPlayer = table.Column<bool>(nullable: false),
                    OnlineTime = table.Column<TimeSpan>(nullable: false),
                    RenameNumb = table.Column<int>(nullable: false),
                    ScienceNumb = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    StateTime = table.Column<long>(nullable: false),
                    UserCenterId = table.Column<long>(nullable: false),
                    UserCode = table.Column<string>(maxLength: 20, nullable: true),
                    VIP = table.Column<int>(nullable: false),
                    VIPExp = table.Column<int>(nullable: false),
                    Version = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.UniqueConstraint("AK_Players_NickName", x => x.NickName);
                });

            migrationBuilder.CreateTable(
                name: "ArenaCerts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BoughtChallengeTimes = table.Column<int>(nullable: false),
                    CD = table.Column<DateTime>(nullable: false),
                    ChallengeTimes = table.Column<int>(nullable: false),
                    CurrentRank = table.Column<int>(nullable: false),
                    IsRobot = table.Column<bool>(nullable: false),
                    MaxRank = table.Column<int>(nullable: false),
                    NextRecvRank = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: false),
                    ReceivedRewards = table.Column<JsonObject<List<int>>>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    TotalBattleNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaCerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArenaCerts_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    IsSelected = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Units = table.Column<JsonObject<List<string>>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
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
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "PlayerOlReward",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    NextTime = table.Column<DateTime>(nullable: false),
                    RewardIndex = table.Column<int>(nullable: false),
                    Round = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerOlReward", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_PlayerOlReward_Players_PlayerId",
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
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    IsSelected = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Units = table.Column<JsonObject<List<string>>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    IsResting = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    RestEndTime = table.Column<DateTime>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "FriendApplications",
                columns: table => new
                {
                    FriendListId = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(maxLength: 64, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendApplications", x => new { x.FriendListId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_FriendApplications_FriendList_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendList",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    FriendListId = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(maxLength: 64, nullable: false),
                    CanRecvOil = table.Column<bool>(nullable: false),
                    CanSendOil = table.Column<bool>(nullable: false),
                    FromTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.FriendListId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_Friendships_FriendList_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendList",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Equip",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Pos = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    UnitId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equip_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArenaCerts_CurrentRank",
                table: "ArenaCerts",
                column: "CurrentRank");

            migrationBuilder.CreateIndex(
                name: "IX_ArenaCerts_PlayerId",
                table: "ArenaCerts",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dungeon_SectionId",
                table: "Dungeon",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeon_Tid_PlayerId",
                table: "Dungeon",
                columns: new[] { "Tid", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Equip_UnitId",
                table: "Equip",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_PlayerId",
                table: "Formations",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendListId",
                table: "Friendships",
                column: "FriendListId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerId",
                table: "Items",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserCenterId",
                table: "Players",
                column: "UserCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserCode",
                table: "Players",
                column: "UserCode");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PlayerId",
                table: "Sections",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerId",
                table: "Teams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_PlayerId",
                table: "Units",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaCerts");

            migrationBuilder.DropTable(
                name: "Dungeon");

            migrationBuilder.DropTable(
                name: "Equip");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "FriendApplications");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Lottery");

            migrationBuilder.DropTable(
                name: "PlayerOlReward");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
