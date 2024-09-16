using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Models
{
    public class ProdutoEstoque : Entity
    {

        public ProdutoEstoque()
            => Id = Guid.NewGuid();

        public ProdutoEstoque(Guid idproduto, int estoque)
        {
            this.IdProduto = idproduto;
            this.Estoque = estoque;
        }

        public Guid IdProduto { get; set; }

        public int Estoque { get; set; }

        public Produto Produto { get; set; }

    }
}
