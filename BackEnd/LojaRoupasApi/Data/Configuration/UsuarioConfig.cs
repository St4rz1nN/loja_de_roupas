using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LojaRoupasApi.Data.Configuration
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder) {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Cpf).IsRequired();
            builder.Property(u => u.Datanascimento).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Senha).IsRequired();
        }
    }
}
