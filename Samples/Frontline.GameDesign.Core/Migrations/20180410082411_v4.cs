using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cnt",
                table: "DRandom",
                newName: "min");

            migrationBuilder.AddColumn<int>(
                name: "max",
                table: "DRandom",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max",
                table: "DRandom");

            migrationBuilder.RenameColumn(
                name: "min",
                table: "DRandom",
                newName: "cnt");
        }
    }
}
