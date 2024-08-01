using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRoupasApi.Data.Configuration
{
    public class ItemCarrinhoConfig : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.HasKey(ic => ic.Id);
            builder.Property(ic => ic.IdCarrinho).IsRequired();
            builder.Property(ic => ic.IdProduto).IsRequired();
            builder.Property(ic => ic.Quantia).IsRequired();

            builder.HasOne(ic => ic.Carrinho)
                   .WithMany(c => c.Items)
                   .HasForeignKey(ic => ic.IdCarrinho)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ic => ic.Produto)
                   .WithMany(p => p.ItemCarrinhos)
                   .HasForeignKey(ic => ic.IdProduto)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
