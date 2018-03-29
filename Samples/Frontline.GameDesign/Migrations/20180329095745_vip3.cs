using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class vip3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "level",
                table: "VIPPrivileges",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "lv",
                table: "VIPPrivileges",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lv",
                table: "VIPPrivileges");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VIPPrivileges",
                newName: "level");
        }
    }
}
