﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_writer_article_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Articles",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_WriterId",
                table: "Articles",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Writers_WriterId",
                table: "Articles",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Writers_WriterId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_WriterId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Articles");
        }
    }
}
