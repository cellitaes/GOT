using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.Migrations
{
    public partial class AddedPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "IdP", "Height", "IdL", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 1300.0, 1, 0.0, 0.0, "Rusinowa Polana" },
                    { 31, 1105.0, 5, 0.0, 0.0, "Stóg Izerski" },
                    { 30, 1066.0, 5, 0.0, 0.0, "Łącznik" },
                    { 29, 1124.0, 5, 0.0, 0.0, "Smrek (TPG Stóg Izerski)" },
                    { 28, 776.0, 5, 0.0, 0.0, "Czerniawska Kopa" },
                    { 27, 0.0, 5, 0.0, 0.0, "Czerniawa Zdrój" },
                    { 26, 364.0, 4, 0.0, 0.0, "Góra Dobrzeszowska" },
                    { 25, 449.0, 4, 0.0, 0.0, "Siniewska Góra" },
                    { 24, 0.0, 4, 0.0, 0.0, "Kuźniaki" },
                    { 23, 337.0, 4, 0.0, 0.0, "Kozłowa" },
                    { 22, 336.0, 4, 0.0, 0.0, "Buczyna" },
                    { 21, 347.0, 4, 0.0, 0.0, "Fajna ryba" },
                    { 20, 792.0, 3, 0.0, 0.0, "Dzielec" },
                    { 19, 0.0, 3, 0.0, 0.0, "Izby" },
                    { 18, 0.0, 3, 0.0, 0.0, "Banica" },
                    { 32, 965.0, 5, 0.0, 0.0, "Polana Izerska" },
                    { 17, 0.0, 3, 0.0, 0.0, "Mochnaczka Niżna" },
                    { 15, 403.0, 3, 0.0, 0.0, "Słona Góra" },
                    { 14, 384.0, 3, 0.0, 0.0, "Góra św. Marcina" },
                    { 13, 864.0, 2, 0.0, 0.0, "Mała Czantoria" },
                    { 12, 621.0, 2, 0.0, 0.0, "Schronisko PTTK Tuł" },
                    { 11, 0.0, 2, 0.0, 0.0, "Bażantowice" },
                    { 10, 521.0, 2, 0.0, 0.0, "Jasieniowa" },
                    { 9, 0.0, 2, 0.0, 0.0, "Cieszyn przez Mniszewo" },
                    { 8, 0.0, 2, 0.0, 0.0, "Dzięgielów - Zamek" },
                    { 7, 0.0, 1, 0.0, 0.0, "Psia Trawka" },
                    { 6, 0.0, 1, 0.0, 0.0, "Rówień Waksmundzka " },
                    { 5, 1489.0, 1, 0.0, 0.0, "Gęsia Szyja" },
                    { 4, 0.0, 1, 0.0, 0.0, "Łysa Polana" },
                    { 3, 1036.0, 1, 0.0, 0.0, "Wierch Porońca" },
                    { 2, 0.0, 1, 0.0, 0.0, "Dolina Filipka" },
                    { 16, 390.0, 3, 0.0, 0.0, "Trzemeska Góra" },
                    { 33, 998.0, 5, 0.0, 0.0, "Rozdroże pod Kopą" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Points",
                keyColumn: "IdP",
                keyValue: 33);
        }
    }
}
