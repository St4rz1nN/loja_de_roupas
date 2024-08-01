using LojaRoupasApi.Domain.Dto.Base;
using LojaRoupasApi.Domain.Models;
using Org.BouncyCastle.Utilities;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Dto
{
    public class CompraDto : BaseDto
    {
        public CompraDto()
            => Id= Guid.NewGuid();

        public CompraDto(Guid idusuario, Guid idcarrinho, DateTime data, int situacao)
        {
            this.IdUsuario = idusuario;
            this.IdCarrinho = idcarrinho;
            this.Data = data;
            this.Situacao = situacao;
        }

        [Required(ErrorMessage = "O Campo IDUsuario é Obrigatorio!")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O Campo IDCarrinho é Obrigatorio!")]
        public Guid IdCarrinho { get; set; }

        [Required(ErrorMessage = "O Campo Data é Obrigatorio!")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O Campo Situacao é Obrigatorio!")]
        public int Situacao { get; set; }
        [Required(ErrorMessage = "O Campo ValorTotal é Obrigatorio!")]
        public decimal ValorTotal { get; set; }

        public UsuarioDto Usuario { get; set; }
        public CarrinhoDto Carrinho { get; set; }
    }
}
