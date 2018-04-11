using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class ww : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DWeekBattle",
                columns: table => new
                {
                    mid = table.Column<int>(nullable: false),
                    day = table.Column<int>(nullable: false),
                    item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    lv = table.Column<int>(nullable: false),
                    res_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    unit_type = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DWeekBattle", x => new { x.mid, x.day });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DWeekBattle");
        }
    }
}
