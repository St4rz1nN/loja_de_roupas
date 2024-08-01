using LojaRoupasApi.Data.Configuration;
using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaRoupasApi.Data.Context
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoEstoqueConfig());
            modelBuilder.ApplyConfiguration(new CarrinhoConfig());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoConfig());
            modelBuilder.ApplyConfiguration(new CompraConfig());


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(
            "server=localhost; Port=3306; Database=lojaroupas; Uid=root; Pwd=mb123157;"
        );
    }
}
