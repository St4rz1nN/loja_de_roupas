using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaRoupasApi.Service.Services
{
    public class ItemCarrinhoService : BaseService<ItemCarrinhoDto, ItemCarrinho>, IItemCarrinhoService
    {
        private readonly IItemCarrinhoRepository _repository;
        private readonly IMapper _mapper;

        public ItemCarrinhoService(IItemCarrinhoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public override async Task<Guid> AddAsync(ItemCarrinhoDto itemcarrinho)
        {

            var itemcarrinhos = await _repository.GetAllAsync();

            var itemcarrinhoencontrado = itemcarrinhos.FirstOrDefault(ic => ic.IdCarrinho == itemcarrinho.IdCarrinho && ic.IdProduto == itemcarrinho.IdProduto);

            if (itemcarrinhoencontrado != null)
            {
                itemcarrinhoencontrado.Quantia += 1;
                await _repository.UpdateAsync(itemcarrinhoencontrado);
                return itemcarrinhoencontrado.Id;
            }
            else
            {
                var itemcarrinhoentity = _mapper.Map<ItemCarrinho>(itemcarrinho);


                Guid id = await _repository.AddAsync(itemcarrinhoentity);
                return id;
            }
        }

        public async Task RemoverPorIdAsync(Guid Id)
        {


            var itemcarrinho = await _repository.GetByIdAsync(Id);


            if (itemcarrinho != null)
            {
                itemcarrinho.Quantia -= 1;
                if (itemcarrinho.Quantia < 1)
                {
                    await _repository.DeleteAsync(Id);
                }
                else
                {
                    await _repository.UpdateAsync(itemcarrinho);
                }
            }
            else
            {

                throw new InvalidOperationException("Item não encontrado no carrinho.");
            }
        }


        public async Task<IEnumerable<ItemCarrinhoDto>> GetItemsByIdCarrinho(Guid Id)
        {


            var items = await _repository.GetAllAsync();
            var itemscarrinho = items.Where(i => i.IdCarrinho == Id);

            var itemscarrinhoDto = _mapper.Map<IEnumerable<ItemCarrinhoDto>>(itemscarrinho);


            return itemscarrinhoDto;
        }
    }
}
