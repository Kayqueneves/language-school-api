using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageSchool.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "teachers",
                newName: "specialty");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "teachers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "teachers",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "guardians",
                newName: "student_id");

            migrationBuilder.CreateTable(
                name: "student_grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AssesmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_grades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teacher_languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_languages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_grades");

            migrationBuilder.DropTable(
                name: "teacher_languages");

            migrationBuilder.RenameColumn(
                name: "specialty",
                table: "teachers",
                newName: "Specialty");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "teachers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "teachers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "guardians",
                newName: "StudentId");
        }
    }
}
