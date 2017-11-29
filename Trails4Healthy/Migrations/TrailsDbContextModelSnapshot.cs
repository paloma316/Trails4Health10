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
    partial class TrailsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Trails4Healthy.Models.ReservaEquipamentos", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data_Reserva_Efetuada");

                    b.Property<DateTime>("Inicio_Reserva");

                    b.Property<int>("TrilhoId");

                    b.Property<int>("TuristaId");

                    b.HasKey("ReservaId");

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
