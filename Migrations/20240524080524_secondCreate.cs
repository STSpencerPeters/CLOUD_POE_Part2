using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD_POE_Part2.Migrations
{
    /// <inheritdoc />
    public partial class secondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Products_ProductID",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Admins_AdminID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AdminID",
                table: "Product",
                newName: "IX_Product_AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID",
                table: "Order",
                newName: "IX_Order_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProductID",
                table: "Item",
                newName: "IX_Item_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrderID",
                table: "Item",
                newName: "IX_Item_OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Order_OrderID",
                table: "Item",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Product_ProductID",
                table: "Item",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Admin_AdminID",
                table: "Product",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Order_OrderID",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Product_ProductID",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Admin_AdminID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AdminID",
                table: "Products",
                newName: "IX_Products_AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerID",
                table: "Orders",
                newName: "IX_Orders_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProductID",
                table: "Items",
                newName: "IX_Items_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Item_OrderID",
                table: "Items",
                newName: "IX_Items_OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrderID",
                table: "Items",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Products_ProductID",
                table: "Items",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Admins_AdminID",
                table: "Products",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
