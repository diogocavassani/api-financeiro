using financeiro.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace financeiro.api.Data.Mappings
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");

            builder.HasKey(p => p.IdCartao);

            builder.Property(p => p.IdCartao)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.NomeCartao)
                .IsRequired()
                .HasColumnName("NomeCartao")
                .HasColumnType("Varchar")
                .HasMaxLength(50);
            builder.Property(p => p.DataVencimentoFatura)
                .HasColumnName("DataVencimentoFatura")
                .HasColumnType("DATETIME");
            builder.Property(p => p.DataVencimentoFatura)
                .HasColumnName("DataVencimentoFatura")
                .HasColumnType("DATETIME");
            builder.Property(p => p.FlExcluido)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("FlExcluido")
                .HasColumnType("BIT");
        }
    }
}
