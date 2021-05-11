using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CW10___Kolokwium.Migrations
{
    public partial class newInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    idChampionship = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.idChampionship);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    idTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MaxAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.idTeam);
                });

            migrationBuilder.CreateTable(
                name: "championship_Teams",
                columns: table => new
                {
                    idChampionshipTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    idChampionship = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_championship_Teams", x => x.idChampionshipTeam);
                    table.ForeignKey(
                        name: "FK_championship_Teams_Championships_idChampionship",
                        column: x => x.idChampionship,
                        principalTable: "Championships",
                        principalColumn: "idChampionship",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_championship_Teams_Teams_idTeam",
                        column: x => x.idTeam,
                        principalTable: "Teams",
                        principalColumn: "idTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                columns: table => new
                {
                    idPlayerTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPlayer = table.Column<int>(type: "int", nullable: false),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    NumOnShirt = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => x.idPlayerTeam);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_idPlayer",
                        column: x => x.idPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_idTeam",
                        column: x => x.idTeam,
                        principalTable: "Teams",
                        principalColumn: "idTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "idChampionship", "OfficialName", "Year" },
                values: new object[,]
                {
                    { 1, "euro2016", 2016 },
                    { 2, "mundial", 2012 },
                    { 3, "euro2012", 2012 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "IdPlayer", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josef", "Zbaznik" },
                    { 2, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pawlo", "Karsik" },
                    { 3, new DateTime(2007, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hadol", "Ajtler" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "idTeam", "MaxAge", "TeamName" },
                values: new object[,]
                {
                    { 1, 18, "Legia" },
                    { 2, 20, "Lech" },
                    { 3, 16, "Wisła" }
                });

            migrationBuilder.InsertData(
                table: "PlayerTeams",
                columns: new[] { "idPlayerTeam", "Comment", "NumOnShirt", "idPlayer", "idTeam" },
                values: new object[,]
                {
                    { 1, null, 0, 1, 1 },
                    { 2, null, 0, 2, 1 },
                    { 3, null, 0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "championship_Teams",
                columns: new[] { "idChampionshipTeam", "Score", "idChampionship", "idTeam" },
                values: new object[,]
                {
                    { 1, 1f, 1, 1 },
                    { 3, 3f, 3, 1 },
                    { 2, 2f, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_championship_Teams_idChampionship",
                table: "championship_Teams",
                column: "idChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_championship_Teams_idTeam",
                table: "championship_Teams",
                column: "idTeam");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_idPlayer",
                table: "PlayerTeams",
                column: "idPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_idTeam",
                table: "PlayerTeams",
                column: "idTeam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "championship_Teams");

            migrationBuilder.DropTable(
                name: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
