using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class randmonname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "DNames");

            migrationBuilder.AddColumn<int>(
                name: "UsedNumber",
                table: "DNames",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedNumber",
                table: "DNames");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "DNames",
                nullable: false,
                defaultValue: false);
        }
    }
}
