using financeiro.dominio.Entidades;
using financeiro.dominio.Entidades.ContasPagar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace financeiro.infra.Mapeamento
{
    public class ContaPagarMap : IEntityTypeConfiguration<ContaPagar>
    {
        public void Configure(EntityTypeBuilder<ContaPagar> builder)
        {
            builder.ToTable("ContaPagar");

            builder.HasKey(p => p.IdContaPagar);

            //Configuração do discriminator
            builder.HasDiscriminator(p => p.TipoContaPagar);

            builder.Property(p => p.ParcelaAtual)
                .HasColumnName("TipoContaPagar")
                .IsRequired()
                .HasColumnType("INT")
                .HasDefaultValue(0);

            builder.Property(p => p.IdContaPagar)
                .ValueGeneratedOnAdd()
                .HasColumnName("IdContaPagar")
                .UseIdentityColumn();

            builder.Property(p => p.ParcelaAtual)
                .HasColumnName("ParcelaAtual")
                .IsRequired()
                .HasColumnType("INT")
                .HasDefaultValue(1);

            builder.Property(p => p.TotalParcela)
                .HasColumnName("TotalParcela")
                .IsRequired()
                .HasColumnType("INT")
                .HasDefaultValue(1);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Valor)
                .HasColumnName("Valor")
                .IsRequired()
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(p => p.DataLancamento)
                .HasColumnName("DataLancamento")
                .HasColumnType("DATETIME");

            builder.Property(p => p.DataVencimento)
                .HasColumnName("DataVencimento")
                .HasColumnType("DATETIME");

            builder.Property(p => p.FlCancelado)
                .HasColumnName("FlCancelado")
                .IsRequired()
                .HasColumnType("BIT")
                .HasDefaultValue(false);

            

        }
    }
}
