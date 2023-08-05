using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Day2.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dept_id",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Department_dept_id",
                table: "Instructors",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Department_dept_id",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "dept_id",
                table: "Instructors");
        }
    }
}
