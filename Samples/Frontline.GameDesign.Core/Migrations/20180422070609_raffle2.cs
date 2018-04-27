using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class raffle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonObject<List<int>>>(
                name: "theme_unit_id",
                table: "DRaffleGroup",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "theme_unit_id",
                table: "DRaffleGroup",
                nullable: false,
                oldClrType: typeof(JsonObject<List<int>>),
                oldNullable: true);
        }
    }
}
