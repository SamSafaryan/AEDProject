using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEDProject.Migrations
{
    /// <inheritdoc />
    public partial class AEDinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Documents_DocumentId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "strId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Documents_DocumentId",
                table: "Images",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Documents_DocumentId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "strId",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Documents_DocumentId",
                table: "Images",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }
    }
}
