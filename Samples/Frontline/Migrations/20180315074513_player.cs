using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class player : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BuySkillNumb = table.Column<int>(nullable: false),
                    Camp = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Exp = table.Column<int>(nullable: false),
                    IP = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IsBind = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    LastLvUpTime = table.Column<DateTime>(nullable: false),
                    LastVipUpTime = table.Column<DateTime>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    MaxPower = table.Column<long>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    OldPlayer = table.Column<bool>(nullable: false),
                    RenameNumb = table.Column<int>(nullable: false),
                    ScienceNumb = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    StateTime = table.Column<long>(nullable: false),
                    UserCenterId = table.Column<long>(nullable: false),
                    UserCode = table.Column<string>(nullable: true),
                    VIP = table.Column<int>(nullable: false),
                    VIPExp = table.Column<int>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.UniqueConstraint("AK_Players_NickName", x => x.NickName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserCenterId",
                table: "Players",
                column: "UserCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserCode",
                table: "Players",
                column: "UserCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
