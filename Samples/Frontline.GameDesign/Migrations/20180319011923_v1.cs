using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDungeons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    desc = table.Column<string>(maxLength: 32, nullable: true),
                    drop_items = table.Column<string>(maxLength: 128, nullable: true),
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
                    table.PrimaryKey("PK_DDungeons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DItems",
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
                    table.PrimaryKey("PK_DItems", x => x.tid);
                });

            migrationBuilder.CreateTable(
                name: "DLevels",
                columns: table => new
                {
                    level = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    buy_gold = table.Column<int>(nullable: false),
                    exp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLevels", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DMonsterAbilities",
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
                    table.PrimaryKey("PK_DMonsterAbilities", x => x.level);
                });

            migrationBuilder.CreateTable(
                name: "DMonsterInDungeons",
                columns: table => new
                {
                    dungeon_id = table.Column<int>(nullable: false),
                    mid = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMonsterInDungeons", x => new { x.dungeon_id, x.mid });
                });

            migrationBuilder.CreateTable(
                name: "DMonsters",
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
                    table.PrimaryKey("PK_DMonsters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DUnits",
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
                    desc = table.Column<string>(nullable: true),
                    distance = table.Column<float>(nullable: false),
                    energy = table.Column<int>(nullable: false),
                    equip = table.Column<string>(nullable: true),
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
                    prop_grow_type = table.Column<string>(nullable: true),
                    prop_grow_val = table.Column<string>(nullable: true),
                    prop_type = table.Column<string>(nullable: true),
                    prop_val = table.Column<string>(nullable: true),
                    pvp_dec_score = table.Column<int>(nullable: false),
                    pvp_point = table.Column<int>(nullable: false),
                    r = table.Column<float>(nullable: false),
                    res_cnt = table.Column<string>(nullable: true),
                    res_type = table.Column<string>(nullable: true),
                    rev = table.Column<float>(nullable: false),
                    rev_body = table.Column<float>(nullable: false),
                    sec = table.Column<int>(nullable: false),
                    show_p = table.Column<int>(nullable: false),
                    skills = table.Column<JsonObject<Int32[]>>(nullable: true),
                    speed = table.Column<float>(nullable: false),
                    star = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    type_detail = table.Column<int>(nullable: false),
                    ww_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUnits", x => x.tid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DDungeons_section_type",
                table: "DDungeons",
                columns: new[] { "section", "type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDungeons");

            migrationBuilder.DropTable(
                name: "DItems");

            migrationBuilder.DropTable(
                name: "DLevels");

            migrationBuilder.DropTable(
                name: "DMonsterAbilities");

            migrationBuilder.DropTable(
                name: "DMonsterInDungeons");

            migrationBuilder.DropTable(
                name: "DMonsters");

            migrationBuilder.DropTable(
                name: "DUnits");
        }
    }
}
