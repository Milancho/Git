using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class addedDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "school",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "school",
                table: "Unit");
        }
    }
}
