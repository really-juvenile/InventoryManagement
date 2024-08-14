using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Transactions",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Suppliers",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Products",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InventoryID",
                table: "Transactions",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductID",
                table: "Transactions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_InventoryID",
                table: "Suppliers",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryID",
                table: "Products",
                column: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Inventories_InventoryID",
                table: "Products",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Inventories_InventoryID",
                table: "Suppliers",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Inventories_InventoryID",
                table: "Transactions",
                column: "InventoryID",
                principalTable: "Inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Inventories_InventoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Inventories_InventoryID",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Inventories_InventoryID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_InventoryID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ProductID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_InventoryID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Products");
        }
    }
}
