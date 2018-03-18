using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class unit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    equip = table.Column<int>(nullable: false),
                    exist = table.Column<int>(nullable: false),
                    grade_item_id = table.Column<int>(nullable: false),
                    grade_max = table.Column<int>(nullable: false),
                    gvg_rest_diamond = table.Column<int>(nullable: false),
                    gvg_rest_res_cnt = table.Column<int>(nullable: false),
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
                    prop_grow_type = table.Column<int>(nullable: false),
                    prop_grow_val = table.Column<float>(nullable: false),
                    prop_type = table.Column<int>(nullable: false),
                    prop_val = table.Column<float>(nullable: false),
                    pvp_dec_score = table.Column<int>(nullable: false),
                    pvp_point = table.Column<int>(nullable: false),
                    r = table.Column<float>(nullable: false),
                    res_cnt = table.Column<int>(nullable: false),
                    res_type = table.Column<int>(nullable: false),
                    rev = table.Column<float>(nullable: false),
                    rev_body = table.Column<float>(nullable: false),
                    sec = table.Column<int>(nullable: false),
                    show_p = table.Column<int>(nullable: false),
                    skills = table.Column<int>(nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DUnits");
        }
    }
}
