using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "desc",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "gid",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "res_count",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "res_type",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "DRandom");

            migrationBuilder.AddColumn<int>(
                name: "cnt",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "group",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "random",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tid",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "w",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cnt",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "group",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "random",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "tid",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "type",
                table: "DRandom");

            migrationBuilder.DropColumn(
                name: "w",
                table: "DRandom");

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "count",
                table: "DRandom",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "DRandom",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "gid",
                table: "DRandom",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "res_count",
                table: "DRandom",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "res_type",
                table: "DRandom",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "weight",
                table: "DRandom",
                nullable: true);
        }
    }
}
