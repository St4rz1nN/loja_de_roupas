using LojaRoupasApi.Domain.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Dto
{
    public class ProdutoEstoqueDto : BaseDto
    {

        public ProdutoEstoqueDto()
            => Id= Guid.NewGuid();

        public ProdutoEstoqueDto(Guid idproduto, int estoque)
        {
            this.IdProduto = idproduto;
            this.Estoque = estoque;
        }

        [Required(ErrorMessage = "O Campo IDProduto é Obrigatorio!")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "O Campo Estoque é Obrigatorio!")]
        public int Estoque { get; set; }

        public ProdutoDto Produto { get; set; }
    }
}



