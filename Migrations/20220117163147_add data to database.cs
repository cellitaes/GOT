using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.Migrations
{
    public partial class adddatatodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tourists",
                columns: new[] { "IdT", "AppartNr", "City", "FlatNr", "Login", "Name", "Password", "PostCode", "Street", "Surname" },
                values: new object[] { 2, 9, "Wrocław", 2, "Janek1234", "Jan", "Haselko123", "59-243", "Kazimierska", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Tourists",
                columns: new[] { "IdT", "AppartNr", "City", "FlatNr", "Login", "Name", "Password", "PostCode", "Street", "Surname" },
                values: new object[] { 3, 9, "Wrocław", 2, "Janek12345", "Jan", "Haselko123", "59-243", "Kazimierska", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Tourists",
                columns: new[] { "IdT", "AppartNr", "City", "FlatNr", "Login", "Name", "Password", "PostCode", "Street", "Surname" },
                values: new object[] { 4, 9, "Wrocław", 2, "Janek123456", "Jan", "Haselko123", "59-243", "Kazimierska", "Kowalski" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tourists",
                keyColumn: "IdT",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tourists",
                keyColumn: "IdT",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tourists",
                keyColumn: "IdT",
                keyValue: 4);
        }
    }
}
