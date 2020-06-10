using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task13.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionery",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdCustomer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false),
                    IdConfectionery = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdConfectionery, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Confectionery_IdConfectionery",
                        column: x => x.IdConfectionery,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Confectionery",
                columns: new[] { "IdConfectionery", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Chocolate cake", 13.33, "For head" },
                    { 2, "Cheesecake", 6.6600000000000001, "For soul" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "IdCustomer", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Gustavus", "Adolfus" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "IdEmployee", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Steven", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdCustomer", "IdEmployee" },
                values: new object[] { 1, new DateTime(2020, 6, 9, 23, 42, 59, 319, DateTimeKind.Local).AddTicks(2063), new DateTime(2020, 6, 9, 23, 42, 59, 323, DateTimeKind.Local).AddTicks(4248), 1, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "IdOrder", "DateAccepted", "DateFinished", "IdCustomer", "IdEmployee" },
                values: new object[] { 2, new DateTime(2020, 6, 9, 23, 42, 59, 323, DateTimeKind.Local).AddTicks(4835), new DateTime(2020, 6, 9, 23, 42, 59, 323, DateTimeKind.Local).AddTicks(4861), 2, 1 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 1, 1, "yum", 1 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 2, 1, "eww", 1 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfectionery", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 2, 2, "nice", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCustomer",
                table: "Order",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployee",
                table: "Order",
                column: "IdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order");

            migrationBuilder.DropTable(
                name: "Confectionery");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
