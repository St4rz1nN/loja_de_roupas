using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;

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
    }
}
