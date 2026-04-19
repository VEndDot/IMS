using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Plugins.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialWriteOffEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material_write_off",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Master_id = table.Column<int>(type: "int", nullable: false),
                    Write_off_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_write_off", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_write_off_User_account_Master_id",
                        column: x => x.Master_id,
                        principalTable: "User_account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_write_off_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Write_off_id = table.Column<int>(type: "int", nullable: false),
                    Nomenclature_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(12,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_write_off_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_write_off_item_Material_nomenclature_Nomenclature_id",
                        column: x => x.Nomenclature_id,
                        principalTable: "Material_nomenclature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Material_write_off_item_Material_write_off_Write_off_id",
                        column: x => x.Write_off_id,
                        principalTable: "Material_write_off",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_write_off_Date",
                table: "Material_write_off",
                column: "Write_off_date");

            migrationBuilder.CreateIndex(
                name: "IX_Material_write_off_Master_id",
                table: "Material_write_off",
                column: "Master_id");

            migrationBuilder.CreateIndex(
                name: "IX_Material_write_off_item_Nomenclature_id",
                table: "Material_write_off_item",
                column: "Nomenclature_id");

            migrationBuilder.CreateIndex(
                name: "IX_Material_write_off_item_Write_off_id",
                table: "Material_write_off_item",
                column: "Write_off_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material_write_off_item");

            migrationBuilder.DropTable(
                name: "Material_write_off");
        }
    }
}
