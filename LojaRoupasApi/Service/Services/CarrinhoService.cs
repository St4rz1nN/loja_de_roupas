using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Service.Services
{
    public class CarrinhoService : BaseService<CarrinhoDto, Carrinho>, ICarrinhoService
    {
        private readonly ICarrinhoRepository _repository;
        private readonly IItemCarrinhoService _serviceItemCarrinho;
        private readonly IMapper _mapper;

        public CarrinhoService(ICarrinhoRepository repository, IItemCarrinhoService serviceItemCarrinho, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _serviceItemCarrinho = serviceItemCarrinho;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ItemCarrinhoDto>> ListarItemsByIdCarrinho(Guid Id)
        {
            var items = await _serviceItemCarrinho.GetItemsByIdCarrinho(Id);
            return items;
        }
    }
}
