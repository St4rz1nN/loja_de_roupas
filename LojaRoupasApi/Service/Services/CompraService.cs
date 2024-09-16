using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;
using System.Linq.Expressions;

namespace LojaRoupasApi.Service.Services
{
    public class CompraService : BaseService<CompraDto, Compra>, ICompraService
    {
        private readonly ICompraRepository _repository;
        private readonly ICarrinhoService _serviceCarrinho;
        private readonly IMapper _mapper;

        public CompraService(ICompraRepository repository, ICarrinhoService serviceCarrinho, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _serviceCarrinho = serviceCarrinho;
            _mapper = mapper;
        }


        public async Task<Guid> AddAsync(CompraDto compradto)
        {
            try
            {
                var idcarrinho = compradto.IdCarrinho;

                var carrinhodto = await _serviceCarrinho.GetByIdAsync(idcarrinho);

                if (carrinhodto.IdCompra != Guid.Empty)
                {
                    throw new InvalidOperationException("Ops, esse carrinho já está vinculado a uma Compra!");
                }

                var compra = _mapper.Map<Compra>(compradto);

                Guid id = await _repository.AddAsync(compra);

                carrinhodto.IdCompra = compra.Id;
                await _serviceCarrinho.UpdateAsync(carrinhodto);

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service: Erro ao Adicionar Compra " + ex.Message);
                throw;
            }

        }


        public async Task<CompraDto> GetCompraByIdCarrinho(Guid IdCarrinho)
        {

            var compras = await _repository.GetAllAsync();

            var compracarrinho = compras.Where(c => c.IdCarrinho == IdCarrinho);

            var compradto = _mapper.Map<CompraDto>(compracarrinho);

            return compradto;
        }

        public async Task<IEnumerable<CompraDto>> GetCompraByIdUsuario(Guid IdUsuario)
        {

            var compras = await _repository.GetAllAsync();

            var comprasusuario = compras.Where(c => c.Carrinho.IdUsuario == IdUsuario);

            var comprasusuariodto = _mapper.Map<IEnumerable<CompraDto>>(comprasusuario);

            return comprasusuariodto;
        }
    }
}
