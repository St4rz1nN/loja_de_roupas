using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Dto.Base;
using LojaRoupasApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Dto
{
    public class ItemCarrinhoDto : BaseDto
    {

        public ItemCarrinhoDto()
            => Id = Guid.NewGuid();
        public ItemCarrinhoDto(Guid idcarrinho, Guid idproduto, int quantia)
        {
            this.IdCarrinho = idcarrinho;
            this.IdProduto = idproduto;
            this.Quantia = quantia;
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo IDCarrinho é Obrigatorio!")]
        public Guid IdCarrinho { get; set; }
        [Required(ErrorMessage = "O Campo IDProduto é Obrigatorio!")]
        public Guid IdProduto { get; set; }
        [Required(ErrorMessage = "O Campo Quantia é Obrigatorio!")]
        public int Quantia { get; set; }

        public CarrinhoDto Carrinho { get; set; }
        public ProdutoDto Produto { get; set; }
    }
}
