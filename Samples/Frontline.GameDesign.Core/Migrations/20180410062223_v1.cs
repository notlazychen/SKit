using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DArenaChallengeReward",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    random_id = table.Column<int>(nullable: false),
                    times = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DArenaChallengeReward", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DArenaRankReward",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    items_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    items_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    random_id = table.Column<int>(nullable: false),
                    rank_area = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DArenaRankReward", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DDiKangQianXian",
                columns: table => new
                {
                    wid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    command = table.Column<int>(nullable: false),
                    monsters = table.Column<JsonObject<Int32[]>>(nullable: true),
                    token = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDiKangQianXian", x => x.wid);
                });

            migrationBuilder.CreateTable(
                name: "DDiKangQianXianBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    box = table.Column<int>(nullable: false),
                    wid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDiKangQianXianBox", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DDiKangQianXianBuilding",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    defence = table.Column<int>(nullable: false),
                    hp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDiKangQianXianBuilding", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DDungeon",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    desc = table.Column<string>(maxLength: 32, nullable: true),
                    drop_items = table.Column<JsonObject<List<int>>>(maxLength: 128, nullable: true),
                    exp = table.Column<int>(nullable: false),
                    exp_element = table.Column<int>(nullable: false),
                    fight_times = table.Column<int>(nullable: false),
                    gold = table.Column<int>(nullable: false),
                    icon = table.Column<string>(maxLength: 32, nullable: true),
                    level_limit = table.Column<int>(nullable: false),
                    map_fighting = table.Column<string>(maxLength: 32, nullable: true),
                    map_file_name = table.Column<string>(maxLength: 32, nullable: true),
                    map_res_name = table.Column<string>(maxLength: 32, nullable: true),
                    mission = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    next = table.Column<int>(nullable: false),
                    oil_cost = table.Column<int>(nullable: false),
                    power = table.Column<int>(nullable: false),
                    random_id = table.Column<int>(nullable: false),
                    screen_id = table.Column<string>(maxLength: 32, nullable: true),
                    section = table.Column<int>(nullable: false),
                    section_name = table.Column<string>(maxLength: 32, nullable: true),
                    time_limit_1 = table.Column<int>(nullable: false),
                    time_limit_2 = table.Column<int>(nullable: false),
                    time_limit_3 = table.Column<int>(nullable: false),
                    type = table.Column<int>(maxLength: 32, nullable: false),
                    type_name = table.Column<string>(maxLength: 32, nullable: true),
                    wipe_cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDungeon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DDungeonStar",
                columns: table => new
                {
                    type = table.Column<int>(nullable: false),
                    section = table.Column<int>(nullable: false),
                    index = table.Column<int>(nullable: false),
                    res_count = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    star = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDungeonStar", x => new { x.type, x.section, x.index });
                });

            migrationBuilder.CreateTable(
                name: "DEquip",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    base_attr_type = table.Column<int>(nullable: false),
                    base_attr_value = table.Column<float>(nullable: false),
                    gradeid = table.Column<int>(nullable: false),
                    level_grow = table.Column<float>(nullable: false),
                    level_k = table.Column<int>(nullable: false),
                    pos = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEquip", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEquipGrade",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    grade = table.Column<int>(nullable: false),
                    grade_grow = table.Column<float>(nullable: false),
                    grade_item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    grade_item_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    grade_res_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    grade_res_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    max_level = table.Column<int>(nullable: false),
                    next_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEquipGrade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DEquipLevelCost",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    soldier_gold = table.Column<int>(nullable: false),
                    tank_gold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEquipLevelCost", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DFacTask",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cost_item_cnt = table.Column<int>(nullable: false),
                    cost_item_id = table.Column<int>(nullable: false),
                    cost_time = table.Column<int>(nullable: false),
                    done_item_cnt = table.Column<int>(nullable: false),
                    done_item_id = table.Column<int>(nullable: false),
                    group = table.Column<int>(nullable: false),
                    item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_cnt_ex = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_id_ex = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_cnt = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    reward_ex_prob = table.Column<float>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    w = table.Column<int>(nullable: false),
                    worker_q = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFacTask", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DFacTaskGroup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gourp_supply = table.Column<int>(nullable: false),
                    group_iron = table.Column<int>(nullable: false),
                    max_level = table.Column<int>(nullable: false),
                    min_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFacTaskGroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DFacWorker",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    itemes_p = table.Column<int>(nullable: false),
                    output_p = table.Column<int>(nullable: false),
                    res_cnt = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DFacWorker", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DItem",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bag_type = table.Column<int>(nullable: false),
                    breakCount = table.Column<int>(nullable: false),
                    breakRandomId = table.Column<int>(nullable: false),
                    breakUnitId = table.Column<int>(nullable: false),
                    cd = table.Column<TimeSpan>(nullable: true),
                    desc = table.Column<string>(maxLength: 64, nullable: true),
                    diamond = table.Column<int>(nullable: false),
                    icon = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    overlap = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    quality = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    useable = table.Column<bool>(nullable: false),
                    worth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DItem", x => x.tid);
                });

            migrationBuilder.CreateTable(
                name: "DLegion",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    def_player_cnt = table.Column<int>(nullable: false),
                    exp = table.Column<int>(nullable: false),
                    glv_add = table.Column<float>(nullable: false),
                    max = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLegion", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DLegionDonate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contri = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false),
                    exp_party = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 64, nullable: true),
                    party_coin = table.Column<int>(nullable: false),
                    party_contri = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLegionDonate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DLevel",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    buy_gold = table.Column<int>(nullable: false),
                    exp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLevel", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DLottery",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cost_item = table.Column<int>(nullable: false),
                    cost_res_cnt = table.Column<int>(nullable: false),
                    cost_res_type = table.Column<int>(nullable: false),
                    free_cd = table.Column<int>(nullable: false),
                    free_cnt = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    rand = table.Column<int>(nullable: false),
                    rand_first10 = table.Column<int>(nullable: false),
                    rand_sp = table.Column<int>(nullable: false),
                    ten_discount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLottery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DLotteryGroup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group = table.Column<JsonObject<Int32[]>>(nullable: true),
                    group_w = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLotteryGroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DLotteryRand",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    group = table.Column<int>(nullable: false),
                    item_cnt = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false),
                    lv_max = table.Column<int>(nullable: false),
                    lv_min = table.Column<int>(nullable: false),
                    w = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLotteryRand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DMonster",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    armor = table.Column<int>(nullable: false),
                    att = table.Column<int>(nullable: false),
                    att_effect = table.Column<string>(maxLength: 32, nullable: true),
                    bullet_count = table.Column<int>(nullable: false),
                    cd = table.Column<float>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    crit = table.Column<float>(nullable: false),
                    crit_hurt = table.Column<float>(nullable: false),
                    defence = table.Column<int>(nullable: false),
                    desc = table.Column<string>(maxLength: 64, nullable: true),
                    die_model = table.Column<string>(maxLength: 32, nullable: true),
                    distance = table.Column<float>(nullable: false),
                    energy = table.Column<int>(nullable: false),
                    hp = table.Column<int>(nullable: false),
                    hurt_add = table.Column<float>(nullable: false),
                    hurt_multiple = table.Column<float>(nullable: false),
                    hurt_sub = table.Column<float>(nullable: false),
                    last_time = table.Column<float>(nullable: false),
                    lv = table.Column<int>(nullable: false),
                    model = table.Column<string>(maxLength: 32, nullable: true),
                    move_effect = table.Column<string>(maxLength: 32, nullable: true),
                    name = table.Column<string>(maxLength: 32, nullable: true),
                    nation = table.Column<int>(nullable: false),
                    off = table.Column<float>(nullable: false),
                    r = table.Column<float>(nullable: false),
                    rev = table.Column<float>(nullable: false),
                    rev_body = table.Column<float>(nullable: false),
                    scale = table.Column<float>(nullable: false),
                    speed = table.Column<float>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    type_detail = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMonster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DMonsterAbility",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    s_atk = table.Column<float>(nullable: false),
                    s_def = table.Column<float>(nullable: false),
                    s_hp = table.Column<float>(nullable: false),
                    t_atk = table.Column<float>(nullable: false),
                    t_def = table.Column<float>(nullable: false),
                    t_hp = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMonsterAbility", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DMonsterInDungeon",
                columns: table => new
                {
                    dungeon_id = table.Column<int>(nullable: false),
                    mid = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMonsterInDungeon", x => new { x.dungeon_id, x.mid });
                });

            migrationBuilder.CreateTable(
                name: "DName",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    UsedNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DName", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DOlReward",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adv_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    adv_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    low_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    low_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    t = table.Column<int>(nullable: false),
                    time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOlReward", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DQuest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    condition_target = table.Column<int>(nullable: false),
                    condition_type = table.Column<int>(nullable: false),
                    index = table.Column<int>(nullable: false),
                    limit_level = table.Column<int>(nullable: false),
                    max_progress = table.Column<int>(nullable: false),
                    next_quest_id = table.Column<int>(nullable: false),
                    res_diamond = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DQuest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DQuestDaily",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    condition_target = table.Column<int>(nullable: false),
                    condition_type = table.Column<int>(nullable: false),
                    level_area = table.Column<JsonObject<Int32[]>>(nullable: true),
                    max_progress = table.Column<int>(nullable: false),
                    quest_point = table.Column<int>(nullable: false),
                    res_exp = table.Column<int>(nullable: false),
                    res_oil = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DQuestDaily", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DQuestDailyReward",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item_id = table.Column<int>(nullable: false),
                    lv = table.Column<JsonObject<Int32[]>>(nullable: true),
                    point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DQuestDailyReward", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DRandom",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    count = table.Column<JsonObject<Int32[]>>(nullable: true),
                    desc = table.Column<string>(maxLength: 32, nullable: true),
                    gid = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_count = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    weight = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRandom", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DRescue",
                columns: table => new
                {
                    mid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    diffic = table.Column<int>(nullable: false),
                    iron = table.Column<int>(nullable: false),
                    may_drop = table.Column<JsonObject<Int32[]>>(nullable: true),
                    supply = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRescue", x => x.mid);
                });

            migrationBuilder.CreateTable(
                name: "DResPrice",
                columns: table => new
                {
                    times = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gold = table.Column<int>(nullable: false),
                    gold_cost = table.Column<int>(nullable: false),
                    iron = table.Column<int>(nullable: false),
                    iron_cost = table.Column<int>(nullable: false),
                    oil = table.Column<int>(nullable: false),
                    oil_cost = table.Column<int>(nullable: false),
                    supply = table.Column<int>(nullable: false),
                    supply_cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DResPrice", x => x.times);
                });

            migrationBuilder.CreateTable(
                name: "DTransport",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    diff = table.Column<int>(nullable: false),
                    gold = table.Column<int>(nullable: false),
                    robbers1 = table.Column<JsonObject<Int32[]>>(nullable: true),
                    robbers2 = table.Column<JsonObject<Int32[]>>(nullable: true),
                    robbers3 = table.Column<JsonObject<Int32[]>>(nullable: true),
                    truck_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTransport", x => x.tid);
                });

            migrationBuilder.CreateTable(
                name: "DUnit",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    armor = table.Column<int>(nullable: false),
                    att_add = table.Column<float>(nullable: false),
                    bullet_count = table.Column<int>(nullable: false),
                    cd = table.Column<float>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    crit = table.Column<float>(nullable: false),
                    crit_hurt = table.Column<float>(nullable: false),
                    crit_v = table.Column<int>(nullable: false),
                    def_add = table.Column<float>(nullable: false),
                    desc = table.Column<string>(maxLength: 128, nullable: true),
                    distance = table.Column<float>(nullable: false),
                    energy = table.Column<int>(nullable: false),
                    equip = table.Column<JsonObject<Int32[]>>(nullable: true),
                    exist = table.Column<int>(nullable: false),
                    grade_item_id = table.Column<int>(nullable: false),
                    grade_max = table.Column<int>(nullable: false),
                    gvg_rest_diamond = table.Column<int>(nullable: false),
                    gvg_rest_res_cnt = table.Column<string>(nullable: true),
                    gvg_rest_second = table.Column<int>(nullable: false),
                    hp_add = table.Column<float>(nullable: false),
                    hurt_add = table.Column<float>(nullable: false),
                    hurt_add_v = table.Column<int>(nullable: false),
                    hurt_multiple = table.Column<float>(nullable: false),
                    hurt_sub = table.Column<float>(nullable: false),
                    hurt_sub_v = table.Column<int>(nullable: false),
                    last_time = table.Column<float>(nullable: false),
                    max_energy = table.Column<int>(nullable: false),
                    mob = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    nation = table.Column<int>(nullable: false),
                    off = table.Column<float>(nullable: false),
                    prop_grow_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    prop_grow_val = table.Column<JsonObject<Single[]>>(nullable: true),
                    prop_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    prop_val = table.Column<JsonObject<Single[]>>(nullable: true),
                    pvp_dec_score = table.Column<int>(nullable: false),
                    pvp_point = table.Column<int>(nullable: false),
                    r = table.Column<float>(nullable: false),
                    res_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    rev = table.Column<float>(nullable: false),
                    rev_body = table.Column<float>(nullable: false),
                    sec = table.Column<int>(nullable: false),
                    show_p = table.Column<int>(nullable: false),
                    skills = table.Column<JsonObject<List<int>>>(nullable: true),
                    speed = table.Column<float>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    type_detail = table.Column<int>(nullable: false),
                    ww_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnit", x => x.tid);
                });

            migrationBuilder.CreateTable(
                name: "DUnitGradeUp",
                columns: table => new
                {
                    star = table.Column<int>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    atk = table.Column<float>(nullable: false),
                    cost_item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    cost_item_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    defence = table.Column<float>(nullable: false),
                    gold = table.Column<int>(nullable: false),
                    grade_item_cnt = table.Column<int>(nullable: false),
                    hp = table.Column<float>(nullable: false),
                    max_level = table.Column<int>(nullable: false),
                    min_level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnitGradeUp", x => new { x.star, x.grade, x.type });
                });

            migrationBuilder.CreateTable(
                name: "DUnitLevelUp",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    star1 = table.Column<int>(nullable: false),
                    star2 = table.Column<int>(nullable: false),
                    star3 = table.Column<int>(nullable: false),
                    star4 = table.Column<int>(nullable: false),
                    star5 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnitLevelUp", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DUnitUnlock",
                columns: table => new
                {
                    tid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item_cnt = table.Column<int>(nullable: false),
                    item_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnitUnlock", x => x.tid);
                });

            migrationBuilder.CreateTable(
                name: "VIPPrivilege",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    lv = table.Column<int>(nullable: false),
                    work_day_hire_n = table.Column<int>(nullable: false),
                    work_reward_ex_prob = table.Column<float>(nullable: false),
                    work_total_hire_n = table.Column<int>(nullable: false),
                    work_worker4_hire_n = table.Column<int>(nullable: false),
                    work_worker4_prob = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPPrivilege", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DDungeon_section_type",
                table: "DDungeon",
                columns: new[] { "section", "type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DArenaChallengeReward");

            migrationBuilder.DropTable(
                name: "DArenaRankReward");

            migrationBuilder.DropTable(
                name: "DDiKangQianXian");

            migrationBuilder.DropTable(
                name: "DDiKangQianXianBox");

            migrationBuilder.DropTable(
                name: "DDiKangQianXianBuilding");

            migrationBuilder.DropTable(
                name: "DDungeon");

            migrationBuilder.DropTable(
                name: "DDungeonStar");

            migrationBuilder.DropTable(
                name: "DEquip");

            migrationBuilder.DropTable(
                name: "DEquipGrade");

            migrationBuilder.DropTable(
                name: "DEquipLevelCost");

            migrationBuilder.DropTable(
                name: "DFacTask");

            migrationBuilder.DropTable(
                name: "DFacTaskGroup");

            migrationBuilder.DropTable(
                name: "DFacWorker");

            migrationBuilder.DropTable(
                name: "DItem");

            migrationBuilder.DropTable(
                name: "DLegion");

            migrationBuilder.DropTable(
                name: "DLegionDonate");

            migrationBuilder.DropTable(
                name: "DLevel");

            migrationBuilder.DropTable(
                name: "DLottery");

            migrationBuilder.DropTable(
                name: "DLotteryGroup");

            migrationBuilder.DropTable(
                name: "DLotteryRand");

            migrationBuilder.DropTable(
                name: "DMonster");

            migrationBuilder.DropTable(
                name: "DMonsterAbility");

            migrationBuilder.DropTable(
                name: "DMonsterInDungeon");

            migrationBuilder.DropTable(
                name: "DName");

            migrationBuilder.DropTable(
                name: "DOlReward");

            migrationBuilder.DropTable(
                name: "DQuest");

            migrationBuilder.DropTable(
                name: "DQuestDaily");

            migrationBuilder.DropTable(
                name: "DQuestDailyReward");

            migrationBuilder.DropTable(
                name: "DRandom");

            migrationBuilder.DropTable(
                name: "DRescue");

            migrationBuilder.DropTable(
                name: "DResPrice");

            migrationBuilder.DropTable(
                name: "DTransport");

            migrationBuilder.DropTable(
                name: "DUnit");

            migrationBuilder.DropTable(
                name: "DUnitGradeUp");

            migrationBuilder.DropTable(
                name: "DUnitLevelUp");

            migrationBuilder.DropTable(
                name: "DUnitUnlock");

            migrationBuilder.DropTable(
                name: "VIPPrivilege");
        }
    }
}
