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
        public DbSet<ItemCarrinho> ItemCarrinhos { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoEstoqueConfig());
            modelBuilder.ApplyConfiguration(new CarrinhoConfig());
            modelBuilder.ApplyConfiguration(new ItemCarrinhoConfig());
            modelBuilder.ApplyConfiguration(new CompraConfig());


            base.OnModelCreating(modelBuilder);

            IList<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d003b"), "Camisa Basica", "Camisa", "G", "Preto", 129, null));
            produtos.Add(new Produto(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d004b"), "Camisa Basica", "Camisa", "P", "Branco", 129, null));
            produtos.Add(new Produto(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d005b"), "Camisa Basica", "Camisa", "PP", "Branco", 129, null));
            produtos.Add(new Produto(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d006b"), "Camisa Basica", "Camisa", "PP", "Amarelo", 129, null));
            produtos.Add(new Produto(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d007b"), "Camisa Basica", "Camisa", "M", "Azul", 129, null));
            produtos.Add(new Produto(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d008b"), "Camisa Basica Luxo", "Camisa", "M", "Azul", 129, null));

            modelBuilder.Entity<Produto>().HasData(produtos);

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(
            "server=localhost; Port=3306; Database=lojaroupas; Uid=root; Pwd=mb123157;"
        );
    }
}
