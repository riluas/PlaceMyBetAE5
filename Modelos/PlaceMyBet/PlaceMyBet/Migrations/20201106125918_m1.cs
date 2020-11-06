using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBet.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<string>(nullable: true),
                    Equipo_local = table.Column<string>(nullable: true),
                    Equipo_visitante = table.Column<string>(nullable: true),
                    Goles_totales = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OverUnder = table.Column<double>(nullable: false),
                    Cuota_over = table.Column<double>(nullable: false),
                    Cuota_under = table.Column<double>(nullable: false),
                    Apostado_over = table.Column<double>(nullable: false),
                    Apostado_under = table.Column<double>(nullable: false),
                    EventoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    CuentaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_banco = table.Column<string>(nullable: true),
                    Num_tarjeta = table.Column<double>(nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    UsuarioID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<string>(nullable: true),
                    Cuota = table.Column<double>(nullable: false),
                    Tipo_apuesta = table.Column<string>(nullable: true),
                    Dinero_apostado = table.Column<double>(nullable: false),
                    MercadoID = table.Column<int>(nullable: false),
                    UsuarioEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaId);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_MercadoID",
                        column: x => x.MercadoID,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalTable: "Usuarios",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "Equipo_local", "Equipo_visitante", "Fecha", "Goles_totales" },
                values: new object[,]
                {
                    { 1, "Valencia", "Barcelona", "2020-04-08", 5 },
                    { 2, "Valencia", "Madrid", "2020-04-08", 7 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Email", "Apellidos", "Edad", "Nombre" },
                values: new object[,]
                {
                    { "ejemplo@ejemplo.es", "Lucas", 21, "Ricardo" },
                    { "ejemplo2@ejemplo2.es", "Lucas", 22, "Ricardo2" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaId", "Nombre_banco", "Num_tarjeta", "Saldo", "UsuarioID" },
                values: new object[] { 1, "Mibanco", 55555555.0, 800.0, "ejemplo@ejemplo.es" });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "Apostado_over", "Apostado_under", "Cuota_over", "Cuota_under", "EventoID", "OverUnder" },
                values: new object[,]
                {
                    { 1, 700.0, 700.0, 1.8999999999999999, 1.8999999999999999, 1, 1.5 },
                    { 3, 100.0, 200.0, 1.8999999999999999, 1.8999999999999999, 1, 1.0 },
                    { 2, 100.0, 100.0, 1.8999999999999999, 1.3999999999999999, 2, 1.5 }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero_apostado", "Fecha", "MercadoID", "Tipo_apuesta", "UsuarioEmail" },
                values: new object[] { 1, 1.8999999999999999, 200.0, "2020-11-05 14:57:16", 1, "Over", "ejemplo@ejemplo.es" });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero_apostado", "Fecha", "MercadoID", "Tipo_apuesta", "UsuarioEmail" },
                values: new object[] { 2, 1.5, 100.0, "2020-11-05 14:57:16", 1, "under", "ejemplo@ejemplo.es" });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "Cuota", "Dinero_apostado", "Fecha", "MercadoID", "Tipo_apuesta", "UsuarioEmail" },
                values: new object[] { 3, 1.78, 50.0, "2020-11-05 14:57:16", 1, "Over", "ejemplo@ejemplo.es" });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_MercadoID",
                table: "Apuestas",
                column: "MercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioEmail",
                table: "Apuestas",
                column: "UsuarioEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioID",
                table: "Cuentas",
                column: "UsuarioID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoID",
                table: "Mercados",
                column: "EventoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
