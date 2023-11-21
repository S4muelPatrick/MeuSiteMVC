using MeuSitemMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSitemMVC.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :  base(options )
        {
        }

        //I create a table without a primaryKey
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a tabela ContatoModel sem chave primária usando HasNoKey()
            modelBuilder.Entity<ContatoModel>()
                          .HasKey(c => c.Id); // Define a propriedade Id como chave primária;
            modelBuilder.Entity<ContatoModel>()
                          .Property(c => c.Id)
                          .ValueGeneratedOnAdd(); // Isso configura o Id para ser gerado automaticamente pelo banco de dados ao adicionar uma nova entidade

            modelBuilder.Entity<UsuarioModel>()
                        .HasKey(c => c.Id);
            modelBuilder.Entity<UsuarioModel>()
                          .Property(c => c.Id)
                          .ValueGeneratedOnAdd();
        }

        public DbSet<ContatoModel> Contato { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }

    }
}
