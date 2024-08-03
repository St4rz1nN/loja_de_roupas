using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;

namespace LojaRoupasApi.Domain.Models
{
    public class ItemCarrinho : Entity
    {
        public ItemCarrinho()
            => Id = Guid.NewGuid();
        public Guid IdCarrinho { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantia { get; set; }
        public Carrinho Carrinho { get; set; }
        public Produto Produto { get; set; }

    }
}
