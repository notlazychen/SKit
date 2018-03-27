using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class fs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendApplication_FriendList_FriendListId",
                table: "FriendApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendship_FriendList_FriendListId",
                table: "Friendship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friendship",
                table: "Friendship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendApplication",
                table: "FriendApplication");

            migrationBuilder.RenameTable(
                name: "Friendship",
                newName: "Friendships");

            migrationBuilder.RenameTable(
                name: "FriendApplication",
                newName: "FriendApplications");

            migrationBuilder.RenameIndex(
                name: "IX_Friendship_FriendListId",
                table: "Friendships",
                newName: "IX_Friendships_FriendListId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendApplication_FriendListId",
                table: "FriendApplications",
                newName: "IX_FriendApplications_FriendListId");

            migrationBuilder.AlterColumn<int>(
                name: "MaxPower",
                table: "Players",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendships",
                table: "Friendships",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendApplications",
                table: "FriendApplications",
                column: "Id");

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

            migrationBuilder.RenameTable(
                name: "Friendships",
                newName: "Friendship");

            migrationBuilder.RenameTable(
                name: "FriendApplications",
                newName: "FriendApplication");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_FriendListId",
                table: "Friendship",
                newName: "IX_Friendship_FriendListId");

            migrationBuilder.RenameIndex(
                name: "IX_FriendApplications_FriendListId",
                table: "FriendApplication",
                newName: "IX_FriendApplication_FriendListId");

            migrationBuilder.AlterColumn<long>(
                name: "MaxPower",
                table: "Players",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friendship",
                table: "Friendship",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendApplication",
                table: "FriendApplication",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendApplication_FriendList_FriendListId",
                table: "FriendApplication",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendship_FriendList_FriendListId",
                table: "Friendship",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
