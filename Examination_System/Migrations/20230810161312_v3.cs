using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Subjects_SubjeId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_SubjeId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "SubjeId",
                table: "Branches");

            migrationBuilder.CreateTable(
                name: "BranchSubject",
                columns: table => new
                {
                    BranchesId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchSubject", x => new { x.BranchesId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_BranchSubject_Branches_BranchesId",
                        column: x => x.BranchesId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchSubject_SubjectsId",
                table: "BranchSubject",
                column: "SubjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchSubject");

            migrationBuilder.AddColumn<int>(
                name: "SubjeId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_SubjeId",
                table: "Branches",
                column: "SubjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Subjects_SubjeId",
                table: "Branches",
                column: "SubjeId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
