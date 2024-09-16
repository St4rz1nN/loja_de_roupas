using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Dto
{
    public class ProdutoDto : BaseDto
    {
        public ProdutoDto()
            => Id = Guid.NewGuid();

        [Required(ErrorMessage = "O Campo Nome é Obrigatorio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo Tipo é Obrigatorio!")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O Campo Tamanho é Obrigatorio!")]
        public string Tamanho { get; set; }
        [Required(ErrorMessage = "O Campo Cor é Obrigatorio!")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O Campo Valor é Obrigatorio!")]
        public decimal Valor { get; set; }
    }
}
