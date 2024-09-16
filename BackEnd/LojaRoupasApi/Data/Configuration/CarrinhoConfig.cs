using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRoupasApi.Data.Configuration
{
    public class CarrinhoConfig : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdUsuario).IsRequired();


            builder.HasOne(c => c.Usuario)
                   .WithMany(u => u.Carrinhos)
                   .HasForeignKey(c => c.IdUsuario)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Compra)
                   .WithOne(co => co.Carrinho)
                   .HasForeignKey<Carrinho>(c => c.IdCompra)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
