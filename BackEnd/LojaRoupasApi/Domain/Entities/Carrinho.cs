using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;

namespace LojaRoupasApi.Domain.Models
{
    public class Carrinho : Entity
    {

        public Carrinho()
            => Id= Guid.NewGuid();

        public Carrinho(Guid IdUsuario)
        {
            this.IdUsuario = IdUsuario;
            Items = new List<ItemCarrinho>();
        }

        public Guid IdUsuario { get; set; }

        public Guid IdCompra { get; set; }
        public ICollection<ItemCarrinho> Items { get; set; }

        public decimal Total;

        public Usuario Usuario { get; set; }
        public Compra Compra { get; set; }


    }
}
