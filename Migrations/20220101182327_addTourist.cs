using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.Migrations
{
    public partial class addTourist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tourists",
                columns: new[] { "IdT", "AppartNr", "City", "FlatNr", "Login", "Name", "Password", "PostCode", "Street", "Surname" },
                values: new object[] { 1, 9, "Wrocław", 2, "Janek123", "Jan", "Haselko123", "59-243", "Kazimierska", "Kowalski" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tourists",
                keyColumn: "IdT",
                keyValue: 1);
        }
    }
}
