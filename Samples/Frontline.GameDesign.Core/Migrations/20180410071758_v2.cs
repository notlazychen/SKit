using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VIPPrivilege",
                table: "VIPPrivilege");

            migrationBuilder.DropColumn(
                name: "id",
                table: "VIPPrivilege");

            migrationBuilder.AlterColumn<int>(
                name: "lv",
                table: "VIPPrivilege",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VIPPrivilege",
                table: "VIPPrivilege",
                column: "lv");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VIPPrivilege",
                table: "VIPPrivilege");

            migrationBuilder.AlterColumn<int>(
                name: "lv",
                table: "VIPPrivilege",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "VIPPrivilege",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VIPPrivilege",
                table: "VIPPrivilege",
                column: "id");
        }
    }
}
