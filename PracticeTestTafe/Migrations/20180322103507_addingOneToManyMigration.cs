using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PracticeTestTafe.Migrations
{
    public partial class addingOneToManyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductTbl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbl_CategoryId",
                table: "ProductTbl",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTbl_CategoryTbl_CategoryId",
                table: "ProductTbl",
                column: "CategoryId",
                principalTable: "CategoryTbl",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTbl_CategoryTbl_CategoryId",
                table: "ProductTbl");

            migrationBuilder.DropIndex(
                name: "IX_ProductTbl_CategoryId",
                table: "ProductTbl");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductTbl");
        }
    }
}
