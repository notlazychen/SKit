using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class ral2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "second",
                table: "DRaffleGroup");

            migrationBuilder.AddColumn<DateTime>(
                name: "endtime",
                table: "DRaffleGroup",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endtime",
                table: "DRaffleGroup");

            migrationBuilder.AddColumn<int>(
                name: "second",
                table: "DRaffleGroup",
                nullable: false,
                defaultValue: 0);
        }
    }
}
