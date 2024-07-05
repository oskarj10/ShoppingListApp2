using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp.Data.Migrations
{
    
    public partial class Auth : Migration
    {
       
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingItems",
                table: "ShoppingItems");

            migrationBuilder.RenameTable(
                name: "ShoppingItems",
                newName: "ShoppingListItems");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "ShoppingProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShoppingListItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "ShoppingListItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShoppingDate",
                table: "ShoppingListItems",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListItems",
                table: "ShoppingListItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingProducts_OwnerId",
                table: "ShoppingProducts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_OwnerId",
                table: "ShoppingListItems",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListItems_AspNetUsers_OwnerId",
                table: "ShoppingListItems",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingProducts_AspNetUsers_OwnerId",
                table: "ShoppingProducts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingProducts_ShoppingItems_ShoppingListId",
                table: "ShoppingProducts",
                column: "ShoppingListId",
                principalTable: "ShoppingListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "ShoppingProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "ShoppingListItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

      
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListItems_AspNetUsers_OwnerId",
                table: "ShoppingListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingProducts_AspNetUsers_OwnerId",
                table: "ShoppingProducts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingProducts_OwnerId",
                table: "ShoppingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListItems",
                table: "ShoppingListItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListItems_OwnerId",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ShoppingProducts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ShoppingListItems");

            migrationBuilder.DropColumn(
                name: "ShoppingDate",
                table: "ShoppingListItems");

           
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "ShoppingProducts");

            migrationBuilder.RenameTable(
                name: "ShoppingListItems",
                newName: "ShoppingItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingItems",
                table: "ShoppingItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingProducts_ShoppingItems_ShoppingListId",
                table: "ShoppingProducts",
                column: "ShoppingListId",
                principalTable: "ShoppingItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "ShoppingListItems");
        }
    }
}
