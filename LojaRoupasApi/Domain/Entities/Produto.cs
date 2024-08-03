using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Models
{
    public class Produto: Entity
    {   
        public Produto()
            => Id = Guid.NewGuid();
        public Produto(string nome, string tipo, string tamanho, string cor, decimal valor, string photo)
        {
            this.Nome = nome;
            this.Photo = photo;
            this.Tipo = tipo;
            this.Tamanho = tamanho;
            this.Cor = cor;
            this.Valor = valor;
        }

        public string Nome { get; set; }
        public string Photo { get; set; }

        public string Tipo { get; set; }

        public string Tamanho { get; set; }

        public string Cor { get; set; }

        public decimal Valor { get; set; }

        public ProdutoEstoque ProdutoEstoque { get; set; }
        public ICollection<ItemCarrinho> ItemCarrinhos { get; set; }
    }
}
