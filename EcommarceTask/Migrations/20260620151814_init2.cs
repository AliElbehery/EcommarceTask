using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommarceTask.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingAdresses_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAdresses_Customers_CustomerId",
                table: "ShippingAdresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAdresses",
                table: "ShippingAdresses");

            migrationBuilder.RenameTable(
                name: "ShippingAdresses",
                newName: "ShippingAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAdresses_CustomerId",
                table: "ShippingAddresses",
                newName: "IX_ShippingAddresses_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe" },
                    { 2, "Jana.Smith@example.com", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone", 699.99m },
                    { 2, 1, "Laptop", 999.99m },
                    { 3, 2, "T-Shirt", 19.99m },
                    { 4, 2, "Jeans", 49.99m },
                    { 5, 3, "Novel", 14.99m },
                    { 6, 3, "Biography", 24.99m }
                });

            migrationBuilder.InsertData(
                table: "ShippingAddresses",
                columns: new[] { "Id", "City", "CustomerId", "Street" },
                values: new object[,]
                {
                    { 1, "New York", null, "123 Main St" },
                    { 2, "Los Angeles", null, "456 Elm St" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, null, 10.00m, 1, 2 },
                    { 2, null, 20.00m, 2, 1 },
                    { 3, null, 15.00m, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "ShippingAddressId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 100m },
                    { 2, 2, 2, 200m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId",
                principalTable: "ShippingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Customers_CustomerId",
                table: "ShippingAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Customers_CustomerId",
                table: "ShippingAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "ShippingAddresses",
                newName: "ShippingAdresses");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAddresses_CustomerId",
                table: "ShippingAdresses",
                newName: "IX_ShippingAdresses_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAdresses",
                table: "ShippingAdresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingAdresses_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId",
                principalTable: "ShippingAdresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAdresses_Customers_CustomerId",
                table: "ShippingAdresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
