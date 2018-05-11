using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Core.Migrations
{
    public partial class dshopxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DSecretShop",
                table: "DSecretShop");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "DSecretShop",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DSecretShop",
                table: "DSecretShop",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DSecretShop",
                table: "DSecretShop");

            migrationBuilder.DropColumn(
                name: "id",
                table: "DSecretShop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DSecretShop",
                table: "DSecretShop",
                columns: new[] { "mission_type", "shop_id" });
        }
    }
}
