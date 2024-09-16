using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRoupasApi.Data.Configuration
{
    public class CompraConfig : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.HasKey(co => co.Id);
            builder.Property(co => co.IdCarrinho).IsRequired();
            builder.Property(co => co.Data).IsRequired();
            builder.Property(co => co.Situacao).IsRequired();

            builder.HasOne(co => co.Carrinho)
                   .WithOne(c => c.Compra)
                   .HasForeignKey<Compra>(co => co.IdCarrinho)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
