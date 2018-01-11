using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trails4Healthy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    DifficultyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.DifficultyId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contactos = table.Column<string>(nullable: true),
                    NomeEmpresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    NomeEstado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Turistas",
                columns: table => new
                {
                    TuristaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Morada = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Numero_Telefone = table.Column<string>(nullable: true),
                    Pass = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turistas", x => x.TuristaId);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Available = table.Column<bool>(nullable: false),
                    DifficultyId = table.Column<int>(nullable: false),
                    Distance = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailID);
                    table.ForeignKey(
                        name: "FK_Trails_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "DifficultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescricaoEquipamento = table.Column<string>(nullable: true),
                    Disponível = table.Column<bool>(nullable: false),
                    EmpresasEmpresaId = table.Column<int>(nullable: true),
                    NomeEquipamento = table.Column<string>(nullable: true),
                    QuantidadeEquip = table.Column<int>(nullable: false),
                    ValorUnidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoId);
                    table.ForeignKey(
                        name: "FK_Equipamento_Empresas_EmpresasEmpresaId",
                        column: x => x.EmpresasEmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaEquipamentos",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data_Reserva_Efetuada = table.Column<DateTime>(nullable: false),
                    Inicio_Reserva = table.Column<DateTime>(nullable: false),
                    TrilhoId = table.Column<int>(nullable: false),
                    TuristaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaEquipamentos", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_ReservaEquipamentos_Trails_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trails",
                        principalColumn: "TrailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaEquipamentos_Turistas_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turistas",
                        principalColumn: "TuristaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoReserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    CausaEstado = table.Column<string>(nullable: true),
                    DataFim_Reserva = table.Column<DateTime>(nullable: false),
                    DataInicio_Reserva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReserva", x => new { x.ReservaId, x.EstadoId });
                    table.ForeignKey(
                        name: "FK_EstadoReserva_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadoReserva_ReservaEquipamentos_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "ReservaEquipamentos",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Linha_Equipamento",
                columns: table => new
                {
                    ReservaId = table.Column<int>(nullable: false),
                    EquipamentoId = table.Column<int>(nullable: false),
                    LinhaEquipamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorParcial = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linha_Equipamento", x => new { x.ReservaId, x.EquipamentoId });
                    table.UniqueConstraint("AK_Linha_Equipamento_LinhaEquipamentoId", x => x.LinhaEquipamentoId);
                    table.ForeignKey(
                        name: "FK_Linha_Equipamento_Equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Linha_Equipamento_ReservaEquipamentos_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "ReservaEquipamentos",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_EmpresasEmpresaId",
                table: "Equipamento",
                column: "EmpresasEmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoReserva_EstadoId",
                table: "EstadoReserva",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Linha_Equipamento_EquipamentoId",
                table: "Linha_Equipamento",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaEquipamentos_TrilhoId",
                table: "ReservaEquipamentos",
                column: "TrilhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaEquipamentos_TuristaId",
                table: "ReservaEquipamentos",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_DifficultyId",
                table: "Trails",
                column: "DifficultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadoReserva");

            migrationBuilder.DropTable(
                name: "Linha_Equipamento");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "ReservaEquipamentos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Turistas");

            migrationBuilder.DropTable(
                name: "Difficulties");
        }
    }
}
