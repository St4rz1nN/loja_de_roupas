using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<Guid> AddAsync(CarrinhoDto carrinhodto)
        {
            var carrinhoencontrado = await GetCarrinhoAtivoByIdUsuarioAsync(carrinhodto.IdUsuario);

            if (carrinhoencontrado == null)
            {
                var carrinho = _mapper.Map<Carrinho>(carrinhodto);
                Guid id = await _repository.AddAsync(carrinho);
                return id;
            }
            else
            {
                throw new InvalidOperationException("Já existe um carrinho ativo nesse usuario!");
            }

        }

        public async Task<IEnumerable<ItemCarrinhoDto>> ListarItemsByIdCarrinho(Guid Id)
        {
            var items = await _serviceItemCarrinho.GetItemsByIdCarrinho(Id);
            return items;
        }

        public async Task<bool> GetCarrinhoAtivoById(Guid IdCarrinho)
        {
            var carrinhos = await _repository.GetAllAsync();

            var carrinhoselecionado = carrinhos.FirstOrDefault(c => c.Id == IdCarrinho);

            if(carrinhoselecionado.IdCompra == Guid.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<CarrinhoDto>> GetCarrinhoByIdUsuario(Guid IdUsuario)
        {
            var carrinhos = await _repository.GetAllAsync();

            var carrinhoencontrado = carrinhos.Where(c => c.IdUsuario == IdUsuario);

            var carrinhoencontradodto = _mapper.Map<IEnumerable<CarrinhoDto>>(carrinhoencontrado);

            return carrinhoencontradodto;
        }

        public async Task<CarrinhoDto> GetCarrinhoAtivoByIdUsuarioAsync(Guid IdUsuario)
        {
            var carrinhosusuario = await GetCarrinhoByIdUsuario(IdUsuario);

            var carrinhoativo = carrinhosusuario.FirstOrDefault(c => c.IdCompra == Guid.Empty);

            return carrinhoativo;
        }
    }
}
