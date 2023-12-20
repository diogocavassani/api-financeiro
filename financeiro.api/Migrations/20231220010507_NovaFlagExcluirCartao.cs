using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financeiro.api.Migrations
{
    /// <inheritdoc />
    public partial class NovaFlagExcluirCartao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FlExcluido",
                table: "Cartao",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlExcluido",
                table: "Cartao");
        }
    }
}
