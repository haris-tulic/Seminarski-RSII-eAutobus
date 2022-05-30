using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAutobus.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivGrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaStanovanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "TipKarte",
                columns: table => new
                {
                    TipKarteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKarte", x => x.TipKarteID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    UlogeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.UlogeID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaKarte",
                columns: table => new
                {
                    VrstaKarteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaKarte", x => x.VrstaKarteID);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    ZonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OznakaZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.ZonaID);
                });

            migrationBuilder.CreateTable(
                name: "Garaza",
                columns: table => new
                {
                    GarazaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivGaraze = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojGaraze = table.Column<int>(type: "int", nullable: false),
                    BrojMjesta = table.Column<int>(type: "int", nullable: false),
                    TrenutnoAutobusa = table.Column<int>(type: "int", nullable: false),
                    IsPopunjeno = table.Column<bool>(type: "bit", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garaza", x => x.GarazaID);
                    table.ForeignKey(
                        name: "FK_Garaza_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Stanica",
                columns: table => new
                {
                    StanicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivLokacijeStanice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanica", x => x.StanicaID);
                    table.ForeignKey(
                        name: "FK_Stanica_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresaStanovanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UlogeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Uloge_UlogeID",
                        column: x => x.UlogeID,
                        principalTable: "Uloge",
                        principalColumn: "UlogeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Autobus",
                columns: table => new
                {
                    AutobusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojAutobusa = table.Column<int>(type: "int", nullable: false),
                    BrojSjedista = table.Column<int>(type: "int", nullable: false),
                    DatumProizvodnje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ispravan = table.Column<bool>(type: "bit", nullable: false),
                    MarkaAutobusa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GarazaID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autobus", x => x.AutobusID);
                    table.ForeignKey(
                        name: "FK_Autobus_Garaza_GarazaID",
                        column: x => x.GarazaID,
                        principalTable: "Garaza",
                        principalColumn: "GarazaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cjenovnik",
                columns: table => new
                {
                    CjenovnikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaID = table.Column<int>(type: "int", nullable: false),
                    VrstaKarteID = table.Column<int>(type: "int", nullable: false),
                    TipkarteID = table.Column<int>(type: "int", nullable: false),
                    PolazisteID = table.Column<int>(type: "int", nullable: false),
                    OdredisteID = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cjenovnik", x => x.CjenovnikID);
                    table.ForeignKey(
                        name: "FK_Cjenovnik_Stanica_OdredisteID",
                        column: x => x.OdredisteID,
                        principalTable: "Stanica",
                        principalColumn: "StanicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cjenovnik_Stanica_PolazisteID",
                        column: x => x.PolazisteID,
                        principalTable: "Stanica",
                        principalColumn: "StanicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cjenovnik_TipKarte_TipkarteID",
                        column: x => x.TipkarteID,
                        principalTable: "TipKarte",
                        principalColumn: "TipKarteID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cjenovnik_VrstaKarte_VrstaKarteID",
                        column: x => x.VrstaKarteID,
                        principalTable: "VrstaKarte",
                        principalColumn: "VrstaKarteID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cjenovnik_Zona_ZonaID",
                        column: x => x.ZonaID,
                        principalTable: "Zona",
                        principalColumn: "ZonaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKarteID = table.Column<int>(type: "int", nullable: false),
                    PolazisteID = table.Column<int>(type: "int", nullable: false),
                    OdredisteID = table.Column<int>(type: "int", nullable: false),
                    VrstaKarteID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    NacinPlacanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.KartaID);
                    table.ForeignKey(
                        name: "FK_Karta_Stanica_OdredisteID",
                        column: x => x.OdredisteID,
                        principalTable: "Stanica",
                        principalColumn: "StanicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Karta_Stanica_PolazisteID",
                        column: x => x.PolazisteID,
                        principalTable: "Stanica",
                        principalColumn: "StanicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Karta_TipKarte_TipKarteID",
                        column: x => x.TipKarteID,
                        principalTable: "TipKarte",
                        principalColumn: "TipKarteID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Karta_VrstaKarte_VrstaKarteID",
                        column: x => x.VrstaKarteID,
                        principalTable: "VrstaKarte",
                        principalColumn: "VrstaKarteID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciUloge",
                columns: table => new
                {
                    KorisniciUlogeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UlogaID = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciUloge", x => x.KorisniciUlogeID);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KorisniciUloge_Uloge_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "UlogeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    VozacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VozackaKategorija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.VozacID);
                    table.ForeignKey(
                        name: "FK_Vozac_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KartaKupac",
                columns: table => new
                {
                    KartaKupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    KartaID = table.Column<int>(type: "int", nullable: false),
                    Aktivna = table.Column<bool>(type: "bit", nullable: false),
                    DatumVadjenjaKarte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVazenjaKarte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pravac = table.Column<bool>(type: "bit", nullable: false),
                    PravacS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartaKupac", x => x.KartaKupacID);
                    table.ForeignKey(
                        name: "FK_KartaKupac_Karta_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Karta",
                        principalColumn: "KartaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KartaKupac_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlatiKartu",
                columns: table => new
                {
                    PlatiKartuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KartaID = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    JeLiPlacena = table.Column<bool>(type: "bit", nullable: false),
                    DatumVadjenjaKarte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVazenjaKarte = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatiKartu", x => x.PlatiKartuID);
                    table.ForeignKey(
                        name: "FK_PlatiKartu_Karta_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Karta",
                        principalColumn: "KartaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlatiKartu_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AutobusVozac",
                columns: table => new
                {
                    AutobusVozacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Smjena = table.Column<int>(type: "int", nullable: false),
                    AutobusID = table.Column<int>(type: "int", nullable: false),
                    VozacID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutobusVozac", x => x.AutobusVozacID);
                    table.ForeignKey(
                        name: "FK_AutobusVozac_Autobus_AutobusID",
                        column: x => x.AutobusID,
                        principalTable: "Autobus",
                        principalColumn: "AutobusID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AutobusVozac_Vozac_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozac",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RasporedVoznje",
                columns: table => new
                {
                    RasporedVoznjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojLinije = table.Column<int>(type: "int", nullable: false),
                    AutobusID = table.Column<int>(type: "int", nullable: false),
                    PolazisteID = table.Column<int>(type: "int", nullable: false),
                    OdredisteID = table.Column<int>(type: "int", nullable: false),
                    VrijemePolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VrijemeDolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VozacID = table.Column<int>(type: "int", nullable: false),
                    KondukterID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalOcjena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporedVoznje", x => x.RasporedVoznjeID);
                    table.ForeignKey(
                        name: "FK_RasporedVoznje_Autobus_AutobusID",
                        column: x => x.AutobusID,
                        principalTable: "Autobus",
                        principalColumn: "AutobusID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RasporedVoznje_Stanica_OdredisteID",
                        column: x => x.OdredisteID,
                        principalTable: "Stanica",
                        principalColumn: "StanicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RasporedVoznje_Stanica_PolazisteID",
                        column: x => x.PolazisteID,
                        principalTable: "Stanica",
                        principalColumn: "StanicaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RasporedVoznje_Vozac_KondukterID",
                        column: x => x.KondukterID,
                        principalTable: "Vozac",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RasporedVoznje_Vozac_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozac",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    RecenzijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaUsluga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRecenzije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RasporedVoznjeID = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.RecenzijaID);
                    table.ForeignKey(
                        name: "FK_Recenzija_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Recenzija_RasporedVoznje_RasporedVoznjeID",
                        column: x => x.RasporedVoznjeID,
                        principalTable: "RasporedVoznje",
                        principalColumn: "RasporedVoznjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradID", "IsDeleted", "NazivGrada", "PostanskiBroj" },
                values: new object[,]
                {
                    { 1, false, "Sarajevo", 88000 },
                    { 2, false, "Mostar", 87000 },
                    { 3, false, "Konjic", 88400 }
                });

            migrationBuilder.InsertData(
                table: "Kupac",
                columns: new[] { "KupacID", "AdresaStanovanja", "BrojTelefona", "Email", "Ime", "IsDeleted", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime" },
                values: new object[,]
                {
                    { 1, "Zalik BB", "062333444", "kupac1@edu.fit.ba", "Kupac1", false, "kupac1", "/VEfw6wmtify1fOTuLBJrXHXo0I=", "ZneRfhOqwq8zu13rCRCrIQ==", "Kupac1" },
                    { 2, "Zalik BB", "062333555", "kupac2@edu.fit.ba", "Kupac2", false, "kupac2", "/VEfw6wmtify1fOTuLBJrXHXo0I=", "ZneRfhOqwq8zu13rCRCrIQ==", "Kupac2" }
                });

            migrationBuilder.InsertData(
                table: "TipKarte",
                columns: new[] { "TipKarteID", "Informacije", "IsDeleted", "Naziv" },
                values: new object[,]
                {
                    { 1, "Važi samo za studente uz priloženu potvrdu!", false, "Studentska" },
                    { 2, "Važi samo za radnike uz priloženu potvrdu!", false, "Radnička" },
                    { 3, "Važi samo za penzionere uz priloženu potvrdu!", false, "Penzionerska" }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogeID", "IsDeleted", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, false, "Admin", "Admin ima pristup svemu." },
                    { 2, false, "Vozač", "Vozač ima ograničen pristup." },
                    { 3, false, "Kondukter", "Kondukter ima ograničen pristup." }
                });

            migrationBuilder.InsertData(
                table: "VrstaKarte",
                columns: new[] { "VrstaKarteID", "Informacije", "IsDeleted", "Naziv" },
                values: new object[,]
                {
                    { 1, "Traje jedan dan!", false, "Dnevna" },
                    { 2, "Traje jedan mjesec!", false, "Mjesečna" },
                    { 3, "Traje jednu godinu!", false, "Godišnja" }
                });

            migrationBuilder.InsertData(
                table: "Zona",
                columns: new[] { "ZonaID", "IsDeleted", "OznakaZone" },
                values: new object[,]
                {
                    { 1, false, "Zona I" },
                    { 2, false, "Zona II" },
                    { 3, false, "Zona III" }
                });

            migrationBuilder.InsertData(
                table: "Garaza",
                columns: new[] { "GarazaID", "BrojGaraze", "BrojMjesta", "GradID", "IsDeleted", "IsPopunjeno", "NazivGaraze", "TrenutnoAutobusa" },
                values: new object[,]
                {
                    { 1, 1, 10, 1, false, false, "Garaža-Mostar", 1 },
                    { 2, 2, 10, 2, false, false, "Garaža-Sarajevo", 1 }
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "KorisnikID", "AdresaStanovanja", "BrojTelefona", "DatumRodjenja", "Email", "GradID", "Ime", "IsDeleted", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "UlogeID" },
                values: new object[,]
                {
                    { 1, "Zalik BB", "061222333", new DateTime(1995, 11, 1, 14, 29, 18, 167, DateTimeKind.Local).AddTicks(8190), "admin@gmail.com", 2, "Admin", false, "desktop", "/VEfw6wmtify1fOTuLBJrXHXo0I=", "ZneRfhOqwq8zu13rCRCrIQ==", "Admin", 1 },
                    { 2, "Zalik BB", "061444555", new DateTime(1995, 11, 1, 14, 29, 18, 167, DateTimeKind.Local).AddTicks(8190), "vozac1@gmail.com", 2, "Vozač1", false, "vozac1", "/VEfw6wmtify1fOTuLBJrXHXo0I=", "ZneRfhOqwq8zu13rCRCrIQ==", "Vozač1", 2 },
                    { 3, "Dolina Sunca BB", "061014555", new DateTime(1990, 10, 1, 14, 29, 18, 167, DateTimeKind.Local).AddTicks(8190), "vozac3@gmail.com", 2, "Vozač3", false, "vozac3", "/VEfw6wmtify1fOTuLBJrXHXo0I=", "ZneRfhOqwq8zu13rCRCrIQ==", "Vozač3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Stanica",
                columns: new[] { "StanicaID", "GradID", "IsDeleted", "NazivLokacijeStanice" },
                values: new object[,]
                {
                    { 1, 1, false, "Stanica-Sarajevo" },
                    { 2, 2, false, "Stanica-Mostar" }
                });

            migrationBuilder.InsertData(
                table: "Autobus",
                columns: new[] { "AutobusID", "BrojAutobusa", "BrojSjedista", "DatumProizvodnje", "GarazaID", "IsDeleted", "Ispravan", "MarkaAutobusa" },
                values: new object[,]
                {
                    { 1, 6, 55, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(7538), 1, false, true, "MAN" },
                    { 2, 10, 55, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(7609), 2, false, true, "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "Cjenovnik",
                columns: new[] { "CjenovnikID", "Cijena", "IsDeleted", "OdredisteID", "PolazisteID", "TipkarteID", "VrstaKarteID", "ZonaID" },
                values: new object[,]
                {
                    { 1, 5.0, false, 1, 2, 1, 1, 1 },
                    { 2, 40.0, false, 1, 2, 1, 2, 1 },
                    { 3, 8.0, false, 1, 2, 2, 1, 1 },
                    { 4, 60.0, false, 1, 2, 2, 2, 1 },
                    { 5, 6.0, false, 1, 2, 3, 1, 1 },
                    { 6, 50.0, false, 1, 2, 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Karta",
                columns: new[] { "KartaID", "Cijena", "IsDeleted", "NacinPlacanja", "OdredisteID", "PolazisteID", "TipKarteID", "VrstaKarteID" },
                values: new object[,]
                {
                    { 1, 5.0, false, "Preuzećem", 1, 2, 1, 1 },
                    { 2, 10.0, false, "Online", 2, 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "KorisniciUlogeID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(7980), 1, 1 },
                    { 2, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(7998), 2, 2 },
                    { 3, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8009), 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Vozac",
                columns: new[] { "VozacID", "IsDeleted", "KorisnikID", "VozackaKategorija" },
                values: new object[,]
                {
                    { 1, false, 2, "B,C,D,D1" },
                    { 2, false, 3, "B,C,D,D1" }
                });

            migrationBuilder.InsertData(
                table: "AutobusVozac",
                columns: new[] { "AutobusVozacID", "AutobusID", "IsDeleted", "Kraj", "Pocetak", "Smjena", "VozacID" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2022, 5, 31, 5, 55, 38, 652, DateTimeKind.Local).AddTicks(7634), new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(7631), 1, 1 },
                    { 2, 2, false, new DateTime(2022, 5, 31, 5, 55, 38, 652, DateTimeKind.Local).AddTicks(7655), new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(7652), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "KartaKupac",
                columns: new[] { "KartaKupacID", "Aktivna", "DatumVadjenjaKarte", "DatumVazenjaKarte", "KartaID", "KupacID", "Pravac", "PravacS" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8103), new DateTime(2022, 5, 31, 9, 55, 38, 652, DateTimeKind.Local).AddTicks(8106), 1, 1, true, "U jednom pravcu" },
                    { 2, true, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8121), new DateTime(2022, 6, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8124), 2, 2, true, "U oba pravca" }
                });

            migrationBuilder.InsertData(
                table: "PlatiKartu",
                columns: new[] { "PlatiKartuID", "Cijena", "DatumVadjenjaKarte", "DatumVazenjaKarte", "JeLiPlacena", "KartaID", "KupacID" },
                values: new object[] { 1, 10.0, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8194), new DateTime(2022, 6, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8197), true, 2, 2 });

            migrationBuilder.InsertData(
                table: "RasporedVoznje",
                columns: new[] { "RasporedVoznjeID", "AutobusID", "BrojLinije", "Datum", "FinalOcjena", "IsDeleted", "KondukterID", "OdredisteID", "PolazisteID", "VozacID", "VrijemeDolaska", "VrijemePolaska" },
                values: new object[,]
                {
                    { 1, 1, 6, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8220), 5m, false, 1, 2, 1, 1, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8228), new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8226) },
                    { 2, 2, 10, new DateTime(2022, 3, 1, 14, 29, 18, 167, DateTimeKind.Local).AddTicks(8190), 4m, false, 2, 1, 2, 2, new DateTime(2022, 3, 1, 14, 30, 0, 0, DateTimeKind.Local).AddTicks(8190), new DateTime(2022, 3, 1, 12, 15, 0, 0, DateTimeKind.Local).AddTicks(8190) }
                });

            migrationBuilder.InsertData(
                table: "Recenzija",
                columns: new[] { "RecenzijaID", "DatumRecenzije", "Komentar", "KupacID", "Ocjena", "RasporedVoznjeID", "VrstaUsluga" },
                values: new object[] { 1, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8256), "Sve pohvale!", 1, 5, 1, "Osoblje" });

            migrationBuilder.InsertData(
                table: "Recenzija",
                columns: new[] { "RecenzijaID", "DatumRecenzije", "Komentar", "KupacID", "Ocjena", "RasporedVoznjeID", "VrstaUsluga" },
                values: new object[] { 2, new DateTime(2022, 5, 30, 21, 55, 38, 652, DateTimeKind.Local).AddTicks(8274), "Nije očišćeno!", 2, 3, 2, "Vozilo" });

            migrationBuilder.CreateIndex(
                name: "IX_Autobus_GarazaID",
                table: "Autobus",
                column: "GarazaID");

            migrationBuilder.CreateIndex(
                name: "IX_AutobusVozac_AutobusID",
                table: "AutobusVozac",
                column: "AutobusID");

            migrationBuilder.CreateIndex(
                name: "IX_AutobusVozac_VozacID",
                table: "AutobusVozac",
                column: "VozacID");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenovnik_OdredisteID",
                table: "Cjenovnik",
                column: "OdredisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenovnik_PolazisteID",
                table: "Cjenovnik",
                column: "PolazisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenovnik_TipkarteID",
                table: "Cjenovnik",
                column: "TipkarteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenovnik_VrstaKarteID",
                table: "Cjenovnik",
                column: "VrstaKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenovnik_ZonaID",
                table: "Cjenovnik",
                column: "ZonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Garaza_GradID",
                table: "Garaza",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_OdredisteID",
                table: "Karta",
                column: "OdredisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_PolazisteID",
                table: "Karta",
                column: "PolazisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_TipKarteID",
                table: "Karta",
                column: "TipKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_VrstaKarteID",
                table: "Karta",
                column: "VrstaKarteID");

            migrationBuilder.CreateIndex(
                name: "IX_KartaKupac_KartaID",
                table: "KartaKupac",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_KartaKupac_KupacID",
                table: "KartaKupac",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_KorisnikID",
                table: "KorisniciUloge",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciUloge_UlogaID",
                table: "KorisniciUloge",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradID",
                table: "Korisnik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UlogeID",
                table: "Korisnik",
                column: "UlogeID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatiKartu_KartaID",
                table: "PlatiKartu",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatiKartu_KupacID",
                table: "PlatiKartu",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedVoznje_AutobusID",
                table: "RasporedVoznje",
                column: "AutobusID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedVoznje_KondukterID",
                table: "RasporedVoznje",
                column: "KondukterID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedVoznje_OdredisteID",
                table: "RasporedVoznje",
                column: "OdredisteID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedVoznje_PolazisteID",
                table: "RasporedVoznje",
                column: "PolazisteID");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedVoznje_VozacID",
                table: "RasporedVoznje",
                column: "VozacID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_KupacID",
                table: "Recenzija",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_RasporedVoznjeID",
                table: "Recenzija",
                column: "RasporedVoznjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Stanica_GradID",
                table: "Stanica",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozac_KorisnikID",
                table: "Vozac",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutobusVozac");

            migrationBuilder.DropTable(
                name: "Cjenovnik");

            migrationBuilder.DropTable(
                name: "KartaKupac");

            migrationBuilder.DropTable(
                name: "KorisniciUloge");

            migrationBuilder.DropTable(
                name: "PlatiKartu");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "RasporedVoznje");

            migrationBuilder.DropTable(
                name: "TipKarte");

            migrationBuilder.DropTable(
                name: "VrstaKarte");

            migrationBuilder.DropTable(
                name: "Autobus");

            migrationBuilder.DropTable(
                name: "Stanica");

            migrationBuilder.DropTable(
                name: "Vozac");

            migrationBuilder.DropTable(
                name: "Garaza");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}
