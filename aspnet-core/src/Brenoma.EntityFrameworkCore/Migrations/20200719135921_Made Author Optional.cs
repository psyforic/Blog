using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brenoma.Migrations
{
    public partial class MadeAuthorOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AppAuthors_AuthorId",
                table: "AppPosts");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "AppPosts",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AppAuthors_AuthorId",
                table: "AppPosts",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AppAuthors_AuthorId",
                table: "AppPosts");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "AppPosts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AppAuthors_AuthorId",
                table: "AppPosts",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
