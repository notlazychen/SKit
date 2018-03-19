using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class equipitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "grade_item_id",
                table: "DEquips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "grade_item_cnt",
                table: "DEquips",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "grade_item_id",
                table: "DEquips",
                nullable: false,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "grade_item_cnt",
                table: "DEquips",
                nullable: false,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);
        }
    }
}
