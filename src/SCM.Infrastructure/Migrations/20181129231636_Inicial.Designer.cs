﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCM.Infrastructure.Data;

namespace SCM.Infrastructure.Migrations
{
    [DbContext(typeof(SCMContext))]
    [Migration("20181129231636_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnType("Varchar(9)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("Varchar(400)");

                    b.Property<int>("ProprietarioId");

                    b.Property<string>("Rua")
                        .HasColumnType("Varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Multa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Pontuacao");

                    b.Property<decimal>("Valor");

                    b.Property<int?>("VeiculoId");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TbInfracao");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Proprietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Proprietario");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MarcaId");

                    b.Property<string>("Placa");

                    b.Property<int>("ProprietarioId");

                    b.Property<string>("Renavam");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("TbVeiculo");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Endereco", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Proprietario", "Proprietario")
                        .WithOne("Endereco")
                        .HasForeignKey("SCM.ApplicationCore.Entity.Endereco", "ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Multa", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Veiculo", "Veiculo")
                        .WithMany("Multa")
                        .HasForeignKey("VeiculoId");
                });

            modelBuilder.Entity("SCM.ApplicationCore.Entity.Veiculo", b =>
                {
                    b.HasOne("SCM.ApplicationCore.Entity.Marca", "Marca")
                        .WithMany("Veiculos")
                        .HasForeignKey("MarcaId");

                    b.HasOne("SCM.ApplicationCore.Entity.Proprietario", "Proprietario")
                        .WithMany("Veiculos")
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
