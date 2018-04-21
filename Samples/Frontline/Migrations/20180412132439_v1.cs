using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiKangs",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Best = table.Column<int>(nullable: false),
                    Current = table.Column<int>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    RecvBox = table.Column<string>(nullable: true),
                    ResetNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiKangs", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    HireWorkerNumb = table.Column<int>(nullable: false),
                    LastRefreshDay = table.Column<DateTime>(nullable: false),
                    TodayMarketRefreshTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "FriendLists",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    RecvTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLists", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Legions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Creater = table.Column<string>(nullable: true),
                    EnrollTime = table.Column<DateTime>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    Glory = table.Column<int>(nullable: false),
                    GvgClientPort = table.Column<int>(nullable: false),
                    GvgLAN = table.Column<string>(nullable: true),
                    GvgMap = table.Column<int>(nullable: false),
                    GvgMaxRank = table.Column<int>(nullable: false),
                    GvgPort = table.Column<int>(nullable: false),
                    GvgRank = table.Column<int>(nullable: false),
                    GvgState = table.Column<int>(nullable: false),
                    GvgWAN = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    LeaderId = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    MaxGlory = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NeedCheck = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotteries",
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
                    GoldUsedNumb = table.Column<int>(nullable: false),
                    LastRefreshDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotteries", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Args = table.Column<JsonObject<List<string>>>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IsCollected = table.Column<bool>(nullable: false),
                    IsLegionMail = table.Column<bool>(nullable: false),
                    IsReaded = table.Column<bool>(nullable: false),
                    IsRecved = table.Column<bool>(nullable: false),
                    LegionName = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malls",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malls", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerQuestDatas",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    DailyPoint = table.Column<int>(nullable: false),
                    DailyPointReward = table.Column<string>(nullable: true),
                    LastRefreshDay = table.Column<DateTime>(nullable: false),
                    RecvedDailyPointReward = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuestDatas", x => x.PlayerId);
                });

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
                    Icon = table.Column<string>(maxLength: 32, nullable: true),
                    IsBind = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(maxLength: 32, nullable: true),
                    LastDayRefreshTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    LastLvUpTime = table.Column<DateTime>(nullable: false),
                    LastVipUpTime = table.Column<DateTime>(nullable: false),
                    LegionId = table.Column<string>(maxLength: 64, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    MaxPower = table.Column<int>(nullable: false),
                    NickName = table.Column<string>(maxLength: 32, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Rescues",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    LastTodayDiff = table.Column<int>(nullable: false),
                    UseNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rescues", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    LastTodayDiff = table.Column<int>(nullable: false),
                    UseNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "WeekBattleData",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    DaysInWeek = table.Column<int>(nullable: false),
                    LastRefreshDay = table.Column<DateTime>(nullable: false),
                    LastRefreshWeek = table.Column<DateTime>(nullable: false),
                    RecvBoxes = table.Column<string>(maxLength: 1024, nullable: true),
                    Score = table.Column<int>(nullable: false),
                    UseNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekBattleData", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "FacTasks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    FacWorkers = table.Column<string>(maxLength: 512, nullable: true),
                    IsWorkersReleased = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacTasks_Factories_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Factories",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacWorkers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FacTaskId = table.Column<string>(nullable: true),
                    InMarket = table.Column<bool>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacWorkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacWorkers_Factories_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Factories",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_FriendApplications_FriendLists_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendLists",
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
                        name: "FK_Friendships_FriendLists_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendLists",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegionApplications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LegionId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    RequestTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegionApplications_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LegionBBS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    LegionId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionBBS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegionBBS_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LegionMembers",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Career = table.Column<int>(nullable: false),
                    Contribution = table.Column<long>(nullable: false),
                    IsTodayDonated = table.Column<bool>(nullable: false),
                    LastContriTime = table.Column<DateTime>(nullable: false),
                    LastLeftTime = table.Column<DateTime>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    LegionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionMembers", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_LegionMembers_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MailAttachment",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MailId = table.Column<string>(nullable: true),
                    Tid = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailAttachment_Mails_MailId",
                        column: x => x.MailId,
                        principalTable: "Mails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MallShops",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MallShops", x => new { x.PlayerId, x.Type });
                    table.ForeignKey(
                        name: "FK_MallShops_Malls_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Malls",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestDailys",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestDailys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestDailys_PlayerQuestDatas_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerQuestDatas",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_PlayerQuestDatas_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "PlayerQuestDatas",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
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
                    ReceivedRewards = table.Column<string>(maxLength: 64, nullable: true),
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
                    RecvdStarReward = table.Column<string>(maxLength: 64, nullable: false),
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
                    Level = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
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
                    TodayBuyGold = table.Column<int>(nullable: false),
                    TodayBuyIron = table.Column<int>(nullable: false),
                    TodayBuyOil = table.Column<int>(nullable: false),
                    TodayBuySupply = table.Column<int>(nullable: false),
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
                name: "LegionSciences",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Tid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionSciences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegionSciences_LegionMembers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "LegionMembers",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MallShopCommodities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CommodityId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    SoldCount = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MallShopCommodities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MallShopCommodities_MallShops_PlayerId_Type",
                        columns: x => new { x.PlayerId, x.Type },
                        principalTable: "MallShops",
                        principalColumns: new[] { "PlayerId", "Type" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArenaBattleHistories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AdversaryName = table.Column<string>(nullable: true),
                    AdversaryPid = table.Column<string>(nullable: true),
                    ArenaCertId = table.Column<string>(nullable: true),
                    BattleResult = table.Column<int>(nullable: false),
                    BattleTime = table.Column<long>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    RankChange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaBattleHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArenaBattleHistories_ArenaCerts_ArenaCertId",
                        column: x => x.ArenaCertId,
                        principalTable: "ArenaCerts",
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
                name: "IX_ArenaBattleHistories_ArenaCertId",
                table: "ArenaBattleHistories",
                column: "ArenaCertId");

            migrationBuilder.CreateIndex(
                name: "IX_ArenaBattleHistories_PlayerId",
                table: "ArenaBattleHistories",
                column: "PlayerId");

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
                name: "IX_FacTasks_PlayerId",
                table: "FacTasks",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_PlayerId",
                table: "Factories",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacWorkers_PlayerId",
                table: "FacWorkers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_PlayerId",
                table: "Formations",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_PlayerId",
                table: "FriendLists",
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
                name: "IX_LegionApplications_LegionId",
                table: "LegionApplications",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LegionBBS_LegionId",
                table: "LegionBBS",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LegionMembers_LegionId",
                table: "LegionMembers",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Legions_Level",
                table: "Legions",
                column: "Level");

            migrationBuilder.CreateIndex(
                name: "IX_Legions_Name",
                table: "Legions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Legions_ShortName",
                table: "Legions",
                column: "ShortName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegionSciences_PlayerId",
                table: "LegionSciences",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MailAttachment_MailId",
                table: "MailAttachment",
                column: "MailId");

            migrationBuilder.CreateIndex(
                name: "IX_Mails_PlayerId",
                table: "Mails",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MallShopCommodities_PlayerId_Type",
                table: "MallShopCommodities",
                columns: new[] { "PlayerId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_MallShops_PlayerId",
                table: "MallShops",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_NickName",
                table: "Players",
                column: "NickName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserCenterId",
                table: "Players",
                column: "UserCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserCode",
                table: "Players",
                column: "UserCode");

            migrationBuilder.CreateIndex(
                name: "IX_QuestDailys_PlayerId",
                table: "QuestDailys",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_PlayerId",
                table: "Quests",
                column: "PlayerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WeekBattleData_PlayerId",
                table: "WeekBattleData",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekBattleData_Score",
                table: "WeekBattleData",
                column: "Score");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaBattleHistories");

            migrationBuilder.DropTable(
                name: "DiKangs");

            migrationBuilder.DropTable(
                name: "Dungeon");

            migrationBuilder.DropTable(
                name: "Equip");

            migrationBuilder.DropTable(
                name: "FacTasks");

            migrationBuilder.DropTable(
                name: "FacWorkers");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "FriendApplications");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "LegionApplications");

            migrationBuilder.DropTable(
                name: "LegionBBS");

            migrationBuilder.DropTable(
                name: "LegionSciences");

            migrationBuilder.DropTable(
                name: "Lotteries");

            migrationBuilder.DropTable(
                name: "MailAttachment");

            migrationBuilder.DropTable(
                name: "MallShopCommodities");

            migrationBuilder.DropTable(
                name: "PlayerOlReward");

            migrationBuilder.DropTable(
                name: "QuestDailys");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Rescues");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "WeekBattleData");

            migrationBuilder.DropTable(
                name: "ArenaCerts");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "FriendLists");

            migrationBuilder.DropTable(
                name: "LegionMembers");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropTable(
                name: "MallShops");

            migrationBuilder.DropTable(
                name: "PlayerQuestDatas");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Legions");

            migrationBuilder.DropTable(
                name: "Malls");
        }
    }
}
