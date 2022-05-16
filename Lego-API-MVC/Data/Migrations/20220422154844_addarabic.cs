using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addarabic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prod_Descreption_Ar",
                table: "Product",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prod_Name_Ar",
                table: "Product",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CatName_Ar",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prod_Descreption_Ar",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Prod_Name_Ar",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CatName_Ar",
                table: "Category");
        }
    }
}
