using financeiro.dominio.Entidades;
using financeiro.dominio.Entidades.ContasPagar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace financeiro.infra.Mapeamento.ContasPagar
{
    public class ContaPagarCartaoMap : IEntityTypeConfiguration<ContaPagarCartao>
    {
        public void Configure(EntityTypeBuilder<ContaPagarCartao> builder)
        {
            builder.Property(p => p.IdCartao)
                .HasColumnName("IdCartao")
                .HasColumnType("INT");

            builder.HasBaseType<ContaPagar>();

            builder.HasOne(p => p.Cartao)
                .WithMany(p => p.ContasPagar)
                .HasForeignKey(p => p.IdCartao).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
