using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Frontline.Migrations
{
    public partial class friend3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendApplications_FriendList_FriendListId",
                table: "FriendApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendList_Players_PlayerId",
                table: "FriendList");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendList_FriendListId",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendList",
                table: "FriendList");

            migrationBuilder.RenameTable(
                name: "FriendList",
                newName: "FriendLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendLists",
                table: "FriendLists",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_PlayerId",
                table: "FriendLists",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendApplications_FriendLists_FriendListId",
                table: "FriendApplications",
                column: "FriendListId",
                principalTable: "FriendLists",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendLists_FriendListId",
                table: "Friendships",
                column: "FriendListId",
                principalTable: "FriendLists",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendApplications_FriendLists_FriendListId",
                table: "FriendApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendLists_FriendListId",
                table: "Friendships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendLists",
                table: "FriendLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendLists_PlayerId",
                table: "FriendLists");

            migrationBuilder.RenameTable(
                name: "FriendLists",
                newName: "FriendList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendList",
                table: "FriendList",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendApplications_FriendList_FriendListId",
                table: "FriendApplications",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendList_Players_PlayerId",
                table: "FriendList",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendList_FriendListId",
                table: "Friendships",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
