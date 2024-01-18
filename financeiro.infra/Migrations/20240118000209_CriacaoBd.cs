using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro.infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    IdCartao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCartao = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    DiaVencimentoFatura = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    FlExcluido = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.IdCartao);
                });

            migrationBuilder.CreateTable(
                name: "ContaPagar",
                columns: table => new
                {
                    IdContaPagar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParcelaAtual = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    TotalParcela = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    Descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FlCancelado = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IdCartao = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaPagar", x => x.IdContaPagar);
                    table.ForeignKey(
                        name: "FK_ContaPagar_Cartao_IdCartao",
                        column: x => x.IdCartao,
                        principalTable: "Cartao",
                        principalColumn: "IdCartao");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaPagar_IdCartao",
                table: "ContaPagar",
                column: "IdCartao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaPagar");

            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
