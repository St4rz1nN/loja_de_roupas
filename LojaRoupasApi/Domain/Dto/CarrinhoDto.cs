using AutoMapper.Configuration.Annotations;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Dto.Base;
using LojaRoupasApi.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace LojaRoupasApi.Domain.Models
{
    public class CarrinhoDto : BaseDto
    {

        public CarrinhoDto()
            => Id = Guid.NewGuid();

        public CarrinhoDto(Guid IdUsuario)
        {
            this.IdUsuario = IdUsuario;
            Items = new List<ItemCarrinhoDto>();
        }

        [Required(ErrorMessage = "O Campo IdUsuario é Obrigatorio!")]
        public Guid IdUsuario { get; set; }

        public Guid IdCompra { get; set; }

        public ICollection<ItemCarrinhoDto> Items { get; set; }

        public decimal Total { get; set; }

        public UsuarioDto Usuario { get; set; }
        public CompraDto Compra { get; set; }

    }
}