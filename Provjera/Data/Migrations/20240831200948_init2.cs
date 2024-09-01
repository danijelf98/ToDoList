using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Provjera.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_AspNetUsers_ApplicationUserId1",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_ApplicationUserId1",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ToDoLists");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ToDoLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_ApplicationUserId",
                table: "ToDoLists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_AspNetUsers_ApplicationUserId",
                table: "ToDoLists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_AspNetUsers_ApplicationUserId",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_ApplicationUserId",
                table: "ToDoLists");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ToDoLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ToDoLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_ApplicationUserId1",
                table: "ToDoLists",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_AspNetUsers_ApplicationUserId1",
                table: "ToDoLists",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
