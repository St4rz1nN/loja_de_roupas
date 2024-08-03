using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Base;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Domain.Interfaces.Services
{
    public interface ICarrinhoService : IBaseService<CarrinhoDto, Carrinho>
    {


        public Task<IEnumerable<ItemCarrinhoDto>> ListarItemsByIdCarrinho(Guid Id);

    }
}
