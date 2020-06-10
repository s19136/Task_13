using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace task13.Migrations
{
    public partial class Notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Order",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 1,
                columns: new[] { "DateAccepted", "DateFinished", "Notes" },
                values: new object[] { new DateTime(2020, 6, 10, 16, 17, 29, 605, DateTimeKind.Local).AddTicks(98), new DateTime(2020, 6, 10, 16, 17, 29, 608, DateTimeKind.Local).AddTicks(6458), "fast" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 2,
                columns: new[] { "DateAccepted", "DateFinished", "Notes" },
                values: new object[] { new DateTime(2020, 6, 10, 16, 17, 29, 608, DateTimeKind.Local).AddTicks(7860), new DateTime(2020, 6, 10, 16, 17, 29, 608, DateTimeKind.Local).AddTicks(7896), "for Gustavus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 1,
                columns: new[] { "DateAccepted", "DateFinished" },
                values: new object[] { new DateTime(2020, 6, 9, 23, 42, 59, 319, DateTimeKind.Local).AddTicks(2063), new DateTime(2020, 6, 9, 23, 42, 59, 323, DateTimeKind.Local).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "IdOrder",
                keyValue: 2,
                columns: new[] { "DateAccepted", "DateFinished" },
                values: new object[] { new DateTime(2020, 6, 9, 23, 42, 59, 323, DateTimeKind.Local).AddTicks(4835), new DateTime(2020, 6, 9, 23, 42, 59, 323, DateTimeKind.Local).AddTicks(4861) });
        }
    }
}
