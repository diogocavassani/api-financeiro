using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro.api.Migrations
{
    /// <inheritdoc />
    public partial class TrocaPropriedadeCartao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVencimentoFatura",
                table: "Cartao");

            migrationBuilder.AlterColumn<int>(
                name: "IdCartao",
                table: "ContaPagar",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "DiaVencimentoFatura",
                table: "Cartao",
                type: "INT",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaVencimentoFatura",
                table: "Cartao");

            migrationBuilder.AlterColumn<int>(
                name: "IdCartao",
                table: "ContaPagar",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimentoFatura",
                table: "Cartao",
                type: "DATETIME",
                nullable: true);
        }
    }
}
