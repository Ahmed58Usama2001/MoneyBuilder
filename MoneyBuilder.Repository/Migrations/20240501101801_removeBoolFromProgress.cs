using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyBuilder.Repository.Migrations
{
    /// <inheritdoc />
    public partial class removeBoolFromProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLectureOpened",
                table: "UsersProgress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLectureOpened",
                table: "UsersProgress",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
