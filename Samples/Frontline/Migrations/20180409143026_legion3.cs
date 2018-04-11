using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class legion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContriTimes",
                table: "LegionMembers");

            migrationBuilder.AddColumn<bool>(
                name: "IsTodayDonated",
                table: "LegionMembers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LegionApplications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LegionId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    RequestTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegionApplications_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LegionBBS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    LegionId = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegionBBS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegionBBS_Legions_LegionId",
                        column: x => x.LegionId,
                        principalTable: "Legions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Args = table.Column<JsonObject<List<string>>>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IsCollected = table.Column<bool>(nullable: false),
                    IsLegionMail = table.Column<bool>(nullable: false),
                    IsReaded = table.Column<bool>(nullable: false),
                    IsRecved = table.Column<bool>(nullable: false),
                    LegionName = table.Column<string>(nullable: true),
                    PlayerId = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailAttachment",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MailId = table.Column<string>(nullable: true),
                    Tid = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailAttachment_Mails_MailId",
                        column: x => x.MailId,
                        principalTable: "Mails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegionApplications_LegionId",
                table: "LegionApplications",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_LegionBBS_LegionId",
                table: "LegionBBS",
                column: "LegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MailAttachment_MailId",
                table: "MailAttachment",
                column: "MailId");

            migrationBuilder.CreateIndex(
                name: "IX_Mails_PlayerId",
                table: "Mails",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegionApplications");

            migrationBuilder.DropTable(
                name: "LegionBBS");

            migrationBuilder.DropTable(
                name: "MailAttachment");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropColumn(
                name: "IsTodayDonated",
                table: "LegionMembers");

            migrationBuilder.AddColumn<int>(
                name: "ContriTimes",
                table: "LegionMembers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
