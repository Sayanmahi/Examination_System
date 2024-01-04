using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class abcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SubId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "Teachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubId",
                table: "Teachers",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubId",
                table: "Teachers",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
