﻿// <auto-generated />
using Frontline.Data;
using Frontline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180406050202_tran")]
    partial class tran
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Frontline.Domain.ArenaBattleHistory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdversaryName");

                    b.Property<string>("AdversaryPid");

                    b.Property<string>("ArenaCertId");

                    b.Property<int>("BattleResult");

                    b.Property<long>("BattleTime");

                    b.Property<string>("Icon");

                    b.Property<string>("PlayerId");

                    b.Property<int>("Power");

                    b.Property<int>("RankChange");

                    b.HasKey("Id");

                    b.HasIndex("ArenaCertId");

                    b.HasIndex("PlayerId");

                    b.ToTable("ArenaBattleHistories");
                });

            modelBuilder.Entity("Frontline.Domain.ArenaCert", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoughtChallengeTimes");

                    b.Property<DateTime>("CD");

                    b.Property<int>("ChallengeTimes");

                    b.Property<int>("CurrentRank");

                    b.Property<bool>("IsRobot");

                    b.Property<int>("MaxRank");

                    b.Property<int>("NextRecvRank");

                    b.Property<string>("PlayerId")
                        .IsRequired();

                    b.Property<string>("ReceivedRewards")
                        .HasMaxLength(64);

                    b.Property<int>("Score");

                    b.Property<int>("TotalBattleNumb");

                    b.HasKey("Id");

                    b.HasIndex("CurrentRank");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("ArenaCerts");
                });

            modelBuilder.Entity("Frontline.Domain.DiKang", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Best");

                    b.Property<int>("Current");

                    b.Property<DateTime>("LastRefreshTime");

                    b.Property<string>("RecvBox");

                    b.Property<int>("ResetNumb");

                    b.HasKey("PlayerId");

                    b.ToTable("DiKangs");
                });

            modelBuilder.Entity("Frontline.Domain.Dungeon", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FightTimes");

                    b.Property<bool>("IsLast");

                    b.Property<bool>("IsOpen");

                    b.Property<DateTime>("LastRefreshTime");

                    b.Property<int>("Mission");

                    b.Property<int>("Next")
                        .HasMaxLength(32);

                    b.Property<string>("PlayerId")
                        .HasMaxLength(20);

                    b.Property<int>("ResetNumb");

                    b.Property<int>("Section");

                    b.Property<string>("SectionId");

                    b.Property<int>("Star");

                    b.Property<int>("Tid");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("Tid", "PlayerId");

                    b.ToTable("Dungeon");
                });

            modelBuilder.Entity("Frontline.Domain.Equip", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GradeId");

                    b.Property<int>("Level");

                    b.Property<string>("PlayerId");

                    b.Property<int>("Pos");

                    b.Property<int>("Tid");

                    b.Property<string>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Equip");
                });

            modelBuilder.Entity("Frontline.Domain.FacTask", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("FacWorkers")
                        .HasMaxLength(512);

                    b.Property<bool>("IsWorkersReleased");

                    b.Property<string>("PlayerId");

                    b.Property<int>("State");

                    b.Property<int>("Tid");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("FacTasks");
                });

            modelBuilder.Entity("Frontline.Domain.Factory", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HireWorkerNumb");

                    b.Property<DateTime>("LastRefreshDay");

                    b.Property<int>("TodayMarketRefreshTimes");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("Frontline.Domain.FacWorker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacTaskId");

                    b.Property<bool>("InMarket");

                    b.Property<string>("PlayerId");

                    b.Property<int>("State");

                    b.Property<int>("Tid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("FacWorkers");
                });

            modelBuilder.Entity("Frontline.Domain.FriendApplication", b =>
                {
                    b.Property<string>("FriendListId");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(64);

                    b.Property<DateTime>("CreateTime");

                    b.HasKey("FriendListId", "PlayerId");

                    b.ToTable("FriendApplications");
                });

            modelBuilder.Entity("Frontline.Domain.FriendList", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastRefreshTime");

                    b.Property<int>("RecvTimes");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("FriendLists");
                });

            modelBuilder.Entity("Frontline.Domain.Friendship", b =>
                {
                    b.Property<string>("FriendListId");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(64);

                    b.Property<bool>("CanRecvOil");

                    b.Property<bool>("CanSendOil");

                    b.Property<DateTime>("FromTime");

                    b.HasKey("FriendListId", "PlayerId");

                    b.HasIndex("FriendListId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("Frontline.Domain.Legion", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Creater");

                    b.Property<DateTime>("EnrollTime");

                    b.Property<int>("Exp");

                    b.Property<int>("Glory");

                    b.Property<int>("GvgClientPort");

                    b.Property<string>("GvgLAN");

                    b.Property<int>("GvgMap");

                    b.Property<int>("GvgMaxRank");

                    b.Property<int>("GvgPort");

                    b.Property<int>("GvgRank");

                    b.Property<int>("GvgState");

                    b.Property<string>("GvgWAN");

                    b.Property<string>("Icon");

                    b.Property<string>("LeaderId");

                    b.Property<int>("Level");

                    b.Property<int>("MaxGlory");

                    b.Property<string>("Name");

                    b.Property<bool>("NeedCheck");

                    b.Property<string>("Note");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("Level");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.ToTable("Legions");
                });

            modelBuilder.Entity("Frontline.Domain.LegionMember", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Career");

                    b.Property<int>("ContriTimes");

                    b.Property<long>("Contribution");

                    b.Property<DateTime>("LastContriTime");

                    b.Property<DateTime>("LastLeftTime");

                    b.Property<DateTime>("LastRefreshTime");

                    b.Property<string>("LegionId");

                    b.HasKey("PlayerId");

                    b.HasIndex("LegionId");

                    b.ToTable("LegionMembers");
                });

            modelBuilder.Entity("Frontline.Domain.Lottery", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Dmd10UsedNumb");

                    b.Property<int>("DmdBaseNumb");

                    b.Property<DateTime>("DmdFreeNextTime");

                    b.Property<int>("DmdFreeNumb");

                    b.Property<DateTime>("DmdLastTime");

                    b.Property<int>("DmdUsedNumb");

                    b.Property<int>("Gold10UsedNumb");

                    b.Property<int>("GoldBaseNumb");

                    b.Property<DateTime>("GoldFreeNextTime");

                    b.Property<int>("GoldFreeNumb");

                    b.Property<DateTime>("GoldLastTime");

                    b.Property<int>("GoldUsedNumb");

                    b.Property<DateTime>("LastRefreshDay");

                    b.HasKey("PlayerId");

                    b.ToTable("Lotteries");
                });

            modelBuilder.Entity("Frontline.Domain.Player", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuySkillNumb");

                    b.Property<int>("Camp");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("Exp");

                    b.Property<float>("Guide");

                    b.Property<string>("IP")
                        .HasMaxLength(32);

                    b.Property<string>("Icon")
                        .HasMaxLength(32);

                    b.Property<bool>("IsBind");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Language")
                        .HasMaxLength(32);

                    b.Property<DateTime>("LastDayRefreshTime");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<DateTime>("LastLvUpTime");

                    b.Property<DateTime>("LastVipUpTime");

                    b.Property<string>("LegionId")
                        .HasMaxLength(64);

                    b.Property<int>("Level");

                    b.Property<int>("MaxPower");

                    b.Property<string>("NickName")
                        .HasMaxLength(32);

                    b.Property<bool>("OldPlayer");

                    b.Property<TimeSpan>("OnlineTime");

                    b.Property<int>("RenameNumb");

                    b.Property<int>("ScienceNumb");

                    b.Property<int>("State");

                    b.Property<long>("StateTime");

                    b.Property<long>("UserCenterId");

                    b.Property<string>("UserCode")
                        .HasMaxLength(20);

                    b.Property<int>("VIP");

                    b.Property<int>("VIPExp");

                    b.Property<string>("Version")
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("NickName")
                        .IsUnique();

                    b.HasIndex("UserCenterId");

                    b.HasIndex("UserCode");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Frontline.Domain.PlayerItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("PlayerId");

                    b.Property<int>("Tid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Frontline.Domain.PlayerOlReward", b =>
                {
                    b.Property<string>("PlayerId");

                    b.Property<DateTime>("NextTime");

                    b.Property<int>("RewardIndex");

                    b.Property<int>("Round");

                    b.HasKey("PlayerId");

                    b.ToTable("PlayerOlReward");
                });

            modelBuilder.Entity("Frontline.Domain.PlayerQuestData", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DailyPoint");

                    b.Property<string>("DailyPointReward");

                    b.Property<DateTime>("LastRefreshDay");

                    b.Property<string>("RecvedDailyPointReward");

                    b.HasKey("PlayerId");

                    b.ToTable("PlayerQuestDatas");
                });

            modelBuilder.Entity("Frontline.Domain.PVPFormation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Index");

                    b.Property<bool>("IsSelected");

                    b.Property<string>("PlayerId");

                    b.Property<JsonObject<List<string>>>("Units");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Formations");
                });

            modelBuilder.Entity("Frontline.Domain.Quest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerId");

                    b.Property<int>("Progress");

                    b.Property<int>("Status");

                    b.Property<int>("Tid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("Frontline.Domain.QuestDaily", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerId");

                    b.Property<int>("Progress");

                    b.Property<int>("Status");

                    b.Property<int>("Tid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("QuestDailys");
                });

            modelBuilder.Entity("Frontline.Domain.Section", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Index");

                    b.Property<string>("PlayerId");

                    b.Property<string>("RecvdStarReward")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Frontline.Domain.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Index");

                    b.Property<bool>("IsSelected");

                    b.Property<string>("PlayerId");

                    b.Property<JsonObject<List<string>>>("Units");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Frontline.Domain.Transport", b =>
                {
                    b.Property<string>("PlayerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastRefreshTime");

                    b.Property<int>("LastTodayDiff");

                    b.Property<int>("UseNumb");

                    b.HasKey("PlayerId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("Frontline.Domain.Unit", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Exp");

                    b.Property<int>("Grade");

                    b.Property<int>("Level");

                    b.Property<string>("PlayerId");

                    b.Property<int>("Power");

                    b.Property<int>("Tid");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Frontline.Domain.Wallet", b =>
                {
                    b.Property<string>("PlayerId");

                    b.Property<int>("DIAMOND");

                    b.Property<int>("GOLD");

                    b.Property<int>("HORN");

                    b.Property<int>("IRON");

                    b.Property<int>("LEGIONCOIN");

                    b.Property<int>("OIL");

                    b.Property<int>("SMOKE");

                    b.Property<int>("SUPPLY");

                    b.Property<int>("TEC");

                    b.Property<int>("TOKEN");

                    b.Property<int>("TodayBuyGold");

                    b.Property<int>("TodayBuyIron");

                    b.Property<int>("TodayBuyOil");

                    b.Property<int>("TodayBuySupply");

                    b.Property<int>("WIPES");

                    b.HasKey("PlayerId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Frontline.Domain.ArenaBattleHistory", b =>
                {
                    b.HasOne("Frontline.Domain.ArenaCert")
                        .WithMany("ArenaBattleHistories")
                        .HasForeignKey("ArenaCertId");
                });

            modelBuilder.Entity("Frontline.Domain.ArenaCert", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithOne("ArenaCert")
                        .HasForeignKey("Frontline.Domain.ArenaCert", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Frontline.Domain.Dungeon", b =>
                {
                    b.HasOne("Frontline.Domain.Section")
                        .WithMany("Dungeons")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("Frontline.Domain.Equip", b =>
                {
                    b.HasOne("Frontline.Domain.Unit")
                        .WithMany("Equips")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("Frontline.Domain.FacTask", b =>
                {
                    b.HasOne("Frontline.Domain.Factory")
                        .WithMany("FacTasks")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.FacWorker", b =>
                {
                    b.HasOne("Frontline.Domain.Factory")
                        .WithMany("FacWorkers")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.FriendApplication", b =>
                {
                    b.HasOne("Frontline.Domain.FriendList")
                        .WithMany("FriendApplications")
                        .HasForeignKey("FriendListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Frontline.Domain.Friendship", b =>
                {
                    b.HasOne("Frontline.Domain.FriendList")
                        .WithMany("Friends")
                        .HasForeignKey("FriendListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Frontline.Domain.LegionMember", b =>
                {
                    b.HasOne("Frontline.Domain.Legion")
                        .WithMany("Members")
                        .HasForeignKey("LegionId");
                });

            modelBuilder.Entity("Frontline.Domain.PlayerItem", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithMany("Items")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.PlayerOlReward", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithOne("OlReward")
                        .HasForeignKey("Frontline.Domain.PlayerOlReward", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Frontline.Domain.PVPFormation", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithMany("Formations")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.Quest", b =>
                {
                    b.HasOne("Frontline.Domain.PlayerQuestData")
                        .WithMany("Quests")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.QuestDaily", b =>
                {
                    b.HasOne("Frontline.Domain.PlayerQuestData")
                        .WithMany("QuestDailys")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.Section", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithMany("Sections")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.Team", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithMany("Teams")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.Unit", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithMany("Units")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Frontline.Domain.Wallet", b =>
                {
                    b.HasOne("Frontline.Domain.Player")
                        .WithOne("Wallet")
                        .HasForeignKey("Frontline.Domain.Wallet", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
