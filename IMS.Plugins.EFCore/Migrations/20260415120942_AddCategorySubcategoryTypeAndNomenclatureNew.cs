using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySubcategoryTypeAndNomenclatureNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material_subcategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_subcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_subcategory_Material_category_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Material_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Subcategory_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_type_Material_subcategory_Subcategory_id",
                        column: x => x.Subcategory_id,
                        principalTable: "Material_subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material_nomenclature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GOST = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cross_section = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "м"),
                    Current_stock = table.Column<decimal>(type: "decimal(12,3)", nullable: false, defaultValue: 0m),
                    Type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_nomenclature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_nomenclature_Material_type_Type_id",
                        column: x => x.Type_id,
                        principalTable: "Material_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_nomenclature_SKU",
                table: "Material_nomenclature",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Material_nomenclature_Type_Name",
                table: "Material_nomenclature",
                columns: new[] { "Type_id", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Material_subcategory_Category_id",
                table: "Material_subcategory",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Material_type_Subcategory_id",
                table: "Material_type",
                column: "Subcategory_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material_nomenclature");

            migrationBuilder.DropTable(
                name: "Material_type");

            migrationBuilder.DropTable(
                name: "Material_subcategory");

            migrationBuilder.DropTable(
                name: "Material_category");
        }
    }
}
