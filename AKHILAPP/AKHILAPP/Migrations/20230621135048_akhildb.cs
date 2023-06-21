using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AKHILAPP.Migrations
{
    /// <inheritdoc />
    public partial class akhildb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_Masters",
                columns: table => new
                {
                    CatMasterId = table.Column<int>(name: "CatMaster_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(name: "Cat_Name", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Masters", x => x.CatMasterId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Masters",
                columns: table => new
                {
                    ProdMasterId = table.Column<int>(name: "ProdMaster_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdName = table.Column<string>(name: "Prod_Name", type: "nvarchar(max)", nullable: true),
                    CatmasterId = table.Column<int>(name: "Catmaster_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Masters", x => x.ProdMasterId);
                    table.ForeignKey(
                        name: "FK_Product_Masters_Category_Masters_Catmaster_Id",
                        column: x => x.CatmasterId,
                        principalTable: "Category_Masters",
                        principalColumn: "CatMaster_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Masters_Catmaster_Id",
                table: "Product_Masters",
                column: "Catmaster_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Masters");

            migrationBuilder.DropTable(
                name: "Category_Masters");
        }
    }
}
