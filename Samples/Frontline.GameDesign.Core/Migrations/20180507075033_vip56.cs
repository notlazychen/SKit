using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class vip56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_gift",
                table: "DVIP");

            migrationBuilder.DropColumn(
                name: "next_gift",
                table: "DVIP");

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "first_item_cnt",
                table: "DVIP",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "first_item_id",
                table: "DVIP",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "next_item_cnt",
                table: "DVIP",
                nullable: true);

            migrationBuilder.AddColumn<JsonObject<Int32[]>>(
                name: "next_item_id",
                table: "DVIP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_item_cnt",
                table: "DVIP");

            migrationBuilder.DropColumn(
                name: "first_item_id",
                table: "DVIP");

            migrationBuilder.DropColumn(
                name: "next_item_cnt",
                table: "DVIP");

            migrationBuilder.DropColumn(
                name: "next_item_id",
                table: "DVIP");

            migrationBuilder.AddColumn<int>(
                name: "first_gift",
                table: "DVIP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "next_gift",
                table: "DVIP",
                nullable: false,
                defaultValue: 0);
        }
    }
}
