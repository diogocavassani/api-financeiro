using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro.api.Migrations
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
                    DataVencimentoFatura = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.IdCartao);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartao");
        }
    }
}
