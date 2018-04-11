using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class resc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rescues",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    LastRefreshTime = table.Column<DateTime>(nullable: false),
                    LastTodayDiff = table.Column<int>(nullable: false),
                    UseNumb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rescues", x => x.PlayerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rescues");
        }
    }
}
