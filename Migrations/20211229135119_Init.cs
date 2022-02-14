using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GOT.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MountRanges",
                columns: table => new
                {
                    IdL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountRanges", x => x.IdL);
                });

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    IdT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    City = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AppartNr = table.Column<int>(type: "int", nullable: false),
                    FlatNr = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.IdT);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    IdW = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    VerifStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.IdW);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    IdP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    IdL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.IdP);
                    table.ForeignKey(
                        name: "FK_Points_MountRanges_IdL",
                        column: x => x.IdL,
                        principalTable: "MountRanges",
                        principalColumn: "IdL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    NrLegitymacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.NrLegitymacji);
                    table.ForeignKey(
                        name: "FK_Leaders_Tourists_IdT",
                        column: x => x.IdT,
                        principalTable: "Tourists",
                        principalColumn: "IdT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    IdTr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdW = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.IdTr);
                    table.ForeignKey(
                        name: "FK_Routes_Trips_IdW",
                        column: x => x.IdW,
                        principalTable: "Trips",
                        principalColumn: "IdW",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    IdO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    HeightDiff = table.Column<double>(type: "float", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    PointStartId = table.Column<int>(type: "int", nullable: false),
                    PointEndId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.IdO);
                    table.ForeignKey(
                        name: "FK_Tracks_Points_PointEndId",
                        column: x => x.PointEndId,
                        principalTable: "Points",
                        principalColumn: "IdP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracks_Points_PointStartId",
                        column: x => x.PointStartId,
                        principalTable: "Points",
                        principalColumn: "IdP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    IdU = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrLegitymacji = table.Column<int>(type: "int", nullable: false),
                    IdL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.IdU);
                    table.ForeignKey(
                        name: "FK_Permissions_Leaders_NrLegitymacji",
                        column: x => x.NrLegitymacji,
                        principalTable: "Leaders",
                        principalColumn: "NrLegitymacji",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_MountRanges_IdL",
                        column: x => x.IdL,
                        principalTable: "MountRanges",
                        principalColumn: "IdL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    IdWp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdO = table.Column<int>(type: "int", nullable: false),
                    IdTr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.IdWp);
                    table.ForeignKey(
                        name: "FK_Entries_Routes_IdTr",
                        column: x => x.IdTr,
                        principalTable: "Routes",
                        principalColumn: "IdTr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Tracks_IdO",
                        column: x => x.IdO,
                        principalTable: "Tracks",
                        principalColumn: "IdO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoredTracks",
                columns: table => new
                {
                    IdS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoredTracks", x => x.IdS);
                    table.ForeignKey(
                        name: "FK_ScoredTracks_Tracks_IdO",
                        column: x => x.IdO,
                        principalTable: "Tracks",
                        principalColumn: "IdO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MountRanges",
                columns: new[] { "IdL", "Name" },
                values: new object[,]
                {
                    { 1, "Tatry" },
                    { 2, "Beskidy Zachodnie" },
                    { 3, "Beskidy Wschodnie" },
                    { 4, "Góry Świętokrzyskie" },
                    { 5, "Sudety" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_IdO",
                table: "Entries",
                column: "IdO");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_IdTr",
                table: "Entries",
                column: "IdTr");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_IdT",
                table: "Leaders",
                column: "IdT");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_IdL",
                table: "Permissions",
                column: "IdL");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_NrLegitymacji",
                table: "Permissions",
                column: "NrLegitymacji");

            migrationBuilder.CreateIndex(
                name: "IX_Points_IdL",
                table: "Points",
                column: "IdL");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_IdW",
                table: "Routes",
                column: "IdW");

            migrationBuilder.CreateIndex(
                name: "IX_ScoredTracks_IdO",
                table: "ScoredTracks",
                column: "IdO");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PointEndId",
                table: "Tracks",
                column: "PointEndId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PointStartId",
                table: "Tracks",
                column: "PointStartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ScoredTracks");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "MountRanges");
        }
    }
}
