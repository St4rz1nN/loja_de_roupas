using AutoMapper;
using LojaRoupasApi.Data.Repositories;
using LojaRoupasApi.Domain.Dto;
using LojaRoupasApi.Domain.Interfaces.Data;
using LojaRoupasApi.Domain.Interfaces.Services;
using LojaRoupasApi.Domain.Models;

namespace LojaRoupasApi.Service.Services
{
    public class CompraService : BaseService<CompraDto, Compra>, ICompraService
    {
        private readonly ICompraRepository _repository;
        private readonly IMapper _mapper;

        public CompraService(ICompraRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
