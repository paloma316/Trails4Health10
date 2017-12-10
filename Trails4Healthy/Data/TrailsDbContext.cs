using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Healthy.Models;

namespace Trails4Healthy.Data
{
    public class TrailsDbContext : DbContext
    {
        public TrailsDbContext(DbContextOptions<TrailsDbContext> options) : base(options) { }

        public DbSet<Trail> Trails { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        //Reserva de Equipamentos
        public DbSet<ReservaEquipamentos> ReservaEquipamentos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Estado_Reserva> EstadoReserva { get; set; }
        public DbSet<LoginClass> Turistas { get; set; }
        public DbSet<Linha_Equipamento_Reserva> Linha_Equipamento { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Chaves estrangeiras de Trails
            modelBuilder.Entity<Trail>()
                .HasOne(trail => trail.Difficulty)
                .WithMany(difficulty => difficulty.Trails)
                .HasForeignKey(trail => trail.DifficultyId);

            //chaves estrangeiras de Estado Reserva
            modelBuilder.Entity<Estado_Reserva>().HasKey(v=> new { v.ReservaId, v.EstadoId });
            //chaves estrangeiras de Linha reserva Equipamento
            modelBuilder.Entity<Linha_Equipamento_Reserva>().HasKey(v => new { v.ReservaId, v.EquipamentoId });

            //Estado Reserva
            modelBuilder.Entity<Estado_Reserva>()
                .HasOne(v => v.Estado)
                .WithMany(v=> v.EstadoReservas)
                .HasForeignKey(bc => bc.EstadoId);

            //Reserva Equipamento
            modelBuilder.Entity<ReservaEquipamentos>()
             .HasOne(v => v.Trails)
             .WithMany(v => v.reservaEquipamentos1)
             .HasForeignKey(bc => bc.TrilhoId);

            modelBuilder.Entity<ReservaEquipamentos>()
           .HasOne(v => v.Turistas)
           .WithMany(v => v.Reservas)
           .HasForeignKey(bc => bc.TuristaId);


            //Linha Equipamento reserva
            /**/
         modelBuilder.Entity<Linha_Equipamento_Reserva>()
        .HasOne(v => v.Reservas)
        .WithMany(v => v.Linha_Equipamento_Reserva)
        .HasForeignKey(bc => bc.ReservaId);

            /**/
            modelBuilder.Entity<Linha_Equipamento_Reserva>()
      .HasOne(v => v.Equipamentos)
      .WithMany(v => v.Linhas)
      .HasForeignKey(bc => bc.EquipamentoId);


            //Equipamento

            

            modelBuilder.Entity<Equipamento>()
     .HasOne(v => v.Empresas)
     .WithMany(v => v.Equipqmento)
     .HasForeignKey(bc => bc.EmpresaId);



        }


    }
}
