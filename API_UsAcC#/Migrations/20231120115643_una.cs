using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_UsAcC_.Migrations
{
    public partial class una : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "gbp_operacional");

            migrationBuilder.CreateTable(
                name: "accesos",
                schema: "gbp_operacional",
                columns: table => new
                {
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo_acceso = table.Column<string>(type: "text", nullable: true),
                    descripcion_acceso = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accesos", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "gbp_operacional",
                columns: table => new
                {
                    id_usuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni_usuario = table.Column<string>(type: "text", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: true),
                    apellidos_usuario = table.Column<string>(type: "text", nullable: true),
                    tlf_usuario = table.Column<string>(type: "text", nullable: true),
                    email_usuario = table.Column<string>(type: "text", nullable: true),
                    clave_usuario = table.Column<string>(type: "text", nullable: false),
                    establoqueado_usuario = table.Column<bool>(type: "boolean", nullable: true),
                    fch_fin_bloqueo_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_alta_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    fch_baja_usuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    id_acceso = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_usuarios_accesos_id_acceso",
                        column: x => x.id_acceso,
                        principalSchema: "gbp_operacional",
                        principalTable: "accesos",
                        principalColumn: "id_acceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_acceso",
                schema: "gbp_operacional",
                table: "usuarios",
                column: "id_acceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "gbp_operacional");

            migrationBuilder.DropTable(
                name: "accesos",
                schema: "gbp_operacional");
        }
    }
}
