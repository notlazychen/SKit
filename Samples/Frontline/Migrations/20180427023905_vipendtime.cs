using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class vipendtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VIPExp",
                table: "Players",
                newName: "VIPGiftReceved");

            migrationBuilder.AddColumn<DateTime>(
                name: "VIPEndTime",
                table: "Players",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VIPEndTime",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "VIPGiftReceved",
                table: "Players",
                newName: "VIPExp");
        }
    }
}
