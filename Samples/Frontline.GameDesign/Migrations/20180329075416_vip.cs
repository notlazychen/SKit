using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class vip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VIPPrivileges",
                columns: table => new
                {
                    lv = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    work_day_hire_n = table.Column<int>(nullable: false),
                    work_reward_ex_prob = table.Column<float>(nullable: false),
                    work_total_hire_n = table.Column<int>(nullable: false),
                    work_worker4_hire_n = table.Column<int>(nullable: false),
                    work_worker4_prob = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPPrivileges", x => x.lv);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VIPPrivileges");
        }
    }
}
