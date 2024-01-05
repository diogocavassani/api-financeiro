using financeiro.dominio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace financeiro.infra.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<ContaPagar> ContasPagar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }


    }
}
