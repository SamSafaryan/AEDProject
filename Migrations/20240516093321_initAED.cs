using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEDProject.Migrations
{
    /// <inheritdoc />
    public partial class initAED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_DocumentTypes_DocumentTypeId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_DocumentTypeId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "strId",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "strId",
                table: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CountryDocumentType",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryDocumentType", x => new { x.CountriesId, x.DocumentTypesId });
                    table.ForeignKey(
                        name: "FK_CountryDocumentType_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryDocumentType_DocumentTypes_DocumentTypesId",
                        column: x => x.DocumentTypesId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryDocumentType_DocumentTypesId",
                table: "CountryDocumentType",
                column: "DocumentTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "CountryDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "strId",
                table: "DocumentTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "strId",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DocumentTypeId",
                table: "Countries",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_DocumentTypes_DocumentTypeId",
                table: "Countries",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
