using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dvip2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIPPrivilege");

            migrationBuilder.CreateTable(
                name: "DVIP",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    can_sweep = table.Column<bool>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    diamond_mall_rate = table.Column<float>(nullable: false),
                    first_gift = table.Column<int>(nullable: false),
                    lv = table.Column<int>(nullable: false),
                    max_oil = table.Column<int>(nullable: false),
                    mission_ex_numb_buytimes = table.Column<int>(nullable: false),
                    next_gift = table.Column<int>(nullable: false),
                    oneday_buy_gold = table.Column<int>(nullable: false),
                    oneday_buy_oil = table.Column<int>(nullable: false),
                    oneday_recv_diamond = table.Column<int>(nullable: false),
                    oneday_recv_gold = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    property_addition = table.Column<int>(nullable: false),
                    reset_dikang = table.Column<int>(nullable: false),
                    reset_rescue = table.Column<int>(nullable: false),
                    reset_transport = table.Column<int>(nullable: false),
                    reset_weekwar = table.Column<int>(nullable: false),
                    sign_re_day_numb = table.Column<int>(nullable: false),
                    work_day_hire_n = table.Column<int>(nullable: false),
                    work_total_hire_n = table.Column<int>(nullable: false),
                    work_worker4_prob = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVIP", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DVIP");

            migrationBuilder.CreateTable(
                name: "VIPPrivilege",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
        }
    }
}
