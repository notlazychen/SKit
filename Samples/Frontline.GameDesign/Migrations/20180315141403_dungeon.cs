using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class dungeon : Migration
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
                    drop_items = table.Column<string>(nullable: true),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDungeons");
        }
    }
}
