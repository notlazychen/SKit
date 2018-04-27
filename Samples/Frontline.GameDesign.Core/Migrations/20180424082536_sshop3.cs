using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class sshop3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "second",
                table: "DSecretShop",
                newName: "interval_second");

            migrationBuilder.AddColumn<int>(
                name: "duration_second",
                table: "DSecretShop",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration_second",
                table: "DSecretShop");

            migrationBuilder.RenameColumn(
                name: "interval_second",
                table: "DSecretShop",
                newName: "second");
        }
    }
}
