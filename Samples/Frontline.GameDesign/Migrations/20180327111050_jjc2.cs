using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class jjc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "rank_area",
                table: "DArenaRankRewards",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "rank_area",
                table: "DArenaRankRewards",
                nullable: false,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);
        }
    }
}
