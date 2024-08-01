using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;
using System.Security.Cryptography.X509Certificates;

namespace LojaRoupasApi.Domain.Models
{
    public class Compra : Entity
    {
        public Compra()
            => Id = Guid.NewGuid();

        public Compra(Guid Idusuario, Guid idcarrinho, DateTime data, int situacao)
        {
            this.IdUsuario = Idusuario;
            this.IdCarrinho = idcarrinho;
            this.Data = data;
            this.Situacao = situacao;
        }

        public Guid IdUsuario { get; set; }
        public Guid IdCarrinho { get; set; }
        public DateTime Data { get; set; }
        public int Situacao { get; set; }

        public Usuario Usuario { get; set; }
        public Carrinho Carrinho { get; set; }

    }
}
