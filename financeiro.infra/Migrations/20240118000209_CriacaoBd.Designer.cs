﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using financeiro.infra.Contexto;

#nullable disable

namespace financeiro.infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240118000209_CriacaoBd")]
    partial class CriacaoBd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("financeiro.dominio.Entidades.Cartao", b =>
                {
                    b.Property<int>("IdCartao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCartao"));

                    b.Property<int>("DiaVencimentoFatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(1)
                        .HasColumnName("DiaVencimentoFatura");

                    b.Property<bool>("FlExcluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("FlExcluido");

                    b.Property<string>("NomeCartao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar")
                        .HasColumnName("NomeCartao");

                    b.HasKey("IdCartao");

                    b.ToTable("Cartao", (string)null);
                });

            modelBuilder.Entity("financeiro.dominio.Entidades.ContaPagar", b =>
                {
                    b.Property<int>("IdContaPagar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdContaPagar");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContaPagar"));

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataLancamento");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataVencimento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("FlCancelado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("FlCancelado");

                    b.Property<int?>("IdCartao")
                        .HasColumnType("INT")
                        .HasColumnName("IdCartao");

                    b.Property<int>("ParcelaAtual")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(1)
                        .HasColumnName("ParcelaAtual");

                    b.Property<int>("TotalParcela")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasDefaultValue(1)
                        .HasColumnName("TotalParcela");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,2)")
                        .HasColumnName("Valor");

                    b.HasKey("IdContaPagar");

                    b.HasIndex("IdCartao");

                    b.ToTable("ContaPagar", (string)null);
                });

            modelBuilder.Entity("financeiro.dominio.Entidades.ContaPagar", b =>
                {
                    b.HasOne("financeiro.dominio.Entidades.Cartao", "Cartao")
                        .WithMany("ContasPagar")
                        .HasForeignKey("IdCartao")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Cartao");
                });

            modelBuilder.Entity("financeiro.dominio.Entidades.Cartao", b =>
                {
                    b.Navigation("ContasPagar");
                });
#pragma warning restore 612, 618
        }
    }
}
