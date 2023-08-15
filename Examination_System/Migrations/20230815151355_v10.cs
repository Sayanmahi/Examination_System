using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Institutes_InstituteId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubjectId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Teachers",
                newName: "SubId");

            migrationBuilder.RenameColumn(
                name: "InstituteId",
                table: "Teachers",
                newName: "InstId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                newName: "IX_Teachers_SubId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_InstituteId",
                table: "Teachers",
                newName: "IX_Teachers_InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Institutes_InstId",
                table: "Teachers",
                column: "InstId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubId",
                table: "Teachers",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Institutes_InstId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "SubId",
                table: "Teachers",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "InstId",
                table: "Teachers",
                newName: "InstituteId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_SubId",
                table: "Teachers",
                newName: "IX_Teachers_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_InstId",
                table: "Teachers",
                newName: "IX_Teachers_InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Institutes_InstituteId",
                table: "Teachers",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubjectId",
                table: "Teachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
