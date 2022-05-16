using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addarabic4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Filter_Option",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name_Ar",
                table: "Filter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Filter_Option");

            migrationBuilder.DropColumn(
                name: "Name_Ar",
                table: "Filter");
        }
    }
}
