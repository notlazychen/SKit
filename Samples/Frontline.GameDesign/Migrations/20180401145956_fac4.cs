using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.GameDesign.Migrations
{
    public partial class fac4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "res_type",
                table: "DFacTasks",
                nullable: false,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "res_cnt",
                table: "DFacTasks",
                nullable: false,
                oldClrType: typeof(JsonObject<Int32[]>),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "res_type",
                table: "DFacTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<JsonObject<Int32[]>>(
                name: "res_cnt",
                table: "DFacTasks",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
