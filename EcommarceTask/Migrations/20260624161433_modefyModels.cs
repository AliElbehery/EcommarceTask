using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommarceTask.Migrations
{
    /// <inheritdoc />
    public partial class modefyModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ShippingAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ShippingAddresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingAddresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_CustomerId",
                table: "ShippingAddresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Customers_CustomerId",
                table: "ShippingAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Customers_CustomerId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_CustomerId",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShippingAddresses");

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_ShippingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "ShippingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_ShippingAddressId",
                table: "CustomerAddresses",
                column: "ShippingAddressId");
        }
    }
}
