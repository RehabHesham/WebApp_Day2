using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Day2.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_Ins_ID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Ins_ID",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_Ins_ID",
                table: "Courses",
                column: "Ins_ID",
                principalTable: "Instructors",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_Ins_ID",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Ins_ID",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_Ins_ID",
                table: "Courses",
                column: "Ins_ID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
