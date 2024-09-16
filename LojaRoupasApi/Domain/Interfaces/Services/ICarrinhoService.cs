using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Base;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Domain.Interfaces.Services
{
    public interface ICarrinhoService : IBaseService<CarrinhoDto, Carrinho>
    {
        public Task<Guid> AddAsync(CarrinhoDto carrinhodto);
        public Task<IEnumerable<ItemCarrinhoDto>> ListarItemsByIdCarrinho(Guid Id);

        public Task<IEnumerable<CarrinhoDto>> GetCarrinhoByIdUsuario(Guid IdUsuario);

        public Task<CarrinhoDto> GetCarrinhoAtivoByIdUsuarioAsync(Guid IdUsuario);

    }
}
