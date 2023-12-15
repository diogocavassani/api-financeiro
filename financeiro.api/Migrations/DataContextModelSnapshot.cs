﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using financeiro.api.Data;

#nullable disable

namespace financeiro.api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("financeiro.api.Models.Cartao", b =>
                {
                    b.Property<int>("IdCartao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCartao"));

                    b.Property<DateTime?>("DataVencimentoFatura")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataVencimentoFatura");

                    b.Property<string>("NomeCartao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar")
                        .HasColumnName("NomeCartao");

                    b.HasKey("IdCartao");

                    b.ToTable("Cartao", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
