using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Base;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Domain.Interfaces.Services
{
    public interface IItemCarrinhoService : IBaseService<ItemCarrinhoDto, ItemCarrinho>
    {

        public Task<Guid> AddAsync(ItemCarrinhoDto itemcarrinho);

        public Task RemoverPorIdAsync(Guid Id);

        public Task<IEnumerable<ItemCarrinhoDto>> GetItemsByIdCarrinho(Guid Id);
    }
}
