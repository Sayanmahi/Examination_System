using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarksObts_Questions_QuestionId",
                table: "MarksObts");

            migrationBuilder.DropIndex(
                name: "IX_MarksObts_QuestionId",
                table: "MarksObts");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "MarksObts");

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
                name: "IX_MarksObts_QuesId",
                table: "MarksObts",
                column: "QuesId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSubject_SubjectsId",
                table: "QuestionSubject",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarksObts_Questions_QuesId",
                table: "MarksObts",
                column: "QuesId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarksObts_Questions_QuesId",
                table: "MarksObts");

            migrationBuilder.DropTable(
                name: "QuestionSubject");

            migrationBuilder.DropIndex(
                name: "IX_MarksObts_QuesId",
                table: "MarksObts");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "MarksObts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarksObts_QuestionId",
                table: "MarksObts",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarksObts_Questions_QuestionId",
                table: "MarksObts",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
