﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Trails4Healthy.Data;

namespace Trails4Healthy.Migrations
{
    [DbContext(typeof(TrailsDbContext))]
    [Migration("20180111003730_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Healthy.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DifficultyId");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contactos");

                    b.Property<string>("NomeEmpresa");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Equipamento", b =>
                {
                    b.Property<int>("EquipamentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescricaoEquipamento");

                    b.Property<bool>("Disponível");

                    b.Property<int?>("EmpresasEmpresaId");

                    b.Property<string>("NomeEquipamento");

                    b.Property<int>("QuantidadeEquip");

                    b.Property<decimal>("ValorUnidade");

                    b.HasKey("EquipamentoId");

                    b.HasIndex("EmpresasEmpresaId");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("NomeEstado");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Estado_Reserva", b =>
                {
                    b.Property<int>("ReservaId");

                    b.Property<int>("EstadoId");

                    b.Property<string>("CausaEstado");

                    b.Property<DateTime>("DataFim_Reserva");

                    b.Property<DateTime>("DataInicio_Reserva");

                    b.HasKey("ReservaId", "EstadoId");

                    b.HasIndex("EstadoId");

                    b.ToTable("EstadoReserva");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Linha_Equipamento_Reserva", b =>
                {
                    b.Property<int>("ReservaId");

                    b.Property<int>("EquipamentoId");

                    b.Property<int>("LinhaEquipamentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("ValorParcial");

                    b.HasKey("ReservaId", "EquipamentoId");

                    b.HasAlternateKey("LinhaEquipamentoId");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("Linha_Equipamento");
                });

            modelBuilder.Entity("Trails4Healthy.Models.LoginClass", b =>
                {
                    b.Property<int>("TuristaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Morada");

                    b.Property<string>("Nome");

                    b.Property<string>("Numero_Telefone");

                    b.Property<string>("Pass");

                    b.Property<string>("username");

                    b.HasKey("TuristaId");

                    b.ToTable("Turistas");
                });

            modelBuilder.Entity("Trails4Healthy.Models.ReservaEquipamentos", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data_Reserva_Efetuada");

                    b.Property<DateTime>("Inicio_Reserva");

                    b.Property<int>("TrilhoId");

                    b.Property<int>("TuristaId");

                    b.HasKey("ReservaId");

                    b.HasIndex("TrilhoId");

                    b.HasIndex("TuristaId");

                    b.ToTable("ReservaEquipamentos");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Trail", b =>
                {
                    b.Property<int>("TrailID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Available");

                    b.Property<int>("DifficultyId");

                    b.Property<string>("Distance");

                    b.Property<string>("Name");

                    b.HasKey("TrailID");

                    b.HasIndex("DifficultyId");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Equipamento", b =>
                {
                    b.HasOne("Trails4Healthy.Models.Empresa", "Empresas")
                        .WithMany("Equipqmento")
                        .HasForeignKey("EmpresasEmpresaId");
                });

            modelBuilder.Entity("Trails4Healthy.Models.Estado_Reserva", b =>
                {
                    b.HasOne("Trails4Healthy.Models.Estado", "Estado")
                        .WithMany("EstadoReservas")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Healthy.Models.ReservaEquipamentos", "Reservas")
                        .WithMany("Estado_Reserva")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Healthy.Models.Linha_Equipamento_Reserva", b =>
                {
                    b.HasOne("Trails4Healthy.Models.Equipamento", "Equipamentos")
                        .WithMany("Linhas")
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Healthy.Models.ReservaEquipamentos", "Reservas")
                        .WithMany("Linha_Equipamento_Reserva")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Healthy.Models.ReservaEquipamentos", b =>
                {
                    b.HasOne("Trails4Healthy.Models.Trail", "Trails")
                        .WithMany("reservaEquipamentos1")
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Healthy.Models.LoginClass", "Turistas")
                        .WithMany("Reservas")
                        .HasForeignKey("TuristaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Healthy.Models.Trail", b =>
                {
                    b.HasOne("Trails4Healthy.Models.Difficulty", "Difficulty")
                        .WithMany("Trails")
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
