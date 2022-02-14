using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.Migrations
{
    public partial class adddatatodatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leaders",
                columns: new[] { "NrLegitymacji", "IdT" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Leaders",
                columns: new[] { "NrLegitymacji", "IdT" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "IdU", "IdL", "NrLegitymacji" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "IdU", "IdL", "NrLegitymacji" },
                values: new object[] { 2, 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "NrLegitymacji",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "IdU",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "IdU",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "NrLegitymacji",
                keyValue: 1);
        }
    }
}
