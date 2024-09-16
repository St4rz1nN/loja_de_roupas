using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;
using System.Security.Cryptography.X509Certificates;

namespace LojaRoupasApi.Domain.Models
{
    public class Compra : Entity
    {
        public Compra()
            => Id = Guid.NewGuid();

        public Compra(Guid idcarrinho, DateTime data, int situacao)
        {
            this.IdCarrinho = idcarrinho;
            this.Data = data;
            this.Situacao = situacao;
        }

        public Guid IdCarrinho { get; set; }
        public DateTime Data { get; set; }
        public int Situacao { get; set; }

        public Carrinho Carrinho { get; set; }

    }
}
