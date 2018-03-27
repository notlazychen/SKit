using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class fs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendApplications_FriendList_FriendListId",
                table: "FriendApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendList_FriendListId",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendApplications",
                table: "FriendApplications");

            migrationBuilder.DropIndex(
                name: "IX_FriendApplications_FriendListId",
                table: "FriendApplications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FriendApplications");

            migrationBuilder.RenameColumn(
                name: "IsSendOil",
                table: "Friendships",
                newName: "CanSendOil");

            migrationBuilder.RenameColumn(
                name: "IsRecvOil",
                table: "Friendships",
                newName: "CanRecvOil");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Friendships",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendListId",
                table: "Friendships",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "FriendApplications",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FriendListId",
                table: "FriendApplications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships",
                columns: new[] { "FriendListId", "PlayerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendApplications",
                table: "FriendApplications",
                columns: new[] { "FriendListId", "PlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendApplications_FriendList_FriendListId",
                table: "FriendApplications",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendList_FriendListId",
                table: "Friendships",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendApplications_FriendList_FriendListId",
                table: "FriendApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendList_FriendListId",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendApplications",
                table: "FriendApplications");

            migrationBuilder.RenameColumn(
                name: "CanSendOil",
                table: "Friendships",
                newName: "IsSendOil");

            migrationBuilder.RenameColumn(
                name: "CanRecvOil",
                table: "Friendships",
                newName: "IsRecvOil");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "Friendships",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "FriendListId",
                table: "Friendships",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Friendships",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "FriendApplications",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "FriendListId",
                table: "FriendApplications",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FriendApplications",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendApplications",
                table: "FriendApplications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FriendApplications_FriendListId",
                table: "FriendApplications",
                column: "FriendListId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendApplications_FriendList_FriendListId",
                table: "FriendApplications",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendList_FriendListId",
                table: "Friendships",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
