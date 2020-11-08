using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class add_school : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school");

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "school",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                schema: "school",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "school",
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                schema: "school",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "school",
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_UnitId",
                schema: "school",
                table: "Exercise",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_CourseId",
                schema: "school",
                table: "Unit",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise",
                schema: "school");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "school");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "school");
        }
    }
}
