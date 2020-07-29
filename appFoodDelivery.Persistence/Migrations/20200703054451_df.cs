﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class df : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productcuisinemaster_AspNetUsers_storeid",
                table: "productcuisinemaster");

            migrationBuilder.DropIndex(
                name: "IX_productcuisinemaster_storeid",
                table: "productcuisinemaster");

            migrationBuilder.DropColumn(
                name: "storeid",
                table: "productcuisinemaster");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "productcuisinemaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productcuisinemaster_ApplicationUserId",
                table: "productcuisinemaster",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_productcuisinemaster_AspNetUsers_ApplicationUserId",
                table: "productcuisinemaster",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productcuisinemaster_AspNetUsers_ApplicationUserId",
                table: "productcuisinemaster");

            migrationBuilder.DropIndex(
                name: "IX_productcuisinemaster_ApplicationUserId",
                table: "productcuisinemaster");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "productcuisinemaster");

            migrationBuilder.AddColumn<string>(
                name: "storeid",
                table: "productcuisinemaster",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productcuisinemaster_storeid",
                table: "productcuisinemaster",
                column: "storeid");

            migrationBuilder.AddForeignKey(
                name: "FK_productcuisinemaster_AspNetUsers_storeid",
                table: "productcuisinemaster",
                column: "storeid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
