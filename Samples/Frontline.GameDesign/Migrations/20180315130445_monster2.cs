using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class monster2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    level = table.Column<int>(nullable: false),
                    mid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DMonsterInDungeons", x => x.id);
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
                    desc = table.Column<string>(maxLength: 32, nullable: true),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DMonsterAbilities");

            migrationBuilder.DropTable(
                name: "DMonsterInDungeons");

            migrationBuilder.DropTable(
                name: "DMonsters");
        }
    }
}
