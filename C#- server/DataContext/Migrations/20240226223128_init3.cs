using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Languages_languageId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "toDate",
                table: "Vacations",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "fromDate",
                table: "Vacations",
                newName: "FromDate");

            migrationBuilder.RenameColumn(
                name: "languageId",
                table: "Tasks",
                newName: "LanguageId");

            migrationBuilder.RenameColumn(
                name: "IdlLanguage",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_languageId",
                table: "Tasks",
                newName: "IX_Tasks_LanguageId");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Languages_LanguageId",
                table: "Tasks",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Languages_LanguageId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Vacations",
                newName: "toDate");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "Vacations",
                newName: "fromDate");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Tasks",
                newName: "languageId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "IdlLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_LanguageId",
                table: "Tasks",
                newName: "IX_Tasks_languageId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Languages_languageId",
                table: "Tasks",
                column: "languageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
