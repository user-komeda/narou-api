using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NarouBackend.Migrations
{
    /// <inheritdoc />
    public partial class addUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItemsEntity_AspNetUsers_userId",
                table: "StockItemsEntity");

            migrationBuilder.DropIndex(
                name: "IX_StockItemsEntity_Ncode",
                table: "StockItemsEntity");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "StockItemsEntity",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StockItemsEntity_userId",
                table: "StockItemsEntity",
                newName: "IX_StockItemsEntity_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemsEntity_Ncode_UserId",
                table: "StockItemsEntity",
                columns: new[] { "Ncode", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockItemsEntity_AspNetUsers_UserId",
                table: "StockItemsEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItemsEntity_AspNetUsers_UserId",
                table: "StockItemsEntity");

            migrationBuilder.DropIndex(
                name: "IX_StockItemsEntity_Ncode_UserId",
                table: "StockItemsEntity");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StockItemsEntity",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_StockItemsEntity_UserId",
                table: "StockItemsEntity",
                newName: "IX_StockItemsEntity_userId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemsEntity_Ncode",
                table: "StockItemsEntity",
                column: "Ncode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockItemsEntity_AspNetUsers_userId",
                table: "StockItemsEntity",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
