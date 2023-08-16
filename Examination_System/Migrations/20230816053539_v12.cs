using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "SubId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubId",
                table: "Questions",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubId",
                table: "Questions",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
