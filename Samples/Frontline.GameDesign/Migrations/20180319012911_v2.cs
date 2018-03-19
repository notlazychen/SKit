using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "res_type",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "res_cnt",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "prop_val",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "prop_type",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "prop_grow_val",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "prop_grow_type",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "equip",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "desc",
                table: "DUnits",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "drop_items",
                table: "DDungeons",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "res_type",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "res_cnt",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "prop_val",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "prop_type",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "prop_grow_val",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "prop_grow_type",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "equip",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "desc",
                table: "DUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "drop_items",
                table: "DDungeons",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
