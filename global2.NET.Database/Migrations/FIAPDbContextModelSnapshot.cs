﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using global2.NET.Database;

#nullable disable

namespace global2.NET.Database.Migrations
{
    [DbContext(typeof(FIAPDbContext))]
    partial class FIAPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeviceEnergyLecture", b =>
                {
                    b.Property<long>("DevicesIdDisp")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("EnergyLecturesId")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("DevicesIdDisp", "EnergyLecturesId");

                    b.HasIndex("EnergyLecturesId");

                    b.ToTable("obter", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.Address", b =>
                {
                    b.Property<long>("IdEnde")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdEnde"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)");

                    b.Property<long>("UsuarioIdUsua")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IdEnde");

                    b.HasIndex("UsuarioIdUsua");

                    b.ToTable("endereco", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.ContactNumber", b =>
                {
                    b.Property<long>("IdTelef")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTelef"));

                    b.Property<string>("CodigoPais")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("NVARCHAR2(3)");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("NVARCHAR2(3)");

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<long>("UsuarioIdUsua")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IdTelef");

                    b.HasIndex("UsuarioIdUsua");

                    b.ToTable("telefone", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.Device", b =>
                {
                    b.Property<long>("IdDisp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdDisp"));

                    b.Property<string>("NomeDispositivo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("StatusDispositivo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("TipoDispositivo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<long>("UsuarioIdUsua")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IdDisp");

                    b.HasIndex("UsuarioIdUsua");

                    b.ToTable("dispositivo", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.EnergyLecture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Consumo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR2(40)");

                    b.Property<DateTime?>("DataLeitura")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ProducaoEnergia")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR2(40)");

                    b.HasKey("Id");

                    b.ToTable("leitura_energia", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.IncentiveScore", b =>
                {
                    b.Property<long>("IdPont")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdPont"));

                    b.Property<DateTime?>("DataPontuacao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<long>("MetaAlcancada")
                        .HasColumnType("NUMBER(19)");

                    b.Property<long>("PontosAdquiridos")
                        .HasColumnType("NUMBER(19)");

                    b.HasKey("IdPont");

                    b.ToTable("incentivo_pontuacao", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.OptimizationAlert", b =>
                {
                    b.Property<long>("IdAler")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdAler"));

                    b.Property<DateTime?>("DataAlerta")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<long>("TelefoneIdTelef")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("TipoAlerta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("IdAler");

                    b.HasIndex("TelefoneIdTelef");

                    b.ToTable("alerta_otimizacao", (string)null);
                });

            modelBuilder.Entity("global2.NET.Database.Models.PrincipalUser", b =>
                {
                    b.Property<long>("IdUsua")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdUsua"));

                    b.Property<string>("EmailUsua")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("NVARCHAR2(70)");

                    b.Property<long>("IncentiveScoreId")
                        .HasColumnType("NUMBER(19)");

                    b.Property<string>("NomeUsua")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("SenhaUsua")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("IdUsua");

                    b.HasIndex("IncentiveScoreId")
                        .IsUnique();

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("DeviceEnergyLecture", b =>
                {
                    b.HasOne("global2.NET.Database.Models.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesIdDisp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("global2.NET.Database.Models.EnergyLecture", null)
                        .WithMany()
                        .HasForeignKey("EnergyLecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("global2.NET.Database.Models.Address", b =>
                {
                    b.HasOne("global2.NET.Database.Models.PrincipalUser", "Usuario")
                        .WithMany("Addresses")
                        .HasForeignKey("UsuarioIdUsua")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("global2.NET.Database.Models.ContactNumber", b =>
                {
                    b.HasOne("global2.NET.Database.Models.PrincipalUser", "Usuario")
                        .WithMany("ContactNumbers")
                        .HasForeignKey("UsuarioIdUsua")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("global2.NET.Database.Models.Device", b =>
                {
                    b.HasOne("global2.NET.Database.Models.PrincipalUser", "Usuario")
                        .WithMany("Devices")
                        .HasForeignKey("UsuarioIdUsua")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("global2.NET.Database.Models.OptimizationAlert", b =>
                {
                    b.HasOne("global2.NET.Database.Models.ContactNumber", "Telefone")
                        .WithMany("OptimizationAlerts")
                        .HasForeignKey("TelefoneIdTelef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("global2.NET.Database.Models.PrincipalUser", b =>
                {
                    b.HasOne("global2.NET.Database.Models.IncentiveScore", "IncentiveScore")
                        .WithOne("Usuario")
                        .HasForeignKey("global2.NET.Database.Models.PrincipalUser", "IncentiveScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IncentiveScore");
                });

            modelBuilder.Entity("global2.NET.Database.Models.ContactNumber", b =>
                {
                    b.Navigation("OptimizationAlerts");
                });

            modelBuilder.Entity("global2.NET.Database.Models.IncentiveScore", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("global2.NET.Database.Models.PrincipalUser", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ContactNumbers");

                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
