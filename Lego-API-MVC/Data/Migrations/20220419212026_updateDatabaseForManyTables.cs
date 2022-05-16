using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateDatabaseForManyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter_Product",
                table: "Product_Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Image",
                table: "Product_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter_Category",
                table: "Filter_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Product_Wishlist",
                table: "Customer_Product_Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Product_Review",
                table: "Customer_Product_Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Product",
                table: "Customer_Product");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product_Option",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Prod_Image",
                table: "Product_Image",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product_Image",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Filter_Category",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customer_Product_Wishlist",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customer_Product_Review",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customer_Product",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter_Product",
                table: "Product_Option",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Image",
                table: "Product_Image",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter_Category",
                table: "Filter_Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Product_Wishlist",
                table: "Customer_Product_Wishlist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Product_Review",
                table: "Customer_Product_Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Product",
                table: "Customer_Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Option_Prod_ID",
                table: "Product_Option",
                column: "Prod_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Image_Prod_ID",
                table: "Product_Image",
                column: "Prod_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_Category_Cat_ID",
                table: "Filter_Category",
                column: "Cat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Product_Wishlist_Wish_ID",
                table: "Customer_Product_Wishlist",
                column: "Wish_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Product_Review_Prod_ID",
                table: "Customer_Product_Review",
                column: "Prod_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Product_Prod_ID",
                table: "Customer_Product",
                column: "Prod_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter_Product",
                table: "Product_Option");

            migrationBuilder.DropIndex(
                name: "IX_Product_Option_Prod_ID",
                table: "Product_Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Image",
                table: "Product_Image");

            migrationBuilder.DropIndex(
                name: "IX_Product_Image_Prod_ID",
                table: "Product_Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter_Category",
                table: "Filter_Category");

            migrationBuilder.DropIndex(
                name: "IX_Filter_Category_Cat_ID",
                table: "Filter_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Product_Wishlist",
                table: "Customer_Product_Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Product_Wishlist_Wish_ID",
                table: "Customer_Product_Wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Product_Review",
                table: "Customer_Product_Review");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Product_Review_Prod_ID",
                table: "Customer_Product_Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Product",
                table: "Customer_Product");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Product_Prod_ID",
                table: "Customer_Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product_Option");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product_Image");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Filter_Category");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer_Product_Wishlist");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer_Product_Review");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer_Product");

            migrationBuilder.AlterColumn<string>(
                name: "Prod_Image",
                table: "Product_Image",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldUnicode: false,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter_Product",
                table: "Product_Option",
                columns: new[] { "Prod_ID", "Filter_Option_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Image",
                table: "Product_Image",
                columns: new[] { "Prod_ID", "Prod_Image" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter_Category",
                table: "Filter_Category",
                columns: new[] { "Cat_ID", "Filter_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Product_Wishlist",
                table: "Customer_Product_Wishlist",
                columns: new[] { "Wish_ID", "Cust_ID", "Prod_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Product_Review",
                table: "Customer_Product_Review",
                columns: new[] { "Prod_ID", "Review_ID", "Cust_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Product",
                table: "Customer_Product",
                columns: new[] { "Prod_ID", "Cust_ID" });
        }
    }
}
