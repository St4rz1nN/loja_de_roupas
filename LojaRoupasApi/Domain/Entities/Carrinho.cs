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

        public ICollection<ItemCarrinho> Items { get; set; }

        public decimal Total => CalcularTotal();

        public Usuario Usuario { get; set; }
        public Compra Compra { get; set; }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.ValorTotal;
            }
            return total;
        }


    }
}
