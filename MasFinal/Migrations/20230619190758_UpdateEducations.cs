using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasFinal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEducations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Employees_EmployeeId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EmployeeId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Educations");

            migrationBuilder.CreateTable(
                name: "EducationEmployee",
                columns: table => new
                {
                    EducationsId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationEmployee", x => new { x.EducationsId, x.EmployeeListId });
                    table.ForeignKey(
                        name: "FK_EducationEmployee_Educations_EducationsId",
                        column: x => x.EducationsId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationEmployee_Employees_EmployeeListId",
                        column: x => x.EmployeeListId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationEmployee_EmployeeListId",
                table: "EducationEmployee",
                column: "EmployeeListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationEmployee");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Educations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EmployeeId",
                table: "Educations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Employees_EmployeeId",
                table: "Educations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
