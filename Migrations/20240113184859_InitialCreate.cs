using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patricia_Adelina_web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeGen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vizionator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Localitate = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizionator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: true),
                    PretBilet = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    GenID = table.Column<int>(type: "int", nullable: true),
                    OrarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_Actor_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Film_Gen_GenID",
                        column: x => x.GenID,
                        principalTable: "Gen",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Film_Orar_OrarID",
                        column: x => x.OrarID,
                        principalTable: "Orar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ActorFilm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false),
                    GenID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorFilm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActorFilm_Actor_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorFilm_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorFilm_Gen_GenID",
                        column: x => x.GenID,
                        principalTable: "Gen",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vizionare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VizionatorID = table.Column<int>(type: "int", nullable: true),
                    FilmID = table.Column<int>(type: "int", nullable: true),
                    DataVizionare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizionare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vizionare_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vizionare_Vizionator_VizionatorID",
                        column: x => x.VizionatorID,
                        principalTable: "Vizionator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorFilm_ActorID",
                table: "ActorFilm",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_ActorFilm_FilmID",
                table: "ActorFilm",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_ActorFilm_GenID",
                table: "ActorFilm",
                column: "GenID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ActorID",
                table: "Film",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_GenID",
                table: "Film",
                column: "GenID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_OrarID",
                table: "Film",
                column: "OrarID");

            migrationBuilder.CreateIndex(
                name: "IX_Vizionare_FilmID",
                table: "Vizionare",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Vizionare_VizionatorID",
                table: "Vizionare",
                column: "VizionatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorFilm");

            migrationBuilder.DropTable(
                name: "Vizionare");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Vizionator");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Gen");

            migrationBuilder.DropTable(
                name: "Orar");
        }
    }
}
