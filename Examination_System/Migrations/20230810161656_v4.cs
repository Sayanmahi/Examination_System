using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionSubject");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_QuestionId",
                table: "Subjects",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Questions_QuestionId",
                table: "Subjects",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Questions_QuestionId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_QuestionId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "QuestionSubject",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionSubject", x => new { x.QuestionsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_QuestionSubject_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSubject_SubjectsId",
                table: "QuestionSubject",
                column: "SubjectsId");
        }
    }
}
