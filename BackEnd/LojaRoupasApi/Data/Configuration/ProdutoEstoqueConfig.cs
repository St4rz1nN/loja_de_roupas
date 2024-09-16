using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LojaRoupasApi.Data.Configuration
{
    public class ProdutoEstoqueConfig : IEntityTypeConfiguration<ProdutoEstoque>
    {
        public void Configure(EntityTypeBuilder<ProdutoEstoque> builder)
        {
            builder.HasKey(pe => pe.Id);
            builder.Property(pe => pe.IdProduto).IsRequired();
            builder.Property(pe => pe.Estoque).IsRequired();

            builder.HasOne(pe => pe.Produto)
                   .WithOne(p => p.ProdutoEstoque)
                   .HasForeignKey<ProdutoEstoque>(pe => pe.IdProduto)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
