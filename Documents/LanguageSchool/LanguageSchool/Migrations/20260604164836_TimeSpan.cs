using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageSchool.Migrations
{
    /// <inheritdoc />
    public partial class TimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_classes",
                table: "classes");

            migrationBuilder.RenameTable(
                name: "classes",
                newName: "school_classes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_school_classes",
                table: "school_classes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_school_classes",
                table: "school_classes");

            migrationBuilder.RenameTable(
                name: "school_classes",
                newName: "classes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_classes",
                table: "classes",
                column: "Id");
        }
    }
}
