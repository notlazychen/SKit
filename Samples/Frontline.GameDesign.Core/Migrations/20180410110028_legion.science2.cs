using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class legionscience2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DLegionScience",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    atk = table.Column<int>(nullable: false),
                    damage = table.Column<int>(nullable: false),
                    damage_del = table.Column<int>(nullable: false),
                    def = table.Column<int>(nullable: false),
                    desc = table.Column<string>(maxLength: 64, nullable: true),
                    hp = table.Column<int>(nullable: false),
                    icon = table.Column<int>(nullable: false),
                    item_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    item_id = table.Column<JsonObject<Int32[]>>(nullable: true),
                    legion_lv = table.Column<int>(nullable: false),
                    lv = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 64, nullable: true),
                    res_cnt = table.Column<JsonObject<Int32[]>>(nullable: true),
                    res_type = table.Column<JsonObject<Int32[]>>(nullable: true),
                    unit_scope = table.Column<JsonObject<Int32[]>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLegionScience", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DLegionScience");
        }
    }
}
