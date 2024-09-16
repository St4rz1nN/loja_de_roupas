using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRoupasApi.Data.Configuration
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {

        public void Configure(EntityTypeBuilder<Produto> builder) {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Tipo).IsRequired();
            builder.Property(p => p.Tamanho).IsRequired();
            builder.Property(p => p.Cor).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
        }
    }
}
