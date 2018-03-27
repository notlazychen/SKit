using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class olreward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOlRewards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adv_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    adv_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    low_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    low_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    t = table.Column<int>(nullable: false),
                    time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOlRewards", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOlRewards");
        }
    }
}
