using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarksObts_Questions_QuesId",
                table: "MarksObts");

            migrationBuilder.DropIndex(
                name: "IX_MarksObts_QuesId",
                table: "MarksObts");

            migrationBuilder.DropColumn(
                name: "QuesId",
                table: "MarksObts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuesId",
                table: "MarksObts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MarksObts_QuesId",
                table: "MarksObts",
                column: "QuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarksObts_Questions_QuesId",
                table: "MarksObts",
                column: "QuesId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
