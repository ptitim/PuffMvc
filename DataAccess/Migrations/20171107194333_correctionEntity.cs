using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccess.Migrations
{
    public partial class correctionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId1",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId1",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeLength",
                table: "Movies",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Adresses",
                type: "int",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Votes",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeLength",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Adresses",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId1",
                table: "Votes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId1",
                table: "Votes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
