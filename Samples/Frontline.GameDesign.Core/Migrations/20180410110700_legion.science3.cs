using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class legionscience3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DLegionScience",
                table: "DLegionScience");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "DLegionScience",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DLegionScience",
                table: "DLegionScience",
                columns: new[] { "id", "lv" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DLegionScience",
                table: "DLegionScience");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "DLegionScience",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DLegionScience",
                table: "DLegionScience",
                column: "id");
        }
    }
}
