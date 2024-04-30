using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyBuilder.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Lectures_LectureId",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Lectures_LectureId",
                table: "Questions",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Lectures_LectureId",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Lectures_LectureId",
                table: "Questions",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id");
        }
    }
}
