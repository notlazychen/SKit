﻿// <auto-generated />
using Frontline.GameDesign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    [DbContext(typeof(GameDesignContext))]
    [Migration("20180406045912_transport")]
    partial class transport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Frontline.GameDesign.DArenaChallengeReward", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("random_id");

                    b.Property<int>("times");

                    b.HasKey("id");

                    b.ToTable("DArenaChallengeRewards");
                });

            modelBuilder.Entity("Frontline.GameDesign.DArenaRankReward", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<JsonObject<Int32[]>>("items_cnt");

                    b.Property<JsonObject<Int32[]>>("items_id");

                    b.Property<int>("random_id");

                    b.Property<JsonObject<Int32[]>>("rank_area");

                    b.HasKey("id");

                    b.ToTable("DArenaRankRewards");
                });

            modelBuilder.Entity("Frontline.GameDesign.DDiKangQianXian", b =>
                {
                    b.Property<int>("wid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("command");

                    b.Property<JsonObject<Int32[]>>("monsters");

                    b.Property<int>("token");

                    b.HasKey("wid");

                    b.ToTable("DDiKangQianXians");
                });

            modelBuilder.Entity("Frontline.GameDesign.DDiKangQianXianBox", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("box");

                    b.Property<int>("wid");

                    b.HasKey("id");

                    b.ToTable("DDiKangQianXianBoxs");
                });

            modelBuilder.Entity("Frontline.GameDesign.DDiKangQianXianBuilding", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("defence");

                    b.Property<int>("hp");

                    b.HasKey("id");

                    b.ToTable("DDiKangQianXianBuildings");
                });

            modelBuilder.Entity("Frontline.GameDesign.DDungeon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("desc")
                        .HasMaxLength(32);

                    b.Property<JsonObject<List<int>>>("drop_items")
                        .HasMaxLength(128);

                    b.Property<int>("exp");

                    b.Property<int>("exp_element");

                    b.Property<int>("fight_times");

                    b.Property<int>("gold");

                    b.Property<string>("icon")
                        .HasMaxLength(32);

                    b.Property<int>("level_limit");

                    b.Property<string>("map_fighting")
                        .HasMaxLength(32);

                    b.Property<string>("map_file_name")
                        .HasMaxLength(32);

                    b.Property<string>("map_res_name")
                        .HasMaxLength(32);

                    b.Property<int>("mission");

                    b.Property<string>("name")
                        .HasMaxLength(32);

                    b.Property<int>("next");

                    b.Property<int>("oil_cost");

                    b.Property<int>("power");

                    b.Property<int>("random_id");

                    b.Property<string>("screen_id")
                        .HasMaxLength(32);

                    b.Property<int>("section");

                    b.Property<string>("section_name")
                        .HasMaxLength(32);

                    b.Property<int>("time_limit_1");

                    b.Property<int>("time_limit_2");

                    b.Property<int>("time_limit_3");

                    b.Property<int>("type")
                        .HasMaxLength(32);

                    b.Property<string>("type_name")
                        .HasMaxLength(32);

                    b.Property<int>("wipe_cost");

                    b.HasKey("id");

                    b.HasIndex("section", "type");

                    b.ToTable("DDungeons");
                });

            modelBuilder.Entity("Frontline.GameDesign.DDungeonStar", b =>
                {
                    b.Property<int>("type");

                    b.Property<int>("section");

                    b.Property<int>("index");

                    b.Property<int>("res_count");

                    b.Property<int>("res_type");

                    b.Property<int>("star");

                    b.HasKey("type", "section", "index");

                    b.ToTable("DDungeonStars");
                });

            modelBuilder.Entity("Frontline.GameDesign.DEquip", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("base_attr_type");

                    b.Property<float>("base_attr_value");

                    b.Property<int>("gradeid");

                    b.Property<float>("level_grow");

                    b.Property<int>("level_k");

                    b.Property<int>("pos");

                    b.Property<int>("type");

                    b.HasKey("id");

                    b.ToTable("DEquips");
                });

            modelBuilder.Entity("Frontline.GameDesign.DEquipGrade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("grade");

                    b.Property<float>("grade_grow");

                    b.Property<JsonObject<Int32[]>>("grade_item_cnt");

                    b.Property<JsonObject<Int32[]>>("grade_item_id");

                    b.Property<int>("max_level");

                    b.Property<int>("next_id");

                    b.HasKey("id");

                    b.ToTable("DEquipGrades");
                });

            modelBuilder.Entity("Frontline.GameDesign.DEquipLevelCost", b =>
                {
                    b.Property<int>("level")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("soldier_gold");

                    b.Property<int>("tank_gold");

                    b.HasKey("level");

                    b.ToTable("DEquipLevelCosts");
                });

            modelBuilder.Entity("Frontline.GameDesign.DFacTask", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cost_oil");

                    b.Property<int>("cost_time");

                    b.Property<int>("done_item_cnt");

                    b.Property<int>("done_item_id");

                    b.Property<int>("group");

                    b.Property<JsonObject<Int32[]>>("item_cnt");

                    b.Property<JsonObject<Int32[]>>("item_cnt_ex");

                    b.Property<JsonObject<Int32[]>>("item_id_ex");

                    b.Property<JsonObject<Int32[]>>("item_type");

                    b.Property<int>("res_cnt");

                    b.Property<int>("res_type");

                    b.Property<float>("reward_ex_prob");

                    b.Property<int>("star");

                    b.Property<int>("type");

                    b.Property<int>("w");

                    b.Property<int>("worker_q");

                    b.HasKey("id");

                    b.ToTable("DFacTasks");
                });

            modelBuilder.Entity("Frontline.GameDesign.DFacTaskGroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("gourp_supply");

                    b.Property<int>("group_iron");

                    b.Property<int>("max_level");

                    b.Property<int>("min_level");

                    b.HasKey("id");

                    b.ToTable("DFacTaskGroup");
                });

            modelBuilder.Entity("Frontline.GameDesign.DFacWorker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("itemes_p");

                    b.Property<int>("output_p");

                    b.Property<int>("res_cnt");

                    b.Property<int>("res_type");

                    b.Property<int>("star");

                    b.Property<int>("type");

                    b.Property<int>("weight");

                    b.HasKey("id");

                    b.ToTable("DFacWorkers");
                });

            modelBuilder.Entity("Frontline.GameDesign.DItem", b =>
                {
                    b.Property<int>("tid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("bag_type");

                    b.Property<int>("breakCount");

                    b.Property<int>("breakRandomId");

                    b.Property<int>("breakUnitId");

                    b.Property<TimeSpan?>("cd");

                    b.Property<string>("desc")
                        .HasMaxLength(64);

                    b.Property<int>("diamond");

                    b.Property<int>("icon");

                    b.Property<string>("name")
                        .HasMaxLength(32);

                    b.Property<int>("overlap");

                    b.Property<int>("price");

                    b.Property<int>("quality");

                    b.Property<int>("type");

                    b.Property<bool>("useable");

                    b.Property<int>("worth");

                    b.HasKey("tid");

                    b.ToTable("DItems");
                });

            modelBuilder.Entity("Frontline.GameDesign.DLegion", b =>
                {
                    b.Property<int>("level")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("def_player_cnt");

                    b.Property<int>("exp");

                    b.Property<float>("glv_add");

                    b.Property<int>("max");

                    b.HasKey("level");

                    b.ToTable("DLegions");
                });

            modelBuilder.Entity("Frontline.GameDesign.DLevel", b =>
                {
                    b.Property<int>("level")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("buy_gold");

                    b.Property<int>("exp");

                    b.HasKey("level");

                    b.ToTable("DLevels");
                });

            modelBuilder.Entity("Frontline.GameDesign.DLottery", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cost_item");

                    b.Property<int>("cost_res_cnt");

                    b.Property<int>("cost_res_type");

                    b.Property<int>("free_cd");

                    b.Property<int>("free_cnt");

                    b.Property<string>("name")
                        .HasMaxLength(32);

                    b.Property<int>("rand");

                    b.Property<int>("rand_first10");

                    b.Property<int>("rand_sp");

                    b.Property<int>("ten_discount");

                    b.HasKey("id");

                    b.ToTable("DLotteries");
                });

            modelBuilder.Entity("Frontline.GameDesign.DLotteryGroup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<JsonObject<Int32[]>>("group");

                    b.Property<JsonObject<Int32[]>>("group_w");

                    b.HasKey("id");

                    b.ToTable("DLotteryGroups");
                });

            modelBuilder.Entity("Frontline.GameDesign.DLotteryRand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("group");

                    b.Property<int>("item_cnt");

                    b.Property<int>("item_id");

                    b.Property<int>("lv_max");

                    b.Property<int>("lv_min");

                    b.Property<int>("w");

                    b.HasKey("id");

                    b.ToTable("DLotteryRands");
                });

            modelBuilder.Entity("Frontline.GameDesign.DMonster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("armor");

                    b.Property<int>("att");

                    b.Property<string>("att_effect")
                        .HasMaxLength(32);

                    b.Property<int>("bullet_count");

                    b.Property<float>("cd");

                    b.Property<int>("count");

                    b.Property<float>("crit");

                    b.Property<float>("crit_hurt");

                    b.Property<int>("defence");

                    b.Property<string>("desc")
                        .HasMaxLength(64);

                    b.Property<string>("die_model")
                        .HasMaxLength(32);

                    b.Property<float>("distance");

                    b.Property<int>("energy");

                    b.Property<int>("hp");

                    b.Property<float>("hurt_add");

                    b.Property<float>("hurt_multiple");

                    b.Property<float>("hurt_sub");

                    b.Property<float>("last_time");

                    b.Property<int>("lv");

                    b.Property<string>("model")
                        .HasMaxLength(32);

                    b.Property<string>("move_effect")
                        .HasMaxLength(32);

                    b.Property<string>("name")
                        .HasMaxLength(32);

                    b.Property<int>("nation");

                    b.Property<float>("off");

                    b.Property<float>("r");

                    b.Property<float>("rev");

                    b.Property<float>("rev_body");

                    b.Property<float>("scale");

                    b.Property<float>("speed");

                    b.Property<int>("type");

                    b.Property<int>("type_detail");

                    b.HasKey("id");

                    b.ToTable("DMonsters");
                });

            modelBuilder.Entity("Frontline.GameDesign.DMonsterAbility", b =>
                {
                    b.Property<int>("level")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("s_atk");

                    b.Property<float>("s_def");

                    b.Property<float>("s_hp");

                    b.Property<float>("t_atk");

                    b.Property<float>("t_def");

                    b.Property<float>("t_hp");

                    b.HasKey("level");

                    b.ToTable("DMonsterAbilities");
                });

            modelBuilder.Entity("Frontline.GameDesign.DMonsterInDungeon", b =>
                {
                    b.Property<int>("dungeon_id");

                    b.Property<int>("mid");

                    b.Property<int>("level");

                    b.HasKey("dungeon_id", "mid");

                    b.ToTable("DMonsterInDungeons");
                });

            modelBuilder.Entity("Frontline.GameDesign.DName", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UsedNumber");

                    b.HasKey("Name");

                    b.ToTable("DNames");
                });

            modelBuilder.Entity("Frontline.GameDesign.DOlReward", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<JsonObject<Int32[]>>("adv_cnt");

                    b.Property<JsonObject<Int32[]>>("adv_id");

                    b.Property<JsonObject<Int32[]>>("low_cnt");

                    b.Property<JsonObject<Int32[]>>("low_id");

                    b.Property<int>("t");

                    b.Property<TimeSpan>("time");

                    b.HasKey("id");

                    b.ToTable("DOlRewards");
                });

            modelBuilder.Entity("Frontline.GameDesign.DQuest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("condition_target");

                    b.Property<int>("condition_type");

                    b.Property<int>("index");

                    b.Property<int>("limit_level");

                    b.Property<int>("max_progress");

                    b.Property<int>("next_quest_id");

                    b.Property<int>("res_diamond");

                    b.Property<int>("type");

                    b.HasKey("id");

                    b.ToTable("DQuests");
                });

            modelBuilder.Entity("Frontline.GameDesign.DQuestDaily", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("condition_target");

                    b.Property<int>("condition_type");

                    b.Property<JsonObject<Int32[]>>("level_area");

                    b.Property<int>("max_progress");

                    b.Property<int>("quest_point");

                    b.Property<int>("res_exp");

                    b.Property<int>("res_oil");

                    b.Property<int>("type");

                    b.HasKey("id");

                    b.ToTable("DQuestDailys");
                });

            modelBuilder.Entity("Frontline.GameDesign.DQuestDailyReward", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("item_id");

                    b.Property<JsonObject<Int32[]>>("lv");

                    b.Property<int>("point");

                    b.HasKey("id");

                    b.ToTable("DQuestDailyRewards");
                });

            modelBuilder.Entity("Frontline.GameDesign.DRandom", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<JsonObject<Int32[]>>("count");

                    b.Property<string>("desc")
                        .HasMaxLength(32);

                    b.Property<JsonObject<Int32[]>>("gid");

                    b.Property<JsonObject<Int32[]>>("res_count");

                    b.Property<JsonObject<Int32[]>>("res_type");

                    b.Property<JsonObject<Int32[]>>("weight");

                    b.HasKey("id");

                    b.ToTable("DRandoms");
                });

            modelBuilder.Entity("Frontline.GameDesign.DResPrice", b =>
                {
                    b.Property<int>("times")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("gold");

                    b.Property<int>("gold_cost");

                    b.Property<int>("iron");

                    b.Property<int>("iron_cost");

                    b.Property<int>("oil");

                    b.Property<int>("oil_cost");

                    b.Property<int>("supply");

                    b.Property<int>("supply_cost");

                    b.HasKey("times");

                    b.ToTable("DResPrices");
                });

            modelBuilder.Entity("Frontline.GameDesign.DTransport", b =>
                {
                    b.Property<int>("tid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("diff");

                    b.Property<int>("gold");

                    b.Property<JsonObject<Int32[]>>("robbers1");

                    b.Property<JsonObject<Int32[]>>("robbers2");

                    b.Property<JsonObject<Int32[]>>("robbers3");

                    b.Property<int>("truck_id");

                    b.HasKey("tid");

                    b.ToTable("DTransports");
                });

            modelBuilder.Entity("Frontline.GameDesign.DUnit", b =>
                {
                    b.Property<int>("tid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("armor");

                    b.Property<float>("att_add");

                    b.Property<int>("bullet_count");

                    b.Property<float>("cd");

                    b.Property<int>("count");

                    b.Property<float>("crit");

                    b.Property<float>("crit_hurt");

                    b.Property<int>("crit_v");

                    b.Property<float>("def_add");

                    b.Property<string>("desc")
                        .HasMaxLength(128);

                    b.Property<float>("distance");

                    b.Property<int>("energy");

                    b.Property<JsonObject<Int32[]>>("equip");

                    b.Property<int>("exist");

                    b.Property<int>("grade_item_id");

                    b.Property<int>("grade_max");

                    b.Property<int>("gvg_rest_diamond");

                    b.Property<string>("gvg_rest_res_cnt");

                    b.Property<int>("gvg_rest_second");

                    b.Property<float>("hp_add");

                    b.Property<float>("hurt_add");

                    b.Property<int>("hurt_add_v");

                    b.Property<float>("hurt_multiple");

                    b.Property<float>("hurt_sub");

                    b.Property<int>("hurt_sub_v");

                    b.Property<float>("last_time");

                    b.Property<int>("max_energy");

                    b.Property<int>("mob");

                    b.Property<string>("name");

                    b.Property<int>("nation");

                    b.Property<float>("off");

                    b.Property<JsonObject<Int32[]>>("prop_grow_type");

                    b.Property<JsonObject<Single[]>>("prop_grow_val");

                    b.Property<JsonObject<Int32[]>>("prop_type");

                    b.Property<JsonObject<Single[]>>("prop_val");

                    b.Property<int>("pvp_dec_score");

                    b.Property<int>("pvp_point");

                    b.Property<float>("r");

                    b.Property<JsonObject<Int32[]>>("res_cnt");

                    b.Property<JsonObject<Int32[]>>("res_type");

                    b.Property<float>("rev");

                    b.Property<float>("rev_body");

                    b.Property<int>("sec");

                    b.Property<int>("show_p");

                    b.Property<JsonObject<List<int>>>("skills");

                    b.Property<float>("speed");

                    b.Property<int>("star");

                    b.Property<int>("type");

                    b.Property<int>("type_detail");

                    b.Property<int>("ww_type");

                    b.HasKey("tid");

                    b.ToTable("DUnits");
                });

            modelBuilder.Entity("Frontline.GameDesign.DUnitGradeUp", b =>
                {
                    b.Property<int>("star");

                    b.Property<int>("grade");

                    b.Property<float>("atk");

                    b.Property<float>("defence");

                    b.Property<int>("gold");

                    b.Property<float>("hp");

                    b.Property<int>("item_cnt");

                    b.Property<int>("max_level");

                    b.Property<int>("min_level");

                    b.HasKey("star", "grade");

                    b.ToTable("DUnitGradeUps");
                });

            modelBuilder.Entity("Frontline.GameDesign.DUnitLevelUp", b =>
                {
                    b.Property<int>("level")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("star1");

                    b.Property<int>("star2");

                    b.Property<int>("star3");

                    b.Property<int>("star4");

                    b.Property<int>("star5");

                    b.HasKey("level");

                    b.ToTable("DUnitLevelUps");
                });

            modelBuilder.Entity("Frontline.GameDesign.DUnitUnlock", b =>
                {
                    b.Property<int>("tid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("item_cnt");

                    b.Property<int>("item_id");

                    b.HasKey("tid");

                    b.ToTable("DUnitUnlocks");
                });

            modelBuilder.Entity("Frontline.GameDesign.VIPPrivilege", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("lv");

                    b.Property<int>("work_day_hire_n");

                    b.Property<float>("work_reward_ex_prob");

                    b.Property<int>("work_total_hire_n");

                    b.Property<int>("work_worker4_hire_n");

                    b.Property<float>("work_worker4_prob");

                    b.HasKey("id");

                    b.ToTable("VIPPrivileges");
                });
#pragma warning restore 612, 618
        }
    }
}
