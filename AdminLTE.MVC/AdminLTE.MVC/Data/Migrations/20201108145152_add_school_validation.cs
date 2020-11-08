using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class add_school_validation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Unit_UnitId",
                schema: "school",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Course_CourseId",
                schema: "school",
                table: "Unit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "school",
                table: "Unit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                schema: "school",
                table: "Unit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                schema: "school",
                table: "Exercise",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "school",
                table: "Exercise",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Unit_UnitId",
                schema: "school",
                table: "Exercise",
                column: "UnitId",
                principalSchema: "school",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Course_CourseId",
                schema: "school",
                table: "Unit",
                column: "CourseId",
                principalSchema: "school",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Unit_UnitId",
                schema: "school",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Course_CourseId",
                schema: "school",
                table: "Unit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "school",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                schema: "school",
                table: "Unit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                schema: "school",
                table: "Exercise",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "school",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Unit_UnitId",
                schema: "school",
                table: "Exercise",
                column: "UnitId",
                principalSchema: "school",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Course_CourseId",
                schema: "school",
                table: "Unit",
                column: "CourseId",
                principalSchema: "school",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
