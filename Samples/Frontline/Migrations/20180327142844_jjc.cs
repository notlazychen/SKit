using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class jjc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReceivedRewards",
                table: "ArenaCerts",
                nullable: true,
                oldClrType: typeof(JsonObject<List<int>>),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonObject<List<int>>>(
                name: "ReceivedRewards",
                table: "ArenaCerts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
